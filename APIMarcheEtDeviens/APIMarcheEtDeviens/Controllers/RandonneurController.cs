using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;
using APIMarcheEtDeviens.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RandonneurController : ControllerBase
	{

		public static Randonneur randonneur = new Randonneur();

		private readonly IConfiguration _configuration;
		private readonly DataContext _DbContext;
		private readonly IController<Guid, RandonneurDTO> randonneurService;
		public RandonneurController(IController<Guid, RandonneurDTO> service, IConfiguration configuration, DataContext dbContext)


		{
			_DbContext = dbContext;
			randonneurService = service;
			_configuration = configuration;
		}

		[HttpGet]
		public async Task<ActionResult<List<RandonneurDTO>>> GetAllRandonneurs()
		{
			var result = await randonneurService.GetAll();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<RandonneurDTO>> GetRandonneurById(Guid id)
		{
			var result = await randonneurService.GetById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		[HttpPost]

		public async Task<ActionResult<List<RandonneurDTO>>> AddRole(RandonneurDTO randonneur)
		{
			var result = await randonneurService.Add(randonneur);
			if (result is null)
				return BadRequest();

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<RandonneurDTO>>> DeleteRole(Guid id)
		{
			var result = await randonneurService.DeleteById(id);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult<List<RandonneurDTO>>> Update(Guid id, RandonneurDTO randonneur)
		{
			var result = await randonneurService.Update(id, randonneur);
			if (result is null)
				return NotFound("Role not found");

			return Ok(result);
		}


		// methode d'enregistrement d'un randonneur

		[HttpPost("enregistrer")]
		public async Task<ActionResult<Randonneur>> Enregistrer(RandonneurDTO requete)
		{
			try
			{
				// hash et salt du mdp
				CreatePasswordHash(requete.MotDePasse, out byte[] motDePasseSalt, out byte[] motDePasseHash);

				// creation d'un nouveau randpnneur avec un id,nom,prenom,mail et tel
				// ainsi que les hash et salt du mdp
				randonneur.RandonneurId = Guid.NewGuid();
				randonneur.Mail = requete.Mail;
				randonneur.Nom = requete.Nom;
				randonneur.Prenom = requete.Prenom;
				randonneur.MotDePasseHash = motDePasseHash;
				randonneur.MotDePasseSalt = motDePasseSalt;
				randonneur.Telephone = requete.Telephone;
				randonneur.RoleId = 1;
				_DbContext.Randonneur.Add(randonneur);
				_DbContext.SaveChanges();
				return Ok(randonneur);
			}
			// si échec, gestion de l'erreur avec un message
			catch (Exception ex)
			{
				return StatusCode(500, $"Erreur du serveur : {ex.Message}");
			}
		}

		// fonction de creation du hash et salt du mdp en sha512 et retour du salt et hash 
		private void CreatePasswordHash(string password, out byte[] motDePasseHash, out byte[] motDePasseSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				motDePasseSalt = hmac.Key;
				motDePasseHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}
		[HttpPost("login")]
		// fonction qui connecte un randonneur avec un DTO
		public async Task<ActionResult<Randonneur>> Connecter(ConnectionRandonneurDTO requete)
		{
			//si requête est vide ou un champs vide, envoie d'une erreur
			if (requete == null || string.IsNullOrEmpty(requete.Mail) || string.IsNullOrEmpty(requete.MotDePasse))
			{
				return BadRequest("formulaire incomplet");
			}

			// recherche du mail dans la bdd et assignation à la variable randonneur
			var randonneur = await _DbContext.Randonneur.FirstOrDefaultAsync(r => r.Mail == requete.Mail);

			// si randonneur n'est pas trouvé ou si le mdp est incorrect, renvoie d'un mesaage
			if (randonneur == null || VerifyPasswordHash(requete.MotDePasse, randonneur.MotDePasseHash, randonneur.MotDePasseSalt))
			{

				return BadRequest("Mail ou Mot de passe  incorrect");
			}
			try
			{
				//si mail et mdp correspondant, génération d'un token
				string token = CreationToken(randonneur);
				//retour d'un retour
				return Ok(new { Randonneur = randonneur, Token = token });

			}
			// si "try" à échouer, envoie d'une erreur  
			catch (Exception ex)
			{
				return StatusCode(500, $"Erreur du serveur : {ex.Message} - {ex.StackTrace}");
			}

		}

		// méthode qui vérifie si le hash et salt du mdp entrée sur le formulaire
		// est identique à celui de la database
		private bool VerifyPasswordHash(string Password, byte[] motDePasseHash, byte[] motDePasseSalt)
		{
			// utilisation de la cle de cryptage sha512
			using (var hmac = new HMACSHA512(motDePasseSalt))
			{
				// hash du mot de passe 
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
				return computedHash.SequenceEqual(motDePasseHash);
			}
		}

		// fonction de creation de token
		private string CreationToken(Randonneur randonneur)
		{
			// création de claim
			List<Claim> claims = new List<Claim> {
				new Claim(ClaimTypes.Email, randonneur.Mail),
				new Claim(ClaimTypes.Role, "User")
			};
			// génération du token
			var secretKey = _configuration.GetValue<string>("Token");
			// vérification si token est existant
			if (string.IsNullOrEmpty(secretKey))
			{
				throw new InvalidOperationException("La clé secrète du token n'est pas configurée.");
			}
			// génération de la clé pour le token
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

			// génération de la signature pour le token
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

			// génération de la structure token avec les claims,
			// credentials et la date d'expiration
			var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: creds
				);

			// création du token
			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			//renvoie du token
			return jwt;
		}
	}
}



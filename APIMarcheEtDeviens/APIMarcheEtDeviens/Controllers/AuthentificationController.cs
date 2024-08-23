using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Migrations;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace APIMarcheEtDeviens.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthentificationController : ControllerBase
	{
		public static Randonneur randonneur = new Randonneur();

		private readonly IConfiguration _configuration;
		private readonly DataContext _dataContext;
		public AuthentificationController(DataContext dataContext, IConfiguration configuration)
		{
			_configuration = configuration;
			_dataContext = dataContext;
		}



		// methode d'enregistrement d'un randonneur
		[HttpPost("enregistrer")]
		public async  Task<ActionResult<Randonneur>> Enregistrer(RandonneurDTO requete)
		{
			try { 
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
			_dataContext.Randonneur.Add(randonneur);
			_dataContext.SaveChanges();
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
		public async Task<ActionResult<Randonneur>> Connecter(LoginDTO requete)
		{
			//si requête est vide ou un champs vide, envoie d'une erreur
			if (requete == null || string.IsNullOrEmpty(requete.Mail) || string.IsNullOrEmpty(requete.MotDePasse))
			{
				return BadRequest("formulaire incomplet");
			}

			// recherche du mail dans la bdd et assignation à la variable randonneur
			var randonneur = await _dataContext.Randonneur.FirstOrDefaultAsync(r => r.Mail == requete.Mail);

			// si randonneur n'est pas trouvé ou si le mdp est incorrect, renvoie d'un mesaage
			if (randonneur == null || !VerifyPasswordHash(requete.MotDePasse, randonneur.MotDePasseHash, randonneur.MotDePasseSalt))
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

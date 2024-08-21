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



		// methode d'enregistrement du mail est du mot de passe (le mdp est  hashe)
		[EnableCors]
		[HttpPost("enregistrer")]
		public async  Task<ActionResult<Randonneur>> Enregistrer(RandonneurDTO requete)
		{
			try { 
			CreatePasswordHash(requete.MotDePasse, out byte[] motDePasseSalt, out byte[] motDePasseHash);

			 
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
			catch (Exception ex)
			{
				return StatusCode(500, $"Erreur du serveur : {ex.Message}");
			}
		}

		private void CreatePasswordHash(string password, out byte[] motDePasseHash, out byte[] motDePasseSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				motDePasseSalt = hmac.Key;
				motDePasseHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		[HttpPost("login")]
		public async Task<ActionResult<Randonneur>> Connecter(LoginDTO requete)
		{

			if (requete == null || string.IsNullOrEmpty(requete.Mail) || string.IsNullOrEmpty(requete.MotDePasse))
			{
				return BadRequest("formulaire incomplet");
			}

			var randonneur = await _dataContext.Randonneur.FirstOrDefaultAsync(r => r.Mail == requete.Mail);

			if (randonneur == null ||VerifyPasswordHash(requete.MotDePasse, randonneur.MotDePasseHash, randonneur.MotDePasseSalt))
			{
				return BadRequest("Mail ou Mot de passe  incorrect");
			}
			try
			{

				string token = CreationToken(randonneur);

				return Ok(new { Randonneur = randonneur, Token = token });

			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Erreur du serveur : {ex.Message} - {ex.StackTrace}");
			}

		}
		private bool VerifyPasswordHash(string Password, byte[] motDePasseHash, byte[] motDePasseSalt)
		{
			using (var hmac = new HMACSHA512(motDePasseSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
				return computedHash.SequenceEqual(motDePasseHash);
			}
		}
		private string CreationToken(Randonneur randonneur)
		{
			List<Claim> claims = new List<Claim> {
				new Claim(ClaimTypes.Email, randonneur.Mail),
				new Claim(ClaimTypes.Role, "User")
			};

			var secretKey = _configuration.GetValue<string>("Token");

			if (string.IsNullOrEmpty(secretKey))
			{
				throw new InvalidOperationException("La clé secrète du token n'est pas configurée.");
			}

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));


			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

			var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: creds
				);


			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}
	}
}

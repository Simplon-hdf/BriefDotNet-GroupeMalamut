using Microsoft.AspNetCore.Mvc;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using APIMarcheEtDeviens.Data;
using Microsoft.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Controllers
{
	public class Authentification : ControllerBase
	{
		public  Randonneur randonneur = new Randonneur();

		private readonly IConfiguration _configuration;
		private readonly DataContext _dataContext;
		public Authentification(DataContext dataContext, IConfiguration configuration)
		{
			
			_dataContext = dataContext;
			_configuration = configuration;
		}
		


		// methode d'enregistrement du mail est du mot de passe (le mdp est sale et hashe)
		[HttpPost("enregistrer")]
		public async Task<List<Randonneur>> Enregistrer(RandonneurDTO requete)
		{
			CreerMotDePassHash(requete.MotDePasse, out byte[] passwordHash, out byte[] passwordSalt);
			randonneur.Mail = requete.Mail;
			randonneur.Nom = requete.Nom;
			randonneur.Prenom = requete.Prenom;
			randonneur.MotDePasse = requete.MotDePasse;
			randonneur.MotDePasseHash = passwordHash;
			randonneur.MotDePasseSalt = passwordSalt;
			await _dataContext.Randonneur.AddAsync(randonneur);

			await _dataContext.SaveChangesAsync();

			return await _dataContext.Randonneur.ToListAsync();

		}

		private void CreerMotDePassHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}


		[HttpPost("login")]
		public async Task<ActionResult<string>> Login(RandonneurDTO requete)
		{
			if (randonneur.Mail != requete.Mail)
				return BadRequest("User not found");

			if (!VerifyPasswordHash(requete.MotDePasse, randonneur.MotDePasseHash, randonneur.MotDePasseSalt))
				return BadRequest("Wrong password");

			string token = CreateToken(randonneur);

			return Ok(token);
		}


		private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computedHash.SequenceEqual(passwordHash);
			}
		}


		private string CreateToken(Randonneur randonneur)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, randonneur.Mail),
				new Claim(ClaimTypes.Role, "Admin")
	  
	   };

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
					_configuration.GetSection("AppSettings:Token").Value));
			var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
			var token = new JwtSecurityToken(
								   claims: claims,
								   expires: DateTime.UtcNow.AddDays(1),
								   signingCredentials: cred
   );
			var jwt = new JwtSecurityTokenHandler().WriteToken(token);
			return jwt;
		}
	}
}

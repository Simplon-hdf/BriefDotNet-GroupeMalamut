using APIMarcheEtDeviens.Data;
using APIMarcheEtDeviens.Models;
using APIMarcheEtDeviens.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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



		// methode d'enregistrement du mail est du mot de passe (le mdp est sale et hashe)
		[HttpPost("enregistrer")]
		public ActionResult<Randonneur> Enregistrer(RandonneurDTO requete)
		{
			string passwordHash
				= BCrypt.Net.BCrypt.HashPassword(requete.MotDePasse);

			randonneur.Mail = requete.Mail;
			randonneur.MotDePasse = passwordHash;
			randonneur.Nom = requete.Nom;
			randonneur.Prenom = requete.Prenom;
			_dataContext.Randonneur.Add(randonneur);
			_dataContext.SaveChanges();
			return Ok(randonneur);
		}


		[HttpPost("login")]
		public ActionResult<Randonneur> Connecter(LoginDTO requete)
		{
			if (requete == null || requete.Mail == null || requete.Password == null)
			{
				return BadRequest("formulaire incomplet");
			}
			 if ( randonneur.Mail != requete.Mail || !BCrypt.Net.BCrypt.Verify(requete.Password, randonneur.MotDePasse))
			{
				return BadRequest("Mail ou Mot de passe  incorrect");
			}


			//string token = CreationToken(randonneur);

			return Ok(randonneur);
		}

		/*private string CreationToken(Randonneur randonneur)
		{
			List<Claim> claims = new List<Claim> {
				new Claim(ClaimTypes.Email, randonneur.Mail)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				_configuration.GetSection("AppSettings:Token").Value!));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

			var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: creds
				);


			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}*/
	}
}

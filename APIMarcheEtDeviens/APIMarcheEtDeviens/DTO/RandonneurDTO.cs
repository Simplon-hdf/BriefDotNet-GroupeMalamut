
using System.ComponentModel.DataAnnotations;

namespace APIMarcheEtDeviens.Services
{
	public class RandonneurDTO
	{
		public Guid RandonneurId { get; set; }
		public string Nom { get; set; } = string.Empty;
		public string Prenom { get; set; } = string.Empty;

		//[RegularExpression("[@]", ErrorMessage = "Veuillez entrer un email valide.")]
		public string Mail { get; set; } = string.Empty;

		//[RegularExpression(@"(?=.{8,})((?=.+\d)|(?=.+\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z])", ErrorMessage = "Le mot de passe doit contenir une majuscule, une minuscule, un chiffre et un caractère spécial")]
		public string MotDePasse { get; set; } = string.Empty;

		//[RegularExpression(@"([1-9](?:\d{2}){4})$", ErrorMessage = "Veuillez entrer un numero de téléphone valide.")]
		public int? Telephone { get; set; }

		public int RoleId { get; set; } = 1;
	}
}

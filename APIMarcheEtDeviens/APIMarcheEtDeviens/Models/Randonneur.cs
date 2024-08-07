using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
	public class Randonneur
	{
		[Key]
		[Column(TypeName = "nvarchar(128)")]
		public Guid RandonneurId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Nom { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Prenom { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string MotDePasse { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Mail { get; set; }


		public byte[] MotDePasseHash { get; set; }

		// ajoute une chaine de caractère au mdp pour plus de sécurité
		public byte[] MotDePasseSalt { get; set; }

		#region FK

		[ForeignKey("RoleId")]
		public Role? Role { get; set; }

		[InverseProperty("Randonneur")]
		public virtual ICollection<Participer> Participers { get; set; }
		#endregion

	}
}

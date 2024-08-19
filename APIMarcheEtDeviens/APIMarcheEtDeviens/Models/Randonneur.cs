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

		[Column(TypeName = "longtext")]
		public string MotDePasse { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Mail { get; set; }
		public int? Telephone { get; set; }
		public DateTime DateDeCreation { get; set; } = DateTime.Now;
		public DateTime DateDeMaj { get; set; } = DateTime.Now;
		#region FK
		public int RoleId { get; set; }

		[ForeignKey("RoleId")]
		public Role? Role { get; set; }

		[InverseProperty("Randonneur")]
		public virtual ICollection<Participant> Participers { get; set; }
		#endregion

	}
}

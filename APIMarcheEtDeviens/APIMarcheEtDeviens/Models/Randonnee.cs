using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
	public class Randonnee
	{
		[Key]
		[Column(TypeName = "nvarchar(128)")]
		public Guid RandonneeId { get; set; }
		public DateTime Date { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Pays { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Region { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Ville { get; set; }
		public float PrixTotal { get; set; }
		public int Duree { get; set; }
		public string Description { get; set; }
		public int NombreMaxPersonnes { get; set; }

		[InverseProperty("Randonnee")]
		public virtual ICollection<Participer> Participers { get; set; }

		[InverseProperty("Randonnee")]
		public virtual ICollection<Media> Medias { get; set; }

	}
}

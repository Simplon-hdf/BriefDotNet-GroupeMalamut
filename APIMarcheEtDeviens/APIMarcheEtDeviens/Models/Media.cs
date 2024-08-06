using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
	public class Media
	{
		[Key]
		[Column(TypeName = "nvarchar(128)")]
		public Guid MediaId { get; set; }
		public string ?CheminDuMedia { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string ?TypeMedia { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string ?NomMedia { get; set; }

		[ForeignKey("RandonneeId")]
		public Randonnee? Randonnee { get; set; }

		[InverseProperty("Media")]
		public virtual ICollection<Pensee> ?Pensees { get; set; }
	}
}

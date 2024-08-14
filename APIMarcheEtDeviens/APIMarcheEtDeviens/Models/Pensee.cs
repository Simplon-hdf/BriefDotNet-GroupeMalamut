using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
	public class Pensee
	{
		[Key]
		[Column(TypeName = "nvarchar(128)")]
		public Guid PenseeId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string ?NomDeLaPensee { get; set; }

		public string ?ContenuPensee { get; set; }
		public DateTime DateDeCreation { get; set; } = DateTime.Now;
		public DateTime DateDeMaj { get; set; } = DateTime.Now;

		[ForeignKey("MediaId")]
		public Media ?Media { get; set; }
	}
}

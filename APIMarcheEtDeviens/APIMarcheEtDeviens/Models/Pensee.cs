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

		[Column(TypeName = "nvarchar(50)")]
		public string ?ContenuPensee { get; set; }
		public DateTime Date {  get; set; }

		[ForeignKey("MediaId")]
		public Media ?Media { get; set; }
	}
}

using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
	public class PenseeDto
	{
		[Column(TypeName = "nvarchar(50)")]
		public string? NomDeLaPensee { get; set; }

		public string? ContenuPensee { get; set; }
		public DateTime Date { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public Guid MediaId {  get; set; }

	}
}

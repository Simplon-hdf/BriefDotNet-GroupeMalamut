using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
	public class RandonneeDto
	{
		public DateTime Date { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Name { get; set; }

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
	}
}

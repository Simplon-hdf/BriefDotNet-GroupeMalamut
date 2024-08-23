using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Services
{
    public class RandonneeDto
    {
		public Guid RandonneeId { get; set; }
		public DateTime Date { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Pays { get; set; } = string.Empty;
		public string Region { get; set; } = string.Empty;
		public string Ville { get; set; } = string.Empty;
		public float PrixTotal { get; set; }
		public int Duree { get; set; }
		public string Description { get; set; } = string.Empty;
		public int NombreMinPersonnes { get; set; }
		public int NombreMaxPersonnes { get; set; }

	}
}

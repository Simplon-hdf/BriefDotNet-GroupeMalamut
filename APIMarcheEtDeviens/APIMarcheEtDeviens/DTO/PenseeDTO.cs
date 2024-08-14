using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Services
{
    public class PenseeDto
    {
		public string? NomDeLaPensee { get; set; } = string.Empty;
		public string? ContenuPensee { get; set; } = string.Empty;

        public Guid MediaId { get; set; }

    }
}

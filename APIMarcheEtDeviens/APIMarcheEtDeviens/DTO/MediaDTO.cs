using Microsoft.JSInterop.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Services
{
    public class MediaDto
    {
		public Guid MediaId { get; set; }
		public string? CheminDuMedia { get; set; } = string.Empty;
		public string? TypeMedia { get; set; } = string.Empty;
		public string? NomMedia { get; set; } = string.Empty;
		
        public string? IdRandonnee { get; set; }

    }
}

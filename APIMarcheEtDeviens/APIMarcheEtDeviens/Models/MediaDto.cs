using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
    public class MediaDto
    {
		[Column(TypeName = "nvarchar(128)")]
		public Guid MediaId { get; set; }
		public string? CheminDuMedia { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? TypeMedia { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? NomMedia { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? IdRandonnee { get; set; }

	}
}

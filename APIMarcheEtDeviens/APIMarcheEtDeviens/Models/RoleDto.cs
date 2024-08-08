using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
	public class RoleDto
	{
		[Column(TypeName = "nvarchar(50)")]
		public string Libelle { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
	public class Role
	{
		[Key]
		public int RoleId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Libelle { get; set; }

		[InverseProperty("Role")]
		public virtual ICollection<Randonneur> Randonneurs { get; set; }
	}
}

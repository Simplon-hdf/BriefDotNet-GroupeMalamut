
namespace APIMarcheEtDeviens.Services
{
	public class RandonneurDTO
	{
		public string Nom {  get; set; } = string.Empty;
		public string Prenom { get; set; } = string.Empty;
		public string Mail {  get; set; } = string.Empty;
		public string MotDePasse { get; set; }  = string.Empty;
		public int? Telephone { get; set; }

		public int RoleId { get; set; }
	}
}

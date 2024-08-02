namespace APIMarcheEtDeviens.Models
{
	public class Role
	{
		public int Id { get; set; }
		public string Libelle { get; set; }

		public ICollection<Randonneur> Randonneurs { get; set; }
	}
}

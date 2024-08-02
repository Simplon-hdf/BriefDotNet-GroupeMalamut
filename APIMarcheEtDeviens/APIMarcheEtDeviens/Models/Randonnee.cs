namespace APIMarcheEtDeviens.Models
{
	public class Randonnee
	{
		public string Id { get; set; }
		public DateTime Date { get; set; }
		public string Pays { get; set; }
		public string Region { get; set; }
		public string Ville { get; set; }
		public float PrixTotal { get; set; }
		public int Duree { get; set; }
		public string Description { get; set; }
		public int NombreMaxPersonnes { get; set; }

		public ICollection<Participer> Participer { get; set; }
	}
}

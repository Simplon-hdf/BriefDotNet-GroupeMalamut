namespace APIMarcheEtDeviens.Models
{
	public class Media
	{
		public string Id { get; set; }
		public string CheminDuMedia { get; set; }
		public string TypeMedia { get; set; }
		public string NomMedia { get; set; }

		public Randonnee Randonnee { get; set; }
		public ICollection<Pensee?> Pensees { get; set; }
	}
}

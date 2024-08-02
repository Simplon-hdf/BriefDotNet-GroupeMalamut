namespace APIMarcheEtDeviens.Models
{
	public class Randonneur
	{
		public string Id { get; set; }
		public string Nom { get; set; }
		public string Prenom { get; set; }
		public string MotDePasse { get; set; }
		public string Mail { get; set; }

		#region FK

		public Role Role { get; set; }
		public ICollection<Participer> Participer { get; set; }
		#endregion

	}
}

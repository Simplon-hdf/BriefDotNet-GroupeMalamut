using APIMarcheEtDeviens.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace APIMarcheEtDeviens.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Media> Media { get; set; }
		public DbSet<Participant> Participer { get; set; }
		public DbSet<Randonnee> Randonnee { get; set; }
		public DbSet<Randonneur> Randonneur { get; set; }
		public DbSet<Role> Role { get; set; }
		public DbSet<Pensee> Pensee { get; set; }

		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{

		}


		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
		}
	}
}

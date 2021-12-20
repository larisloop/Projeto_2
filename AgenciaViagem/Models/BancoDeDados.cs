using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagem.Models
{
    public class BancoDeDados : DbContext
    {
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }

        public DbSet<Hotel> Hoteis { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-D2NE7RB;Database=AgenciaViagem;Integrated Security=True");
        }
        
    }
}

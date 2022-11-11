using Microsoft.EntityFrameworkCore;


namespace GlobalSolution.Models
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Estacionamento> Estacionamento { get; set; }

        public DbSet<Carro> Carro { get; set; }

    }

}




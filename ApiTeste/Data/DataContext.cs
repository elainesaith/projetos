using Microsoft.EntityFrameworkCore;
using ApiTeste.Models;

namespace ApiTeste.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Evento> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=Teste_db; User Id=sa; Password=masterkey");
        }
    }
}

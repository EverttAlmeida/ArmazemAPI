using Microsoft.EntityFrameworkCore;
using ArmazemAPI.Models;

namespace ArmazemAPI.Context
{
    public class ArmazemDBContext:DbContext
    {
        public ArmazemDBContext(DbContextOptions<ArmazemDBContext> options) : base (options)
        {

        }
        public DbSet<Models.Armazem> Armazems { get; set; }
        public DbSet<ArmazemAPI.Models.Cliente>? Cliente { get; set; }
        public DbSet<ArmazemAPI.Models.Fornecedor>? Fornecedor { get; set; }

    }
}

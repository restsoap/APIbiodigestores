using BiodigestoresAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BiodigestoresAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Ubicacion> Ubicaciones { get; set; }

        public DbSet<Extension> Extensiones { get; set; }

        public DbSet<Biodigestor> Biodigestores { get; set; }
    }
}

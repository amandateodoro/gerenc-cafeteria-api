using CafeManiaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManiaApi.DataContexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Campus>()
            //    .HasMany(e => e.Servidores)
            //    .WithOne(e => e.Campus)
            //    .HasForeignKey(e => e.CampusId)
            //    .IsRequired(false);

            modelBuilder.Entity<Servidor>()
                .HasOne(e => e.Campus)
                .WithMany(e => e.Servidores)
                .HasForeignKey(e => e.CampusId)
                .IsRequired(false);
        }
    }
}

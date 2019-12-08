using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webApiClubDeport.Entities;
using webApiClubDeport.Models;

namespace webApiClubDeport.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            var roleAdmin = new IdentityRole()
            {
                Id = "f406bd6e-0de4-4679-874d-33bcb9c6861b",
                Name = "admin",
                NormalizedName = "admin"
            };

            builder.Entity<IdentityRole>().HasData(roleAdmin);

            base.OnModelCreating(builder);
            
        }

        public DbSet<Deporte> Deportes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Pista> Pistas { get; set; }

    }
}

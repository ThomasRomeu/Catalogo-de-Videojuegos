using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace primerParcial.Models
{
    public class VideojuegosDbContext : DbContext
    {
        public VideojuegosDbContext(DbContextOptions<VideojuegosDbContext> options) : base(options)
        {

        }

        public DbSet<Videojuego> Videojuegos { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
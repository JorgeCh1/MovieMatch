using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Entidades
{
    public partial class EntityContext : DbContext
    {
        public EntityContext()
            : base("name=EntityContext")
        {
        }

        public virtual DbSet<Peliculas> Peliculas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peliculas>()
                .HasMany(e => e.Usuarios)
                .WithMany(e => e.Peliculas)
                .Map(m => m.ToTable("PeliculasUsuarios").MapLeftKey("IdPelicula").MapRightKey("IdUsuario"));
        }
    }
}

namespace Entidades
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityContext : DbContext
    {
        public EntityContext()
            : base("name=EntityContext")
        {
        }

        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<CategoriaAction> CategoriaAction { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaAction>()
                .HasMany(e => e.Action)
                .WithRequired(e => e.CategoriaAction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Director>()
                .HasMany(e => e.Pelicula)
                .WithRequired(e => e.Director)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pelicula>()
                .HasMany(e => e.Action)
                .WithOptional(e => e.Pelicula)
                .HasForeignKey(e => new { e.IdPelicula, e.IdDirector });
        }
    }
}

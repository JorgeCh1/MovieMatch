namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Peliculas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Peliculas()
        {
            Comentarios = new HashSet<Comentarios>();
            Usuarios = new HashSet<Usuarios>();
        }

        [Key]
        public int IdPelicula { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Sinopsis { get; set; }

        public double? Rating { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaLanzamiento { get; set; }

        [StringLength(100)]
        public string Generos { get; set; }

        public string Poster { get; set; }

        public byte? Match { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentarios> Comentarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pelicula")]
    public partial class Pelicula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pelicula()
        {
            Action = new HashSet<Action>();
        }

        [Key]
        [Column(Order = 0)]
        public int IdPelicula { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDirector { get; set; }

        [Required]
        [StringLength(15)]
        public string Titulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaLanzamiento { get; set; }

        [StringLength(60)]
        public string Genero { get; set; }

        [Required]
        [StringLength(1000)]
        public string Sinopsis { get; set; }

        public double? Rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Action> Action { get; set; }

        public virtual Director Director { get; set; }
    }
}

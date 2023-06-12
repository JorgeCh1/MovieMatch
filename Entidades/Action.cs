namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Action")]
    public partial class Action
    {
        [Key]
        [Column(Order = 0)]
        public int IdAction { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCategoriaAction { get; set; }

        public int? Match { get; set; }

        public int? IdPelicula { get; set; }

        public int? IdDirector { get; set; }

        public virtual CategoriaAction CategoriaAction { get; set; }

        public virtual Pelicula Pelicula { get; set; }
    }
}

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string PrimerNombre { get; set; }

        [StringLength(50)]
        public string SegundoNombre { get; set; }

        [Required]
        [StringLength(50)]
        public string PrimerApellido { get; set; }

        [StringLength(50)]
        public string SegunoApellido { get; set; }

        [Column("Usuario")]
        [Required]
        [StringLength(50)]
        public string Usuario1 { get; set; }

        [Required]
        [StringLength(60)]
        public string Clave { get; set; }

        [Required]
        [StringLength(100)]
        public string CorreoElectronico { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaCreacionCuenta { get; set; }

        [MaxLength(200)]
        public byte[] Imagen { get; set; }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaWebEmpleado.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaWebEmpleado.Models
{

    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[A-Z]{2}[0-9]{5}$")]
        public string Legajo { get; set; }

        [CheckValidYearAttribute]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Titulo { get; set; }
    }
}

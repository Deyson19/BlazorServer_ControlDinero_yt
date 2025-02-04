using System.ComponentModel.DataAnnotations;

namespace BlazorServer_ControlDinero.Data
{
    public class ControlDinero
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Descripcion { get; set; }
        [Required]
        [Display(Name ="Tipo de Ingreso")]
        public bool EsIngreso { get; set; }

        [Required]
        public double Valor { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
    }

    public class UpsertControlDinero
    {
        [Required(ErrorMessage = "El campo {0} no es correcto.")]
        [StringLength(60,MinimumLength =5)]
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo {0} no es correcto.")]

        [Display(Name = "Tipo de Ingreso")]
        public bool EsIngreso { get; set; }

        [Required(ErrorMessage = "El campo {0} no es correcto.")]
        public double Valor { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
    }

}

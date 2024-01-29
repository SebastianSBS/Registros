using System.ComponentModel.DataAnnotations;

public class Prioridades
{
    [Key]
    public int PrioridadId { get; set; }

    [Required(ErrorMessage = "La descripcion no debe de resultar en nula")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Se debe de agregar los dias de compromiso")]

    [Range(0, 31)]
    public int DiasCompromiso { get; set; }
}
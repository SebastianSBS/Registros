using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tickets
{
    [Key]

    public int TicketId { get; set; }

    public DateTime Fecha { get; set; }

    [ForeignKey("ClienteId")]
    public int ClienteId { get; set; }

    [ForeignKey("SistemaId")]
    public int SistemaId { get; set; }

    [ForeignKey("PrioridadId")]
    public int PrioridadId { get; set; } 

    [Required(ErrorMessage = "Es necesario especificar por quien fue solicitado")]
    public string? SolicitadoPor { get; set; }

    [Required(ErrorMessage = "Especifique el asunto..")]
    public string? Asunto { get; set; }

    [Required(ErrorMessage = "Es necesario dar una descripcion")]
    public string? Descripcion { get; set; }

}

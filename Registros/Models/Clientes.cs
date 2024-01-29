using System.ComponentModel.DataAnnotations;

public class Clientes{
    [Key]

    public int ClienteId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(maximumLength: 30, MinimumLength = 15)]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar un numero de telefono.")]
    [StringLength(maximumLength:10, MinimumLength = 10)]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El celular es obligatorio.")]
    [StringLength(maximumLength: 10, MinimumLength = 10)]
    public string? Celular { get; set; }

    [Required(ErrorMessage = "El RNC es obligatorio.")]
    [StringLength(maximumLength: 14, MinimumLength = 14)]
    public string RNC { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar un correo electronico.")]
    [StringLength(maximumLength: 30, MinimumLength = 20)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Es necesario agregar una direccion.")]
    [StringLength(maximumLength: 50, MinimumLength = 6)]
    public string Direccion { get; set; } = string.Empty;
}
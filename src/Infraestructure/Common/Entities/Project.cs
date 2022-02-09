using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OlSoftware.Infraestructure.Common.Entities;
public class Project
{
    public Project() => Languages = new HashSet<Language>();

    [Key]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int ProjectId { get; set; }


    [DisplayName("Nombre del proyecto")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(128, ErrorMessage = "El campo {0} debe ser una cadena con una longitud máxima de {1}.")]
    public string Name { get; set; }

    [Required]
    [JsonIgnore]
    [ForeignKey("Client")]
    public int ClientId { get; set; }

    [JsonIgnore]
    public virtual Client Client { get; set; }

    [DisplayName("Fecha inicial")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DisplayName("Fecha final")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [DisplayName("Precio")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int Price { get; set; }

    [DisplayName("Horas totales")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int TotalHours { get; set; }

    [DisplayName("Estado")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [ForeignKey("Status")]
    public int StatusId { get; set; }

    [JsonIgnore]
    public virtual Status Status { get; set; }

    public virtual ICollection<Language> Languages { get; set; }
}
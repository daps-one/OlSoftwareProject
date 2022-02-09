using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OlSoftware.Infraestructure.Common.Entities;
public class Client
{
    public Client() => Projects = new HashSet<Project>();

    [Key]
    [Required]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClientId { get; set; }

    [DisplayName("Nombre")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(256, ErrorMessage = "El campo {0} debe ser una cadena con una longitud máxima de {1}.")]
    public string Name { get; set; }

    [DisplayName("Identificación")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(11, ErrorMessage = "El campo {0} debe ser una cadena con una longitud máxima de {1}.")]
    public string Identification { get; set; }

    [DisplayName("Dirección")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(256, ErrorMessage = "El campo {0} debe ser una cadena con una longitud máxima de {1}.")]
    public string Address { get; set; }
    
    [DisplayName("Teléfono")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(10, ErrorMessage = "El campo {0} debe ser una cadena con una longitud máxima de {1}.")]
    public string Phone { get; set; }

    [JsonIgnore]
    public virtual ICollection<Project> Projects { get; set; }
}
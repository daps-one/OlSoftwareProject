using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OlSoftware.Infraestructure.Common.Entities;
public class Language
{
    [Key]
    [Required]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LanguageId { get; set; }

    [DisplayName("Lenguaje")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(255, ErrorMessage = "El campo {0} debe ser una cadena con una longitud máxima de {1}.")]
    public string Description { get; set; }

    [DisplayName("Nivel")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int LevelId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(LevelId))]
    public virtual Level Level { get; set; }

    [Required]
    [JsonIgnore]
    public int ProjectId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(ProjectId))]
    public virtual Project Project { get; set; }
}
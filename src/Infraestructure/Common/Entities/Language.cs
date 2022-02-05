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

    [Required]
    [StringLength(255)]
    public string Description { get; set; }

    [Required]
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
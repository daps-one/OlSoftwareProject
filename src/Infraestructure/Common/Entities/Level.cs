using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OlSoftware.Infraestructure.Common.Entities;
public class Level
{
    public Level() => Languages = new HashSet<Language>();

    [Key]
    [Required]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LevelId { get; set; }

    [Required]
    [StringLength(10)]
    public string Description { get; set; }

    // [InverseProperty(nameof(Language.Level))]
    public virtual ICollection<Language> Languages { get; set; }
}
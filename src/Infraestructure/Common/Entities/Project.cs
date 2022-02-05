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

    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    [JsonIgnore]
    [ForeignKey("Client")]
    public int ClientId { get; set; }

    [JsonIgnore]
    public virtual Client Client { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int TotalHours { get; set; }

    [Required]
    [ForeignKey("Status")]
    public int StatusId { get; set; }

    [JsonIgnore]
    public virtual Status Status { get; set; }

    public virtual ICollection<Language> Languages { get; set; }
}
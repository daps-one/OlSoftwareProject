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

    [Required]
    [StringLength(256)]
    public string Name { get; set; }

    [Required]
    [StringLength(11)]
    public string Identification { get; set; }

    [Required]
    [StringLength(256)]
    public string Address { get; set; }
    
    [Required]
    [StringLength(10)]
    public string Phone { get; set; }

    [JsonIgnore]
    public virtual ICollection<Project> Projects { get; set; }
}
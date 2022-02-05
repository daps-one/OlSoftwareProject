using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlSoftware.Infraestructure.Common.Entities;
public class Status
{
    public Status() => Projects = new HashSet<Project>();

    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StatusId { get; set; }

    [Required]
    [StringLength(30)]
    public string Description { get; set; }

    public virtual ICollection<Project> Projects { get; set; }
}
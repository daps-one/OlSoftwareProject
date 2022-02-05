using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OlSoftware.Infraestructure.Common.Entities.NoMapped;

public class ClientReport
{
    [JsonProperty("id_cliente")]
    public int ClientId { get; set; }

    [JsonProperty("nombre_cliente")]
    public string Name { get; set; }

    [JsonProperty("identificacion_cliente")]
    public string Identification { get; set; }

    [JsonProperty("direccion_cliente")]
    public string Address { get; set; }

    [JsonProperty("telefono_cliente")]
    public string Phone { get; set; }

    [JsonProperty("proyectos")]
    public ICollection<ProjectReport> Projects { get; set; } = new HashSet<ProjectReport>();
}

public class ProjectReport
{
    [JsonProperty("id_proyecto")]
    public int ProjectId { get; set; }

    [JsonProperty("nombre")]
    public string ProjectName { get; set; }

    [DataType(DataType.Date)]
    [JsonProperty("fecha_inicio")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    [JsonProperty("fecha_fin")]
    public DateTime EndDate { get; set; }

    [JsonProperty("precio")]
    public int Price { get; set; }

    [JsonProperty("horas_totales")]
    public int TotalHours { get; set; }

    [JsonProperty("estado")]
    public string Status { get; set; }

    [JsonProperty("lenguajes")]
    public IEnumerable<LanguageReport> Languages { get; set; } = new HashSet<LanguageReport>();
}

public class LanguageReport
{
    [JsonProperty("lenguaje")]
    public string Language { get; set; }

    [JsonProperty("nivel")]
    public string Level { get; set; }
}

public class TemporalLanguagesReport
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Price { get; set; }

    public int TotalHours { get; set; }

    public string Status { get; set; }

    public string Language { get; set; }

    public string Level { get; set; }
}
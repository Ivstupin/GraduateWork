using GraduateWork.Models;
using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public record AutomationRun
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("source")] public string? Source { get; set; } 
}

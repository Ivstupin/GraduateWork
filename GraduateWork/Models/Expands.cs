
using GraduateWork.Models;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace GraduateWork.Models;

public record Expands
{
    [JsonPropertyName("expands")] public Expands[] configs { get; set; }
    [JsonPropertyName("configs")] public Expands[] Configs { get; set; }
    [JsonPropertyName("milestones")] public Expands[] Milestones { get; set; }
    [JsonPropertyName("users")] public Expands[] Users { get; set; }
}
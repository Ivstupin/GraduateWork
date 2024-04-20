
using GraduateWork.Models;
using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public record Projects
{
    [JsonPropertyName("page")] public int Page { get; set; }
    [JsonPropertyName("prev_page")] public string? Prev_page { get; set; }
    [JsonPropertyName("next_page")] public string? Next_page { get; set; }
    [JsonPropertyName("last_page")] public int Last_page { get; set; }
    [JsonPropertyName("per_page")] public int Per_page { get; set; }
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("result")] public List<Project> Result { get; set; } = new();
}

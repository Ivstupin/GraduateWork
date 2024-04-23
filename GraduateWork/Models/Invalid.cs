using GraduateWork.Models.Enums;
using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public record Invalid
{
    [JsonPropertyName("message")] public string? Message { get; set; }
    [JsonPropertyName("code")] public int Сode { get; set; }
}
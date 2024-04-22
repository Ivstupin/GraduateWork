
using GraduateWork.Models;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace GraduateWork.Models;

public record Project
{
    // [JsonPropertyName("result")] public List<Project> Result { get; set; } = new();
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("note")] public string? Note { get; set; }
    [JsonPropertyName("is_completed")] public bool Is_completed { get; set; }
    [JsonPropertyName("milestone_count")] public int Milestone_count { get; set; }
    [JsonPropertyName("milestone_active_count")] public int Milestone_active_count { get; set; }
    [JsonPropertyName("milestone_completed_count")] public int Milestone_completed_count { get; set; }
    [JsonPropertyName("run_count")] public int Run_count { get; set; }
    [JsonPropertyName("run_active_count")] public int Run_active_count { get; set; }
    [JsonPropertyName("run_closed_count")] public int Run_closed_count { get; set; }
    [JsonPropertyName("session_count")] public int Session_count { get; set; }
    [JsonPropertyName("session_active_count")] public int Session_active_count { get; set; }
    [JsonPropertyName("session_closed_count")] public int Session_closed_count { get; set; }
    [JsonPropertyName("automation_source_count")] public int Automation_source_count { get; set; }
    [JsonPropertyName("automation_source_active_count")] public int Automation_source_active_count { get; set; }
    [JsonPropertyName("automation_source_retired_count")] public int Automation_source_retired_count { get; set; }
    [JsonPropertyName("automation_run_count")] public int Automation_run_count { get; set; }
    [JsonPropertyName("automation_run_active_count")] public int Automation_run_active_count { get; set; }
    [JsonPropertyName("automation_run_completed_count")] public int Automation_run_completed_count { get; set; }
    [JsonPropertyName("created_at")] public string? Created_at { get; set; }
    [JsonPropertyName("created_by")] public int? Created_by { get; set; }
    [JsonPropertyName("updated_at")] public string? Updated_at { get; set; }
    [JsonPropertyName("updated_by")] public int? Updated_by { get; set; }
    [JsonPropertyName("completed_at")] public string? Completed_at { get; set; }
}
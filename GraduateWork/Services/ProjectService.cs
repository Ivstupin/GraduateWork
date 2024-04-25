using System.Net;
using GraduateWork.Models;
using GraduateWork.Services;
using RestSharp;
using GraduateWork.Models;

namespace GraduateWork.Services;

public class ProjectService : IProjectService, IDisposable
{
    private readonly RestClientExtended _client;
    private readonly string projectId = "325";

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public HttpStatusCode GetProject(Project project)
    {
        var request = new RestRequest("/api/v1/projects/{project_id}")
            .AddUrlSegment("project_id", projectId);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    /// <summary>
    /// вернёт все существующие проекты
    /// </summary>
    public Task<Projects> GetProjects()
    {
        var request = new RestRequest("/api/v1/projects");

        var projects = _client.ExecuteAsync<Projects>(request);
        return projects;
    }

    /// <summary>
    /// вернёт все существующие автозапуски
    /// </summary>
    public Task<Projects> GetAllAutomationRun()
    {
        var request = new RestRequest("/api/v1/projects/{project_id}/automation/runs")
            .AddUrlSegment("project_id", projectId);
            return _client.ExecuteAsync<Projects>(request);
    }

    public HttpStatusCode PostAutomationRun(AutomationRun automationRun)
    {
        var request = new RestRequest("/api/v1/projects/{project_id}/automation/runs", Method.Post)
           .AddUrlSegment("project_id", projectId)
            .AddJsonBody(automationRun);
        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    /// <summary>
    /// запрос несуществующего пользователя
    /// </summary>
    public Task<RestResponse> GetInvalidUser( )
    {
        var request = new RestRequest("/api/v1/users/2");
        return _client.ExecuteAsync(request);
    }

    /// <summary>
    /// запрос несуществующего проекта
    /// </summary>
    public Task<RestResponse> GetInvalidProject()
    {
        var request = new RestRequest("/api/v1/projects/9000");
        return _client.ExecuteAsync(request);
    }
    
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}
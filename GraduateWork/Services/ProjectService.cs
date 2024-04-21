using System.Net;
using GraduateWork.Clients;
using GraduateWork.Models;
using GraduateWork.Services;
using RestSharp;
using GraduateWork.Clients;
using GraduateWork.Models;

namespace GraduateWork.Services;

public class ProjectService : IProjectService, IDisposable
{
    private readonly RestClientExtended _client;
    private readonly string projectId = "189";

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Project> GetProject()
    {
        var request = new RestRequest("/api/v1/projects/{project_id}")
            .AddUrlSegment("project_id", projectId);

        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Projects> GetProjects()
    {
        var request = new RestRequest("/api/v1/projects");

        var projects = _client.ExecuteAsync<Projects>(request);
        return projects;
    }

    public Task<Projects> GetAllAutomationRuns()
    {
        var request = new RestRequest("/api/v1/projects/{project_id}/automation/runs")
            .AddUrlSegment("project_id", projectId);
            //.AddJsonBody(project);

        return _client.ExecuteAsync<Projects>(request);
    }

    public HttpStatusCode PostAutomationRun(AutomationRun automationRun)
    {
        var request = new RestRequest("/api/v1/projects/{project_id}/automation/runs", Method.Post)
           .AddUrlSegment("project_id", projectId)
            .AddJsonBody(automationRun);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    //public HttpStatusCode GetProject(string projectId)
    //{
    //    var request = new RestRequest("/api/v1/projects/{project_id}")
    //        .AddUrlSegment("project_id", projectId);
    //        //.AddJsonBody("{}");

    //    return _client.ExecuteAsync(request).Result.StatusCode;
    //}

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}
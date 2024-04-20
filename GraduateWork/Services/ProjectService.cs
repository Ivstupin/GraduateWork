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
    private readonly string projectId = "161";

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Project> GetProject(string projectId)
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

    public Task<Project> AddProject(Project project)
    {
        var request = new RestRequest("/api/v1/projects/161/automation/runs", Method.Post)
            .AddUrlSegment("project_id", project.Id)
            .AddJsonBody(project);

        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Project> UpdateProject(Project project)
    {
        var request = new RestRequest("index.php?/api/v2/update_project/{project_id}", Method.Post)
           .AddUrlSegment("project_id", project.Id)
            .AddJsonBody(project);

        return _client.ExecuteAsync<Project>(request);
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
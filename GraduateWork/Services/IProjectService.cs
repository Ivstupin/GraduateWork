using GraduateWork.Models;
using System.Net;
//using TestRailComplexApi.Models;

namespace GraduateWork.Services;

public interface IProjectService
{
    Task<Project> GetProject(string projectId);
    Task<Projects> GetProjects();
    Task<Project> AddProject(Project project);
    Task<Project> UpdateProject(Project project);
    //HttpStatusCode GetProject(string projectId);
}
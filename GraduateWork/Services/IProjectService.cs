using GraduateWork.Models;
using RestSharp;
using System.Net;

namespace GraduateWork.Services;

public interface IProjectService
{
    Task<Projects> GetProjects();
    Task<RestResponse> GetInvalidUser();
    Task<RestResponse> GetInvalidProject();
    Task<Projects> GetAllAutomationRun();
    HttpStatusCode PostAutomationRun(AutomationRun automationRun);
    HttpStatusCode GetProject(Project project);
}
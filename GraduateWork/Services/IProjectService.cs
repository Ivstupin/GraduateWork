using GraduateWork.Models;
using System.Net;
//using TestRailComplexApi.Models;

namespace GraduateWork.Services;

public interface IProjectService
{
    HttpStatusCode GetProject(Project project);
    Task<Projects> GetProjects();
    HttpStatusCode GetInvalidUser();
    Task<Projects> GetAllAutomationRun();
     HttpStatusCode PostAutomationRun(AutomationRun automationRun);
    //HttpStatusCode GetProject(string projectId);
}
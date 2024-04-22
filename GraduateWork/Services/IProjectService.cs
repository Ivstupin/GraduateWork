using GraduateWork.Models;
using System.Net;
//using TestRailComplexApi.Models;

namespace GraduateWork.Services;

public interface IProjectService
{
    Task<Project> GetProject();
    Task<Projects> GetProjects();
    Task<Projects> GetAllAutomationRuns();
     HttpStatusCode PostAutomationRun(AutomationRun automationRun);
    //HttpStatusCode GetProject(string projectId);
}
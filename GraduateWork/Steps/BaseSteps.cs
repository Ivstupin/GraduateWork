using GraduateWork.Pages;
using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class BaseSteps(IWebDriver driver)
{
    protected readonly IWebDriver Driver = driver;
    protected LoginPage? LoginPage { get; set; }
    protected ProjectsPage? ProjectsPage { get; set; }
    protected RepositoryPage? RepositoryPage { get; set; }
    protected ProjectsOverviewPage? ProjectsOverviewPage { get; set; }
    protected ProjectsAdminPage? ProjectsAdminPage { get; set; }
    protected AddProjectPage? AddProjectPage { get; set; }
}
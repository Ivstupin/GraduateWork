using GraduateWork.Helpers;
using GraduateWork.Pages;
using OpenQA.Selenium;
using System.Reflection;

namespace GraduateWork.Steps;

public class ActionsSteps : BaseSteps
{
    public AddProjectPage addProjectPage;
    public ProjectsPage projectsPage;
    public ProjectsOverviewPage projectsOverviewPage;
    public ProjectsAdminPage projectsAdminPage;
    public RepositoryPage repositoryPage;
    public ActionsSteps(IWebDriver driver) : base(driver)
    {
        addProjectPage = new AddProjectPage(Driver);
        
        projectsOverviewPage = new ProjectsOverviewPage(Driver);
        projectsAdminPage = new ProjectsAdminPage(Driver);
        projectsPage = new ProjectsPage(Driver);
        repositoryPage = new RepositoryPage(Driver);
    }

    /// <summary>
    /// со страницы ProjectsPage вызываем страницу AddProjectPage кликом по кнопке Project
    /// </summary>
    public AddProjectPage PlusProjectButtonClick() 
    {
        projectsPage._PlusProjectButton.Click();
        return new AddProjectPage(Driver);
    }

    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Summary
    /// </summary>
    public AddProjectPage InputValuesInSummaryInputField(string values)
    {
        addProjectPage.SummaryInputField.Click();
        addProjectPage.SummaryInputField.Clear();
        addProjectPage.SummaryInputField.SendKeys(values);
        return addProjectPage;
    }

    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Name
    /// </summary>
    public AddProjectPage InputValuesInNameInputField(string values)
    {
        addProjectPage.NameInputField.Click();
        addProjectPage.NameInputField.Clear();
        addProjectPage.NameInputField.SendKeys(values);
        return addProjectPage;
    }

    public RepositoryPage NameInputFieldAddTestCase(string values)
    {
        repositoryPage.NameInputField.Click();
        repositoryPage.NameInputField.Clear();
        repositoryPage.NameInputField.SendKeys(values);
        return repositoryPage;
    }
    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Name
    /// </summary>
    public ProjectsOverviewPage AddProjectButtonClick()
    {
        addProjectPage._AddProjectButton.Click();
        
        return new ProjectsOverviewPage(Driver);
    }

    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Name
    /// </summary>
    //public ProjectsAdminPage ManageProjectsButtonClick()
    //{
    //    projectsOverviewPage.ManageProjectsButtonLink.Click();

    //    return new ProjectsAdminPage(Driver);
    //}

    /// <summary>
    /// на странице AddProjectPage заполняем поле для ввода Name
    /// </summary>
    public ProjectsAdminPage DeleteProject()
    {
        projectsAdminPage.DeleteButton
            .Click();
        projectsAdminPage.CheckboxDelete
            .Click();
        projectsAdminPage.DeleteProjectButton
            .Click();
        return projectsAdminPage;
    }
    public RepositoryPage ToRepositoryPage()
    {
        projectsOverviewPage.RepositoryButton.Click();

        return new RepositoryPage(Driver);
    }
    public RepositoryPage AddTestCaseButtonClick()
    {
        repositoryPage.AddTestCaseButton.Click();
        return repositoryPage;
    }

    public RepositoryPage UploadFile()
    {
        RepositoryPage repositoryPage = new RepositoryPage(Driver);

        
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
       
        string filePath = Path.Combine(assemblyPath, "Resources", "cat_time.jpg");

        repositoryPage.ChooseFilesFileUpload.SendKeys(filePath);

        // Thread.Sleep(10000);
        if (repositoryPage.ImageUploaded.Displayed)
        { repositoryPage.AddCaseButton.Click(); }
        else throw new Exception("Файл не загружен");
        //Thread.Sleep(10000);
        return repositoryPage;
    }



}



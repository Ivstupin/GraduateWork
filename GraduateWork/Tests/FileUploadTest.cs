using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests;

public class FileUploadTest : BaseTest
{
    [Test]
    [Description("Загрузка файла с ПК")]
    public void _FileUploadTest()
    {
        UserSteps userSteps = new(Driver);
        ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
        Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

        ActionsSteps actionsSteps = new(Driver);
        AddProjectPage addProjectPage = actionsSteps.PlusProjectButtonClick(); //клик по кнопке Project
        Assert.That(addProjectPage.IsPageOpened); //страница addProjectPage открыта

        actionsSteps.InputValuesInNameInputField("Тестовый 2проект");
        actionsSteps.InputValuesInSummaryInputField("Тестовое описание");
       
        ProjectsOverviewPage projectsOverviewPage = actionsSteps.AddProjectButtonClick();
        //Thread.Sleep(10000);
        Assert.That(projectsOverviewPage.IsPageOpened); 
        //NavigationsSteps navigateSteps = new(Driver);
        RepositoryPage repositoryPage = actionsSteps.ToRepositoryPage();
        //Thread.Sleep(10000);
        Assert.That(repositoryPage.IsPageOpened);
        //Thread.Sleep(10000);
       // actionsSteps.UploadFile();
        //Thread.Sleep(10000);
        actionsSteps.AddTestCaseButtonClick();
        actionsSteps.NameInputFieldAddTestCase("TestCase314");
        actionsSteps.UploadFile();
        //Thread.Sleep(10000);
        
    }
}
using GraduateWork.Elements;
using GraduateWork.Pages;
using GraduateWork.Steps;
using OpenQA.Selenium;

namespace GraduateWork.Tests.UI_Tests;
public class FileUploadTest : BaseUITest
{
    [Test]
    [Category("Regression")]
    [Description("Загрузка файла")]
    //[Ignore("Ignore this Test")]
    public void _FileUploadTest()
    {// должен быть создан любой проект
        UserSteps userSteps = new(Driver);
        //IWebDriver webDriver = new(Driver);
       
        ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
        Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

        ActionsSteps actionsSteps = new(Driver);
        ProjectsOverviewPage projectsOverviewPage = actionsSteps.ProjectLinkClick();
        //Assert.That(projectsOverviewPage.IsPageOpened);
        RepositoryPage repositoryPage = actionsSteps.ToRepositoryPage();
        //Assert.That(repositoryPage.IsPageOpened);

        //UIElement _UIElement = new(repositoryPage.AddTestCaseButton, by:);
        // repositoryPage.IsProjectWasDelete(        //Assert.That(repositoryPage.IsPageOpened);
        //repositoryPage.GetWaitsInvisibleRemovableProjectButton());
        actionsSteps.AddTestCaseButtonClick();
        actionsSteps.NameInputFieldAddTestCase("Upload_Cat");
        actionsSteps.UploadFile();
        Assert.That(repositoryPage.ImageUploaded.Displayed);
    }
}
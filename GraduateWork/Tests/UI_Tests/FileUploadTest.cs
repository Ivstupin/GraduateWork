using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests;

public class FileUploadTest : BaseUITest
{
    [Test]
    [Description("Загрузка файла")]
    [Ignore("Ignore this Test")]
    public void _FileUploadTest()
    {// должен быть создан любой проект
        UserSteps userSteps = new(Driver);
        ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
        Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

        ActionsSteps actionsSteps = new(Driver);
        ProjectsOverviewPage projectsOverviewPage = actionsSteps.ProjectLinkClick();
        Assert.That(projectsOverviewPage.IsPageOpened);
        RepositoryPage repositoryPage = actionsSteps.ToRepositoryPage();
        //Assert.That(repositoryPage.IsPageOpened);
       // repositoryPage.IsProjectWasDelete(        //Assert.That(repositoryPage.IsPageOpened);
        //repositoryPage.GetWaitsInvisibleRemovableProjectButton());
        actionsSteps.AddTestCaseButtonClick();
        actionsSteps.NameInputFieldAddTestCase("Upload_Cat");
        actionsSteps.UploadFile();
        Assert.That(repositoryPage.ImageUploaded.Displayed);
    }
}
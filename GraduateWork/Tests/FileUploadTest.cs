using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests;

public class FileUploadTest : BaseTest
{
    [Test]
    [Description("Загрузка файла")]
    public void _FileUploadTest()
    {
        UserSteps userSteps = new(Driver);
        ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
        Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

        ActionsSteps actionsSteps = new(Driver);
        ProjectsOverviewPage projectsOverviewPage = actionsSteps.ProjectLinkClick();
        Assert.That(projectsOverviewPage.IsPageOpened); 
        RepositoryPage repositoryPage = actionsSteps.ToRepositoryPage();
        Assert.That(repositoryPage.IsPageOpened);
        
        actionsSteps.AddTestCaseButtonClick();
        actionsSteps.NameInputFieldAddTestCase("TestC2ase3824"); //нужна реализация подбора уникальных значений, иначе не подгружает
        actionsSteps.UploadFile();
        Assert.That(repositoryPage.ImageUploaded.Displayed);
    }
}
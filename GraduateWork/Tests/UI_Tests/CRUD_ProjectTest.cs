using Allure.NUnit.Attributes;
using Bogus.DataSets;
using GraduateWork.Models;
using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests
{
    public class CRUD_ProjectTest : BaseUITest
    {
        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [Order(2)]
        //[Ignore("Ignore this Test")]
        //[Repeat(4)]
        public void CreateProject_CRUD_ProjectTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.NavigateToProjectsPage()._PlusProjectButton.Click();
            _navigationSteps.NavigateAddProjectPage().NameInputField.SendKeys("Автопродажа");
            _navigationSteps.NavigateAddProjectPage().SummaryInputField.SendKeys("Автопродажа");
            _navigationSteps.NavigateAddProjectPage()._AddProjectButton.Click();
            _navigationSteps.NavigateProjectsOverviewPage().ManageProjectsButtonLink.Click();
            Assert.That(_navigationSteps.NavigateProjectsAdminPage()._PlusProjectButton.Displayed);
            }

        [Test]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [Order(1)]
        //[Ignore("Ignore this Test")]
        //[Repeat(7)]
        public void DeleteProject_CRUD_ProjectTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.NavigateToProjectsPage().Project.Click();
            _navigationSteps.NavigateProjectsOverviewPage().ManageProjectsButtonLink.Click();
            _navigationSteps.NavigateProjectsAdminPage().DeleteButton.Click();
            _navigationSteps.NavigateProjectsAdminPage().CheckboxDelete.Click();
            _navigationSteps.NavigateProjectsAdminPage().DeleteProjectButton.Click();
            Assert.Multiple(() =>
            {
                Assert.That(_navigationSteps.NavigateProjectsAdminPage().RemovableProjectButton.Displayed);
                Assert.That(_navigationSteps.NavigateProjectsAdminPage().IsProjectWasDelete());
            });
        }

        [Test]
        [Category("Regression")]
        [Description("Загрузка файла")]
        [Order(3)]
        ////[Ignore("Ignore this Test")]
        public void _FileUploadTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.NavigateToProjectsPage()._PlusProjectButton.Click();
            _navigationSteps.NavigateAddProjectPage().NameInputField.SendKeys("UploadFile");
            _navigationSteps.NavigateAddProjectPage().SummaryInputField.SendKeys("UploadFile");
            _navigationSteps.NavigateAddProjectPage()._AddProjectButton.Click();
            _navigationSteps.NavigateProjectsOverviewPage().RepositoryButton.Click();
            _navigationSteps.NavigateRepositoryPage().AddTestCaseButton.Click();
            _navigationSteps.NameInputFieldAddTestCase("tost");
            _navigationSteps.NavigateRepositoryPage().UploadFile();
            _navigationSteps.NavigateRepositoryPage().TestCaseLink.Click();
            Assert.That(_navigationSteps.NavigateRepositoryPage().ImageUploaded.Displayed);
            _navigationSteps.NavigateToProjectsPage().Project.Click();
            _navigationSteps.NavigateProjectsOverviewPage().ManageProjectsButtonLink.Click();
            _navigationSteps.NavigateProjectsAdminPage().DeleteButton.Click();
            _navigationSteps.NavigateProjectsAdminPage().CheckboxDelete.Click();
            _navigationSteps.NavigateProjectsAdminPage().DeleteProjectButton.Click();
            Assert.That(_navigationSteps.NavigateProjectsAdminPage().IsProjectWasDelete());
        }
    }
}

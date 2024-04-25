using Allure.NUnit.Attributes;
using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests
{
    [AllureSuite("UI DialogueWindow Test")]
    public class DialogueWindowTest : BaseUITest
    {
        [Test]
        [Category("Smoke")]
        [Category("Regression")]
        public void _DialogueWindowTest()
        {
            _navigationSteps
                .SuccessfulLogin(Admin);
            _navigationSteps
                .NavigateToProjectsPage()
                ._PlusProjectButton.Click();

            Assert.That(_navigationSteps
                .NavigateAddProjectPage()
                .DialogueWindowIsDisplayed); 
            
        }
    }
}

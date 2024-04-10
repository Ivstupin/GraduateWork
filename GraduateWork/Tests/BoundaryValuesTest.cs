using GraduateWork.Tests;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests
{
    public class BoundaryValuesTest : BaseTest
    {
        [Test]
        public void BoundaryValues()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User();
            
            Assert.That(projectsPage.IsPageOpened);
            Assert.That(projectsPage.IsPopupVisible);
           
            ActionsSteps actionsSteps = new(Driver);
            AddProjectPage addProjectPage = actionsSteps.AddProjectButtonClick();
            
            Assert.That(addProjectPage.IsPageOpened);
            
            actionsSteps.PositiveBoundaryValues40();
            //actionsSteps.NegativeBoundaryValues();
            Assert.That(addProjectPage.CounterValue("40/80"));
            Thread.Sleep(5000);
        }
    }
}

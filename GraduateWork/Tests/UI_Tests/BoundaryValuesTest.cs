using GraduateWork.Models;
using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests
{
    
    public class BoundaryValuesTest : BaseUITest
    {
        readonly BoundaryValues boundaryValues = new BoundaryValues();

        [Test]
        [Category("Regression")]
        public void PositiveBoundaryValuesTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.NavigateToProjectsPage()._PlusProjectButton.Click();

            _navigationSteps.InputValuesInSummaryInputField(boundaryValues.Bvalues40);
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("40/80"));

            _navigationSteps.InputValuesInSummaryInputField(""); //0
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("0/80"));

            _navigationSteps.InputValuesInSummaryInputField("1"); //1
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("1/80"));

            _navigationSteps.InputValuesInSummaryInputField(boundaryValues.Bvalues80); //80
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("80/80"));

            _navigationSteps.InputValuesInSummaryInputField(boundaryValues.Bvalues79); //79
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("79/80"));
        }

        [Test]
        [Category("Regression")]
        public void NegativeBoundaryValuesTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.NavigateToProjectsPage()._PlusProjectButton.Click();

            _navigationSteps.InputValuesInSummaryInputField(boundaryValues.Bvalues81); //81
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("80/80"));

            _navigationSteps.InputValuesInSummaryInputField(boundaryValues.Bvalues162); //162
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("80/80"));

            _navigationSteps.InputValuesInSummaryInputField(boundaryValues.BvaluesBig); //много
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("80/80"));
        }
    }
}
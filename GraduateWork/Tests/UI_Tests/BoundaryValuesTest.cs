using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests
{
    public class BoundaryValuesTest : BaseUITest
    {
        [Test]
        [Category("Regression")]
        public void PositiveBoundaryValuesTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.NavigateToProjectsPage()._PlusProjectButton.Click();

            _navigationSteps.InputValuesInSummaryInputField("dfhfdgdh6re5rujfthfjftghdb56u56....сорок");
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("40/80"));

            _navigationSteps.InputValuesInSummaryInputField(""); //0
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("0/80"));

            _navigationSteps.InputValuesInSummaryInputField("1"); //1
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("1/80"));

            _navigationSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj7gj5i67u75uu67uj666666666jtgygygjc63...........восемь_десят"); //80
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("80/80"));

            _navigationSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj7gj5i67u75uu67uj666666666jtgygygjc63......семьдесят_девять"); //79
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("79/80"));
        }

        [Test]
        [Category("Regression")]
        public void NegativeBoundaryValuesTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.NavigateToProjectsPage()._PlusProjectButton.Click();

            _navigationSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди11"); //81
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("80/80"));

            _navigationSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди31asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_один2"); //162
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("80/80"));

            _navigationSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди31asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj..........." +
                "восемь_десят_один2asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди31asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_один2" +
                "asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди31asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_один2"); //много
            Assert.That(_navigationSteps.NavigateAddProjectPage().CounterValue("80/80"));
        }
    }
}
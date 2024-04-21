using GraduateWork.Pages;
using GraduateWork.Steps;

namespace GraduateWork.Tests.UI_Tests
{
    public class BoundaryValuesTest : BaseUITest
    {
        [Test]
        public void PositiveBoundaryValuesTest()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
            Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

            ActionsSteps actionsSteps = new(Driver);
            AddProjectPage addProjectPage = actionsSteps.PlusProjectButtonClick(); //клик по кнопке Project
            Assert.That(addProjectPage.IsPageOpened); //страница addProjectPage открыта

            // блок с проверкой ГЗ
            actionsSteps.InputValuesInSummaryInputField("dfhfdgdh6re5rujfthfjftghdb56u56....сорок"); //ввод 40 значений - середина диапазона 0-80
            Assert.That(addProjectPage.CounterValue("40/80")); // проверяем что совпадает счётчик введённых символов  

            actionsSteps.InputValuesInSummaryInputField(""); //0
            Assert.That(addProjectPage.CounterValue("0/80"));

            actionsSteps.InputValuesInSummaryInputField("1"); //1
            Assert.That(addProjectPage.CounterValue("1/80"));

            actionsSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj7gj5i67u75uu67uj666666666jtgygygjc63...........восемь_десят"); //80
            Assert.That(addProjectPage.CounterValue("80/80"));

            actionsSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj7gj5i67u75uu67uj666666666jtgygygjc63......семьдесят_девять"); //79
            Assert.That(addProjectPage.CounterValue("79/80"));
        }

        [Test]
        public void NegativeBoundaryValuesTest()
        {
            UserSteps userSteps = new(Driver);
            ProjectsPage projectsPage = userSteps.LoginByCorrect_User(); //логин
            Assert.That(projectsPage.IsPageOpened); //страница projectsPage открыта

            ActionsSteps actionsSteps = new(Driver);
            AddProjectPage addProjectPage = actionsSteps.PlusProjectButtonClick(); //клик по кнопке Project
            Assert.That(addProjectPage.IsPageOpened); //страница addProjectPage открыта

            // блок с проверкой ГЗ
            actionsSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди11"); //81
            Assert.That(addProjectPage.CounterValue("80/80"));

            actionsSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди31asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_один2"); //162
            Assert.That(addProjectPage.CounterValue("80/80"));

            actionsSteps.InputValuesInSummaryInputField("asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди31asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj..........." +
                "восемь_десят_один2asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди31asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_один2" +
                "asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди31asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_один2"); //много
            Assert.That(addProjectPage.CounterValue("80/80"));
        }
    }
}

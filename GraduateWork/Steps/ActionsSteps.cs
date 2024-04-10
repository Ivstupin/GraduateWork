using GraduateWork.Pages;
using GraduateWork.Steps;
using OpenQA.Selenium;
using GraduateWork.Pages;

namespace GraduateWork.Steps;

public class ActionsSteps : BaseSteps
{
    public AddProjectPage addProjectPage;
    public ProjectsPage projectsPage;
   // public CartPage cartPage;

    public ActionsSteps(IWebDriver driver) : base(driver)
    {
        addProjectPage = new AddProjectPage(Driver);
        projectsPage = new ProjectsPage(Driver);
        //cartPage = new CartPage(Driver);
    }
    /// <summary>
    /// со страницы ProjectsPage вызываем страницу AddProjectPage кликом по кнопке Project
    /// </summary>
    public AddProjectPage AddProjectButtonClick() 
    {
        projectsPage._AddProjectButton.Click();
        return addProjectPage;
    }

    /// <summary>
    /// со страницы ProjectsPage вызываем страницу AddProjectPage кликом по кнопке Project
    /// </summary>
    public AddProjectPage PositiveBoundaryValues40()
    {
        addProjectPage.SummaryInputField.Click();
        addProjectPage.SummaryInputField.Clear();
        addProjectPage.SummaryInputField.SendKeys("dfhfdgdh6re5rujfthfjftghdb56u56....сорок"); //40
        //Assert.That(addProjectPage.IsCounter("40/80"));
        //Thread.Sleep(5000);

       // addProjectPage.SummaryInputField.Clear();
       // addProjectPage.SummaryInputField.SendKeys("");//0
       // //Thread.Sleep(5000);
       // addProjectPage.SummaryInputField.SendKeys("1");//1
       //// Thread.Sleep(5000);
       // addProjectPage.SummaryInputField.Clear();
       // addProjectPage.SummaryInputField.SendKeys("asfgdfh6u5yyfhgjg6gkj7gj5i67u75uu67uj666666666jtgygygjc63...........восемь_десят"); //80
       // //Thread.Sleep(5000);
       // addProjectPage.SummaryInputField.Clear();
       // addProjectPage.SummaryInputField.SendKeys("asfgdfh6u5yyfhgjg6gkj7gj5i67u75uu67uj666666666jtgygygjc63......семьдесят_девять"); //79
       //// Thread.Sleep(5000);
       //// addProjectPage.SummaryInputField.Clear();
        return addProjectPage;
    }

    public AddProjectPage NegativeBoundaryValues()
    {
        addProjectPage.SummaryInputField.Click();
        addProjectPage.SummaryInputField.SendKeys("asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди11"); //81
        addProjectPage.SummaryInputField.Clear();
       // Thread.Sleep(5000);
        addProjectPage.SummaryInputField.SendKeys("asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_оди31asfgdfh6u5yyfhgjg6gkj73457u75uu67uj666666666jtgygygj...........восемь_десят_один2"); //162
       // Thread.Sleep(5000);
        addProjectPage.SummaryInputField.Clear();
        return addProjectPage;
    }
}



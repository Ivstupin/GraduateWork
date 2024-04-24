using GraduateWork.Helpers;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class ProjectsOverviewPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private static string END_POINT = "";

        // Описание элементов

       private static readonly By ManageProjectsButtonLinkBy = By.CssSelector("[href='https://ivst.testmo.net/admin/projects']"); //поле ввода Summary
       private static readonly By RepositoryButtonBy = By.CssSelector("[href*='https://ivst.testmo.net/repositories/']"); //счётчик введённых символов в поле Summary
                                                                                                                         
        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        protected override bool EvaluateLoadedStatus()
        {
            Console.WriteLine(ManageProjectsButtonLink.Text.Trim());
            return ManageProjectsButtonLink.Text.Trim().Equals("Manage projects");
        }

        // Атомарные Методы
        public IWebElement ManageProjectsButtonLink => WaitsHelper.WaitForExists(ManageProjectsButtonLinkBy); // название страницы Projects 
        public IWebElement RepositoryButton => WaitsHelper.FluentWaitForElement(RepositoryButtonBy);  //всплывающее окно
       
    }
}
using GraduateWork.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Data;

namespace GraduateWork.Pages
{
    public class ProjectsAdminPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private static string END_POINT = "/admin/projects";

        // Описание элементов
        private static readonly By _PlusProjectButtonBy = By.XPath("//button[contains(text(),'Project')]"); //селектор кнопки добавить проект
        private static readonly By DeleteButtonBy = By.CssSelector("[data-action='delete']"); 
        private static readonly By CheckboxDeleteBy = By.CssSelector("[data-target='confirmationLabel']"); 
        private static readonly By DeleteProjectButtonBy = By.CssSelector("[data-target='deleteButton']"); 
        private static readonly By RemovableProjectButtonBy = By.CssSelector("[class='deleted-entity']"); //селектор удаляемой сущности проекта (после удаления проекта)
        private static readonly By RemovableProjectButtonBy90 = By.XPath("//*[contains(text(),'5')]");
        //private static readonly By RemovableProjectButtonBy91 = By.Val("//*[contains(text(),'5')]");

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        protected override bool EvaluateLoadedStatus()
        {
            Console.WriteLine(_PlusProjectButton.Text.Trim());
            return _PlusProjectButton.Text.Trim().Equals("Project");
        }

        // Атомарные Методы
        public IWebElement _PlusProjectButton => WaitsHelper.WaitForExists(_PlusProjectButtonBy); // 
        public IWebElement DeleteButton => WaitsHelper.WaitForExists(DeleteButtonBy);
        public IWebElement CheckboxDelete => WaitsHelper.WaitForExists(CheckboxDeleteBy);//
        public IWebElement DeleteProjectButton => WaitsHelper.WaitForExists(DeleteProjectButtonBy);//
        public IWebElement RemovableProjectButton => WaitsHelper.WaitForExists(RemovableProjectButtonBy);
        public IWebElement RemovableProjectButton90 => WaitsHelper.WaitForExists(RemovableProjectButtonBy90);
        public bool WaitsInvisibleRemovableProjectButton => WaitsHelper.WaitForElementInvisible(RemovableProjectButton); // 
                                                                                                                      
        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public bool IsProjectWasDelete()
        {
            try
            {
                while (RemovableProjectButton.Displayed)
                {
                    RefreshPage();
                }
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Проект удалён");
                return true;
            }
        }

       
    }
}
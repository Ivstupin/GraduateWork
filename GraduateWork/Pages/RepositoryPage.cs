using GraduateWork.Helpers;
using OpenQA.Selenium;
using System.Reflection;

namespace GraduateWork.Pages
{
    public class RepositoryPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов

       private static readonly By PlusCaseButtonBy = By.XPath("//*[contains(text(),'Case')]"); //поле ввода Summary
       private static readonly By ChooseFilesFileUploadBy = By.CssSelector("[type = 'file']"); //счётчик введённых символов в поле Summary
       private static readonly By AddCaseButtonBy = By.CssSelector("[data-target='submitButton']"); //
       private static readonly By NameInputFieldBy = By.CssSelector("[placeholder='Case name']"); // поле Name при создании тест кейса
       private static readonly By ImageUploadedBy = By.XPath("//*[contains(text(),'cat_time')]"); // 
        public RepositoryPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
            
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            Console.WriteLine(AddTestCaseButton.Text.Trim());
            return AddTestCaseButton.Text.Trim().Equals("Case");
        }
        


        // Атомарные Методы
        public IWebElement AddTestCaseButton => WaitsHelper.FluentWaitForElement(PlusCaseButtonBy); // 
        public IWebElement ChooseFilesFileUpload => WaitsHelper.WaitForExists(ChooseFilesFileUploadBy);  
        public IWebElement AddCaseButton => WaitsHelper.WaitForExists(AddCaseButtonBy);//
        public IWebElement NameInputField => WaitsHelper.WaitForExists(NameInputFieldBy);//
        public IWebElement ImageUploaded => WaitsHelper.WaitForExists(ImageUploadedBy); //  



        // public IWebElement RemovableProjectButton => WaitsHelper.WaitForExists(RemovableProjectButtonBy);
        public IWebElement WaitsInvisibleRemovableProjectButton => WaitsHelper.WaitForVisibilityLocatedBy(PlusCaseButtonBy); // 

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public IWebElement GetWaitsInvisibleRemovableProjectButton()
        {
            return WaitsInvisibleRemovableProjectButton;
        }

        public bool IsProjectWasDelete(IWebElement waitsInvisibleRemovableProjectButton)
        {
            
            try
            {
                while (waitsInvisibleRemovableProjectButton.Displayed)
                {
                    RefreshPage();
                }
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                RefreshPage();
                Console.WriteLine("Проект удалён");
                return true;
            }
        }

    }
}
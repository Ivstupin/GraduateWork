using GraduateWork.Elements;
using GraduateWork.Helpers;
using OpenQA.Selenium;
using System.Reflection;

namespace GraduateWork.Pages
{
    public class RepositoryPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private static string END_POINT = "";

        // Описание элементов

        // private static readonly By PlusCaseButtonBy = By.XPath("//*[contains(text(),'Case')]"); //поле ввода Summary
        private static readonly By PlusCaseButtonBy = By.CssSelector("[data-target='repositories--index.nodataAddCaseButton']");
        private static readonly By ChooseFilesFileUploadBy = By.CssSelector("[type = 'file']"); //счётчик введённых символов в поле Summary
        private static readonly By AddCaseButtonBy = By.CssSelector("[data-target='submitButton']"); //
        private static readonly By NameInputFieldBy = By.CssSelector("[placeholder='Case name']"); // поле Name при создании тест кейса
        private static readonly By ImageUploadedBy = By.XPath("//*[contains(text(),'cat_time')]"); // 
        private static readonly By TestCaseLinkBy = By.CssSelector("[data-action='activate']");

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        protected override bool EvaluateLoadedStatus()
        {
            Console.WriteLine(AddTestCaseButton.Text.Trim());
            return AddTestCaseButton.Text.Trim().Equals("Case");
        }

        // Атомарные Методы
        public IWebElement AddTestCaseButton => WaitsHelper.FluentWaitForElement(PlusCaseButtonBy); // 
        public IWebElement ChooseFilesFileUpload => WaitsHelper.WaitForExists(ChooseFilesFileUploadBy);
        public IWebElement AddCaseButton => WaitsHelper.WaitForExists(AddCaseButtonBy);//
        public IWebElement NameInputField => WaitsHelper.WaitForExists(NameInputFieldBy);//
        public IWebElement ImageUploaded => WaitsHelper.FluentWaitForElement(ImageUploadedBy); //  
        public IWebElement TestCaseLink => WaitsHelper.WaitForExists(TestCaseLinkBy); //  

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

        public void UploadFile()
        {
            RepositoryPage repositoryPage = new RepositoryPage(Driver);

            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string filePath = Path.Combine(assemblyPath, "Resources", "cat_time.jpg");

            repositoryPage.ChooseFilesFileUpload.SendKeys(filePath);

            if (repositoryPage.ImageUploaded.Displayed)
            {
                repositoryPage.AddCaseButton.Click();
            }
            else throw new Exception("Файл не загружен");

            //return repositoryPage;


        }
        public RepositoryPage NameInputFieldAddTestCase(string values)
        {
            RepositoryPage repositoryPage = new RepositoryPage(Driver);
            repositoryPage.NameInputField.Click();
            repositoryPage.NameInputField.Clear();
            repositoryPage.NameInputField.SendKeys(values);
            return repositoryPage;
        }

    }

    
}
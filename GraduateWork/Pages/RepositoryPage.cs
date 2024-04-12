using GraduateWork.Helpers;
using OpenQA.Selenium;
using System.Reflection;

namespace GraduateWork.Pages
{
    public class RepositoryPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов

       private static readonly By AddTestCaseButtonBy = By.CssSelector("[data-target='repositories--index.nodataAddCaseButton']"); //поле ввода Summary
       private static readonly By ChooseFilesFileUploadBy = By.CssSelector("[type = 'file']"); //счётчик введённых символов в поле Summary
       private static readonly By AddCaseButtonBy = By.CssSelector("[data-target='submitButton']"); // селектор ссылки на страницу с тележкой 
       private static readonly By NameInputFieldBy = By.CssSelector("[placeholder='Case name']"); //бэйдж с количеством товаров в тележке
       private static readonly By ImageUploadedBy = By.XPath("//*[contains(text(),'cat_time')]"); // dropdown Name (A to Z)
                                                                                            //private static readonly By NameProductsTitleBy = By.CssSelector("[class~='inventory_item_name']"); //селектор имени товара со ссылкой на страницу его описания

        //public ThreeStripesMenuPage ThreeStripesMenuPage;
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
            return AddTestCaseButton.Text.Trim().Equals("Add test case");
        }

        /// <summary>
        /// сравнивает счётчик символов на странице
        /// </summary>
        //public bool CounterValue(string counter)
        //{
        //    Console.WriteLine(Counter.Text.Trim());
        //    return Counter.Text.Trim().Equals(counter);
        //}

        // Атомарные Методы
        public IWebElement AddTestCaseButton => WaitsHelper.WaitForExists(AddTestCaseButtonBy); // название страницы Projects 
        public IWebElement ChooseFilesFileUpload => WaitsHelper.WaitForExists(ChooseFilesFileUploadBy);  //всплывающее окно
        public IWebElement AddCaseButton => WaitsHelper.WaitForExists(AddCaseButtonBy);//
        public IWebElement NameInputField => WaitsHelper.WaitForExists(NameInputFieldBy);//бэйдж с количеством товаров в тележке
       public IWebElement ImageUploaded => WaitsHelper.WaitForExists(ImageUploadedBy); //  кнопка со ссылкой на страницу с тележкой 
                                                                                                 // public IWebElement NameProductsTitle => WaitsHelper.WaitForExists(NameProductsTitleBy); // заголовок товара


         //public bool ImageUploadedByIsInvisible => WaitsHelper.WaitForElementInvisible(ImageUploadedBy); //вернёт true если не найдёт selector кнопки Remove

        /// <summary>
        /// вернёт TRUE если на странице ProductsPage не добавлен ни один товар в тележку
        /// </summary>
        //  public bool ProductsNotChoosen()
        // {
        // try
        //  {
        //return WaitForElementInvisibleRemoveButton;
        // }
        // catch (WebDriverTimeoutException)
        //{
        //  return false;
        //}
        //public RepositoryPage UploadFile()
        //{
        //     RepositoryPage repositoryPage = new RepositoryPage(Driver);
             
        //  // repositoryPage.ChooseFilesButton.Click();

        //    //var fileUpload = WaitsHelper.WaitForExists(By.CssSelector("[type = 'file']"));
        //    string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    // Конструируем путь к файлу внутри проекта
        //    string filePath = Path.Combine(assemblyPath, "Resources", "cat_time.jpg");

        //    ChooseFilesFileUpload.SendKeys(filePath);
            

        //    AddCaseButton.Submit();
        //    return repositoryPage;
        //}

    }
}
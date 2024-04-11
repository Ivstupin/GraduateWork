using GraduateWork.Helpers;
using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class ProjectsOverviewPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов

       private static readonly By ManageProjectsLinkBy = By.CssSelector("[href='https://ivst.testmo.net/admin/projects']"); //поле ввода Summary
       //private static readonly By CounterBy = By.ClassName("maxlength-counter__counter"); //счётчик введённых символов в поле Summary
     
      // private static readonly By NameInputFieldBy = By.CssSelector("[data-target='name']"); // селектор ссылки на страницу с тележкой 
                                                                                            //private static readonly By ShoppingCartBadgeBy = By.CssSelector("[class='shopping_cart_badge']"); //бэйдж с количеством товаров в тележке
                                                                                            // private static readonly By DropdownNameBy = By.CssSelector("[class='product_sort_container']"); // dropdown Name (A to Z)
                                                                                            //private static readonly By NameProductsTitleBy = By.CssSelector("[class~='inventory_item_name']"); //селектор имени товара со ссылкой на страницу его описания

        //public ThreeStripesMenuPage ThreeStripesMenuPage;
        public ProjectsOverviewPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
            
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            Console.WriteLine(ManageProjectsLink.Text.Trim());
            return ManageProjectsLink.Text.Trim().Equals("Manage projects");
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
        public IWebElement ManageProjectsLink => WaitsHelper.WaitForExists(ManageProjectsLinkBy); // название страницы Projects 
        //public IWebElement SummaryInputField => WaitsHelper.WaitForExists(SummaryInputFieldBy);  //всплывающее окно
       // public IWebElement Counter => WaitsHelper.WaitForExists(CounterBy);//
       // public IWebElement NameInputField => WaitsHelper.WaitForExists(NameInputFieldBy);//бэйдж с количеством товаров в тележке
                                                                                                 // public IWebElement ShoppingCartButton => WaitsHelper.WaitForExists(ShoppingCartButtonBy); //  кнопка со ссылкой на страницу с тележкой 
                                                                                                 // public IWebElement NameProductsTitle => WaitsHelper.WaitForExists(NameProductsTitleBy); // заголовок товара


        // public bool WaitForElementInvisibleRemoveButton => WaitsHelper.WaitForElementInvisible(RemoveButtonBy); //вернёт true если не найдёт selector кнопки Remove

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
        

    }
}
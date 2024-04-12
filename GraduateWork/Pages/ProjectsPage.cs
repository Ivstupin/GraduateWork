using GraduateWork.Helpers;
using GraduateWork.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace GraduateWork.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string END_POINT = "";

        // Описание элементов
        private static readonly By DropDownListTourBy = By.XPath("//div[contains(text(),'Testmo trial started')]"); //выпадающий список Tour
        private static readonly By PopupMessageBy = By.CssSelector("[class='avatar__text__identifier']"); //всплывающее сообщение

        private static readonly By TrialBy = By.CssSelector("[class='navbar__trial__button']"); // название страницы Projects 
        private static readonly By TitleLabelBy = By.XPath("//div[contains(text(),'Projects')]"); // название страницы Projects 

        private static readonly By PlusProjectButtonBy = By.XPath("//button[contains(text(),'Project')]"); //селектор кнопки добавить проект
                                                                                                          //private static readonly By RemoveButtonBy = By.XPath("//*[contains(text(),'Remove')]"); //селектор кнопки удалить из тележки
                                                                                                          //private static readonly By ShoppingCartButtonBy = By.CssSelector("[class='shopping_cart_link']"); // селектор ссылки на страницу с тележкой 
                                                                                                          //private static readonly By ShoppingCartBadgeBy = By.CssSelector("[class='shopping_cart_badge']"); //бэйдж с количеством товаров в тележке
                                                                                                          // private static readonly By DropdownNameBy = By.CssSelector("[class='product_sort_container']"); // dropdown Name (A to Z)
                                                                                                          //private static readonly By NameProductsTitleBy = By.CssSelector("[class~='inventory_item_name']"); //селектор имени товара со ссылкой на страницу его описания

        //public ThreeStripesMenuPage ThreeStripesMenuPage;
        public ProjectsPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
            // ThreeStripesMenuPage = new ThreeStripesMenuPage(Driver); //три точки меню слева вверху
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            return TitleLabel.Text.Trim().Equals("Projects");
        }

        public bool IsPopupVisible()
        {
            Console.WriteLine(PopupMessage.Text.Trim());
            // PopupMessage.
            return PopupMessage.Text.Trim().Equals("I");
        }

        // Атомарные Методы
        public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy); // название страницы Projects 
        public IWebElement PopupMessage => WaitsHelper.WaitForExists(PopupMessageBy);  //всплывающее окно
        public IWebElement _PlusProjectButton => WaitsHelper.WaitForExists(PlusProjectButtonBy);// // кнопка добавить проект
                                                                                              // public IWebElement ShoppingCartBadge => WaitsHelper.WaitForExists(ShoppingCartBadgeBy);//бэйдж с количеством товаров в тележке
                                                                                              // public IWebElement ShoppingCartButton => WaitsHelper.WaitForExists(ShoppingCartButtonBy); //  кнопка со ссылкой на страницу с тележкой 
                                                                                              // public IWebElement NameProductsTitle => WaitsHelper.WaitForExists(NameProductsTitleBy); // заголовок товара
                                                                                              //public void GG()
                                                                                              //{
                                                                                              //    var t = PopupMessage;
                                                                                              //    var a = new Actions(Driver);
                                                                                              //    PopupMessage.
                                                                                              //}
                                                                                              //public bool WaitForElementInvisiblePopup => WaitsHelper.WaitForElementInvisible(PopupMessageBy); //вернёт true если не найдёт selector кнопки Remove

        /// <summary>
        /// вернёт TRUE если на странице ProductsPage не добавлен ни один товар в тележку
        /// </summary>
        //public bool IsPopupVisible()
        //{
        //    try
        //    {
        //        Console.WriteLine(PopupMessage.Text.Trim());
        //        return PopupMessage.Text.Trim().Equals("Ivan Stupin");
        //    }
        //    catch (WebDriverTimeoutException)
        //    {
        //        return false;
        //    }

       public void MoveToPopupMessage() 
       {
            var allPopupMessage = WaitsHelper.WaitForAllVisibleElementsLocatedBy(PopupMessageBy); // вернёт коллекцию всех найденых на странице всплывающих сообщений
            var actions = new Actions(Driver);
            
            foreach (var msg in allPopupMessage) //перебор всех всплывающих сообщений
            {
                actions
                    .MoveToElement(msg)
                    .Build()
                    .Perform();
            }
       }
    }
}
using OpenQA.Selenium;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class HomePage : ProjectPageObject
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        //locators
        private readonly ElementLocator _welcomePagePicture = new ElementLocator(Locator.CssSelector, "img[src='/petclinic/resources/images/pets.png']");
        private readonly ElementLocator _welcomeSign = new ElementLocator(Locator.CssSelector, "h2");


        public bool HomePagePicture => Driver.IsElementDisplayed(_welcomePagePicture);

        public string WelcomeSign => Driver.GetText(_welcomeSign);

        public HomePage Open()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }
    }
}
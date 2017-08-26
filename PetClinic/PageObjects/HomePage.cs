﻿using OpenQA.Selenium;
using PetClinic.Extensions;
using PetClinic.Helpers;

namespace PetClinic.PageObjects
{
    public class HomePage : ProjectPageObject
    {
        private readonly IWebDriver _driver;

        //locators
        private readonly ElementLocator _welcomePagePicture = new ElementLocator(Locator.CssSelector, "img[src='/petclinic/resources/images/pets.png']");
        private readonly ElementLocator _welcomeSign = new ElementLocator(Locator.CssSelector, "h2");

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public bool HomePagePicture => this._driver.IsElementDisplayed(_welcomePagePicture);

        public string WelcomeSign => this._driver.GetText(_welcomeSign);

        public HomePage Open()
        {
            this._driver.Navigate().GoToUrl(Url);
            return this;
        }
    }
}
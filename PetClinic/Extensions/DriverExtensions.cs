using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PetClinic.Helpers;

namespace PetClinic.Extensions
{
    public static class DriverExtensions
    {
        private const double Wait = 30;

        public static bool IsElementDisplayed(this IWebDriver driver, ElementLocator locator)
        {
            try
            {
                return new WebDriverWait(driver, TimeSpan.FromSeconds(Wait))
                    .Until(ExpectedConditions.ElementIsVisible(locator.ToBy(locator)))
                    .Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static string GetText(this IWebDriver driver, ElementLocator locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Wait)).Until(
                ExpectedConditions.ElementIsVisible(locator.ToBy(locator))).Text;
        }

        public static IWebElement FindElement(this IWebDriver driver, ElementLocator locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Wait)).Until(
                ExpectedConditions.ElementToBeClickable(driver.FindElement(locator.ToBy(locator))));
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, ElementLocator locator, params object[] parameters)
        {
            locator = locator.Format(parameters);
            new WebDriverWait(driver, TimeSpan.FromSeconds(Wait)).Until(drv => driver.FindElements(locator.ToBy(locator)).Count > 0);
            return driver.FindElements(locator.ToBy(locator));
        }

        public static void SendKeys(this IWebDriver driver, ElementLocator locator, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var el = new WebDriverWait(driver, TimeSpan.FromSeconds(Wait)).Until(
                    ExpectedConditions.ElementToBeClickable(driver.FindElement(locator.ToBy(locator))));
                //ugly hack becaue of unknown error: cannot focus element in chromedriver
                //TODO replace by sendKeys when bug is fixed
                new Actions(driver).MoveToElement(el).Click().SendKeys(text).Build().Perform();
            }
        }

        public static void Click(this IWebDriver driver, ElementLocator locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(Wait)).Until(
                ExpectedConditions.ElementToBeClickable(driver.FindElement(locator.ToBy(locator)))).Click();
        }
    }
}
﻿using System;
using OpenQA.Selenium;
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

        public static void SendKeys(this IWebDriver driver, ElementLocator locator, string text)
        {
            if (!string.IsNullOrEmpty(text))
                new WebDriverWait(driver, TimeSpan.FromSeconds(Wait)).Until(
                    ExpectedConditions.ElementToBeClickable(driver.FindElement(locator.ToBy(locator)))).SendKeys(text);
        }

        public static void Click(this IWebDriver driver, ElementLocator locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(Wait)).Until(
                ExpectedConditions.ElementToBeClickable(driver.FindElement(locator.ToBy(locator)))).Click();
        }
    }
}
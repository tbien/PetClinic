using OpenQA.Selenium;

namespace PetClinic.Helpers
{
    public class ElementLocator
    {
        public ElementLocator(Locator locator, string value)
        {
            Kind = locator;
            Value = value;
        }

        public Locator Kind { get; set; }
        public string Value { get; set; }

        public ElementLocator Format(params object[] parameters)
        {
            return new ElementLocator(Kind, string.Format(Value, parameters));
        }

        public By ToBy(ElementLocator locator)
        {
            By by;
            switch (locator.Kind)
            {
                case Locator.Id:
                    by = By.Id(locator.Value);
                    break;
                case Locator.ClassName:
                    by = By.ClassName(locator.Value);
                    break;
                case Locator.CssSelector:
                    by = By.CssSelector(locator.Value);
                    break;
                case Locator.LinkText:
                    by = By.LinkText(locator.Value);
                    break;
                case Locator.Name:
                    by = By.Name(locator.Value);
                    break;
                case Locator.PartialLinkText:
                    by = By.PartialLinkText(locator.Value);
                    break;
                case Locator.TagName:
                    by = By.TagName(locator.Value);
                    break;
                case Locator.XPath:
                    by = By.XPath(locator.Value);
                    break;
                default:
                    by = By.Id(locator.Value);
                    break;
            }
            return by;
        }
    }

    public enum Locator
    {
        /// <summary>
        ///     The Id selector
        /// </summary>
        Id,

        /// <summary>
        ///     The class name selector
        /// </summary>
        ClassName,

        /// <summary>
        ///     The CSS selector
        /// </summary>
        CssSelector,

        /// <summary>
        ///     The link text selector
        /// </summary>
        LinkText,

        /// <summary>
        ///     The name selector
        /// </summary>
        Name,

        /// <summary>
        ///     The partial link text selector
        /// </summary>
        PartialLinkText,

        /// <summary>
        ///     The tag name selector
        /// </summary>
        TagName,

        /// <summary>
        ///     The XPath selector
        /// </summary>
        XPath
    }
}
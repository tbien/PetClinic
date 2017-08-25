using NUnit.Framework;

namespace PetClinic.Tests.HomePage
{
    public class HomePageTest : ProjectTestBase
    {
        [TestCase("Welcome")]
        public void CheckIfWelcomePageIsDisplayed(string welcomeSign)
        {
            var homePage = new PageObjects.HomePage(Driver)
                .Open();

            Assert.True(homePage.HomePagePicture, "Welome page is not displayed");
            Assert.AreEqual(welcomeSign, homePage.WelcomeSign);
        }
    }
}
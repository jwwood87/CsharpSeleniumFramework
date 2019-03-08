using NUnit.Framework;
using UdemyFramework.Pages;

namespace UdemyFramework.Tests
{

    public class SliderTests : BaseTest
    {
        HomePage homePage;

        [Test]
        [Category("PropertyForPageSection")]
        [Description("This test shows how to break up a large web page using a Property to describe one section")]
        public void TestUsingPropertyForPage()
        {
            homePage = new HomePage(Driver);
            homePage.Goto();
            homePage.Slider.ClickNextButton();
            string imageOne = homePage.Slider.CurrentImage;
            homePage.Slider.ClickNextButton();
            string imageTwo = homePage.Slider.CurrentImage;

            Assert.AreNotEqual(imageOne, imageTwo, "Oops, the image didn't change.");
        }

    }
}

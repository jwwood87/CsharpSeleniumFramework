using NUnit.Framework;
using UdemyFramework.Pages;
using UdemyFramework.Tests;

namespace UdemyFramework
{

    public class ContactUsTests : BaseTest
    {
        ContactUsPage _contactUsPage;
        AutomationPracticePage _automationPracticePage;
        SignInPage _signInPage;
        UltimateComplicatedPage _ultimateComplicatedPage;

        [SetUp]
        public void Setup()
        {
            _contactUsPage = new ContactUsPage(Driver);
            _automationPracticePage = new AutomationPracticePage(Driver);
            _signInPage = new SignInPage(Driver);
            _ultimateComplicatedPage = new UltimateComplicatedPage(Driver);
        }

        [Test]
        [Author("JohnWood")]
        [Category("ContactUs Test")]
        [Description("TC_ID4: This test checks that the Contact Us page loads.")]
        public void OpenAutomationPractice_ClickContactUs_PageOpens()
        {
            _automationPracticePage.Goto();
            _contactUsPage = _automationPracticePage.ClickContactUs();

            Assert.IsTrue(_contactUsPage.IsVisible);
        }

        [Test]
        [Author("JohnWood")]
        [Description("TC_ID5: Verify that the signIn lilnk takes user to the login page.")]
        public void OpenAutomationPractice_ClickSignIn_FillOutForm()
        {
            _automationPracticePage.Goto();
            _signInPage =_automationPracticePage.SignIn();

            Assert.IsTrue(_signInPage.IsVisible);
        }

        [Test]
        [Author("JohnWood")]
        [Description("TC_ID6: Submit form for Section of Random Stuff")]
        public void SectionRandomStuff_SubmitForm_Successful()
        {
            _ultimateComplicatedPage.Goto();
            Assert.IsTrue(_ultimateComplicatedPage.IsVisible);
            _ultimateComplicatedPage.FillOutForm();
            _ultimateComplicatedPage.SubmitForm();

            Assert.IsTrue(_ultimateComplicatedPage.SignInSuccessful());
        }

        [Test]
        [Author("JohnWood")]
        [Description("TC_ID7: Search Complicated Page")]
        public void ComplicatedPage_SearchString_ResultsAreCorrect()
        {
            _ultimateComplicatedPage.Goto();
            _ultimateComplicatedPage.SearchLeftBox();

            Assert.IsTrue(Driver.Title.Contains("You searched for selenium errors"));
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using UdemyFramework.Common;
using UdemyFramework.Pages;
using UdemyFramework.Tests;

namespace UdemyFramework
{

    public class ContactUs : BaseTest
    {
        [Test]
        [Author("JohnWood")]
        [Category("ContactUs Test")]
        [Description("This test checks that the Contact Us page loads.")]
        public void ContactUs1()
        {
            ContactUsPage contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();

            Assert.IsTrue(contactUsPage.PageTitle.Contains("Contact"), "The expected page did not appear.");
        }

        [Test]
        [Author("JohnWood")]
        [Description("Verify that the Contact Us page opens when clicking the Contact Us button.")]
        public void ClickContactUs_PageOpens()
        {

        }

        [Test]
        [Author("JohnWood")]
        [Description("ClickSignIn_PageOpens")]
        public void ClickSignIn_PageOpens()
        {

        }

        [Test]
        [Author("JohnWood")]
        [Description("Submit form for Section of Random Stuff")]
        public void SectionRandomStuff_SubmitForm_Successful()
        {

        }

        [Test]
        [Author("JohnWood")]
        [Description("Search Complicated Page")]
        public void ComplicatedPage_SearchString_ResultsAreCorrect()
        {

        }
    }
}

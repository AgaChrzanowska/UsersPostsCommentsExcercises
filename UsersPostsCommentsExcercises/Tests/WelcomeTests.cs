using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UsersPostsCommentsExcercises.Pages;

namespace UsersPostsCommentsExcercises.Tests
{
    [TestClass]
    public class WelcomeTests: BaseTests
    {
        WelcomePageObject _welcomePageObject;

        [TestInitialize]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            _welcomePageObject = new WelcomePageObject(Driver);
            string url = "http://localhost:4200/home";
            Driver.Navigate().GoToUrl(url);
        }

      

        [TestMethod]
        public void Check_H1_Text()
        {
            try
            {
                Assert.AreEqual("Hi there!", _welcomePageObject.H1Welcome.Text);
            }
            catch (AssertFailedException afe)
            {

                FileLogHelper.Save(afe);
            }
        }

        [TestMethod]
        public void Check_Button_SeePosts()
        {
            try
            {
                IWebElement btn = _welcomePageObject.BtnSeePosts;
                Assert.AreEqual("See posts", btn.Text);
            }
            catch (AssertFailedException afe)
            {

                FileLogHelper.Save(afe);
            }
        }

        [TestMethod]
        public void Check_If_Button_Switches_To_Posts()
        {
            PostsPageObject ppo = _welcomePageObject.RedirectToPosts();
            Assert.AreEqual("http://localhost:4200/posts", Driver.Url);
            // Alternative method to get url
            Assert.AreEqual("http://localhost:4200/posts", ppo.GetCurrentUrl());
            Assert.AreEqual("List of posts with authors", ppo.H1Text.Text);
        }
    }
}

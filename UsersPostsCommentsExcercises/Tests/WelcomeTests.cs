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
    public class WelcomeTests
    {
        private IWebDriver _driver;
        WelcomePageObject _welcomePageObject;
        FileLogHelper _fileLogHelper = new FileLogHelper();

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _welcomePageObject = new WelcomePageObject(_driver);
            string url = "http://localhost:4200/home";
            _driver.Navigate().GoToUrl(url);
        }

        [TestMethod]
        public void Check_List_Menu_Count()
        {
            try
            {
                Assert.AreEqual(3, _welcomePageObject.GetListMenuCount());
            }
            catch (AssertFailedException afe)
            {
                _fileLogHelper.Save(afe);
            }
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

                _fileLogHelper.Save(afe);
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

                _fileLogHelper.Save(afe);
            }
        }
        [TestMethod]
        public void Check_If_Button_Switches_To_Posts()
        {
            PostsPageObject ppo = _welcomePageObject.RedirectToPosts();
            Assert.AreEqual("http://localhost:4200/posts", _driver.Url);
            // Alternative method to get url
            Assert.AreEqual("http://localhost:4200/posts", ppo.GetCurrentUrl());
            Assert.AreEqual("List of posts with authors", ppo.H1Text.Text);
        }

        [TestCleanup]
        public void Finish()
        {
            _driver.Dispose();
        }
    }
}

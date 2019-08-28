using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UsersPostsCommentsExcercises.Pages;

namespace UsersPostsCommentsExcercises.Tests
{
    [TestClass]
    public class AboutTests
    {
        private IWebDriver _driver;
        AboutPageObject _aboutPageObject;
        FileLogHelper _fileLogHelper = new FileLogHelper();

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _aboutPageObject = new AboutPageObject(_driver);
            string url = "http://localhost:4200/about";
            _driver.Navigate().GoToUrl(url);
        }

        [TestMethod]
        public void Check_H1_Text()
        {
            try
            {
                Assert.AreEqual("About author", _aboutPageObject.H1.Text);
            }
            catch (AssertFailedException afe)
            {
                _fileLogHelper.Save(afe);
            }
        }
        [TestMethod]
        public void Check_Info_About_Author()
        {
            try
            {
                Assert.IsNotNull(_aboutPageObject.About);
            }
            catch (AssertFailedException afe)
            {
                _fileLogHelper.Save(afe);
            }
        }

        [TestCleanup]
        public void Finish()
        {
            _driver.Dispose();
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UsersPostsCommentsExcercises.Pages;

namespace UsersPostsCommentsExcercises.Tests
{
    [TestClass]
    public class AboutTests: BaseTests
    {
        AboutPageObject _aboutPageObject;

        [TestInitialize]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            _aboutPageObject = new AboutPageObject(Driver);
            string url = "http://localhost:4200/about";
            Driver.Navigate().GoToUrl(url);
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
               FileLogHelper.Save(afe);
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
                FileLogHelper.Save(afe);
            }
        }
    }
}

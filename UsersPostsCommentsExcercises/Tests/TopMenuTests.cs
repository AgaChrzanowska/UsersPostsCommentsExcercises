using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UsersPostsCommentsExcercises.Pages;

namespace UsersPostsCommentsExcercises.Tests
{
    [TestClass]
    public class TopMenuTests: BaseTests

    {
        TopMenuPageObject _topMenuPageObject;

        [TestInitialize]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            _topMenuPageObject = new TopMenuPageObject(Driver);
        }

        [TestMethod]
        public void Check_List_Menu_Count()
        {
            try
            {
                string url = "http://localhost:4200/home";
                Driver.Navigate().GoToUrl(url);
                Assert.AreEqual(3, _topMenuPageObject.GetListMenuCount());
            }
            catch (AssertFailedException afe)
            {
                FileLogHelper.Save(afe);
            }
        }

        
    }
}

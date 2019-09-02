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
        public void Go_To_About_From_Home()
        {
            try
            {
                Driver.Navigate().GoToUrl("http://localhost:4200/home");
                AboutPageObject about = _topMenuPageObject.RedirectToAbout();
                Assert.AreEqual("http://localhost:4200/about", Driver.Url);
            }
            catch (AssertFailedException afe)
            {
                FileLogHelper.Save(afe);
            }
        }

        [TestMethod]
        public void Go_To_Posts_From_Home()
        {
            try
            {
                Driver.Navigate().GoToUrl("http://localhost:4200/home");
                PostsPageObject posts = _topMenuPageObject.RedirectToPosts();
                Assert.AreEqual("http://localhost:4200/posts", Driver.Url);
            }
            catch (AssertFailedException afe)
            {
                FileLogHelper.Save(afe);
            }
        }
        [TestMethod]
        public void Go_To_About_From_Posts()
        {
            try
            {
                Driver.Navigate().GoToUrl("http://localhost:4200/posts");
                AboutPageObject about = _topMenuPageObject.RedirectToAbout();
                Assert.AreEqual("http://localhost:4200/about", Driver.Url);
            }
            catch (AssertFailedException afe)
            {
                FileLogHelper.Save(afe);
            }
        }
        public void Go_To_Posts_From_Home_And_Check_H1_Text()
        {
            try
            {
                Driver.Navigate().GoToUrl("http://localhost:4200/home");
                PostsPageObject posts = _topMenuPageObject.RedirectToPosts();
                Assert.AreEqual("List of posts with authors", posts.H1Text.Text);
            }
            catch (AssertFailedException afe)
            {
                FileLogHelper.Save(afe);
            }
        }
        public void Go_To_About_From_Posts_And_Check_H1_Text()
        {
            try
            {
                Driver.Navigate().GoToUrl("http://localhost:4200/posts");
                AboutPageObject about = _topMenuPageObject.RedirectToAbout();
                Assert.AreEqual("About author", Driver.Url);
            }
            catch (AssertFailedException afe)
            {
                FileLogHelper.Save(afe);
            }
        }

        [TestMethod]
        public void Go_To_Welcome_From_Posts()
        {
            try
            {
                Driver.Navigate().GoToUrl("http://localhost:4200/posts");
                WelcomePageObject welcome = _topMenuPageObject.RedirectToHome();
                Assert.AreEqual("http://localhost:4200/home", Driver.Url);
            }
            catch (AssertFailedException afe)
            {
                FileLogHelper.Save(afe);
            }
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

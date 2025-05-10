using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Security.Cryptography.X509Certificates;

namespace HostOperator.Tests
{
    public class HostOperatorAboutTests : IDisposable
    {
        private IWebDriver driver;

        public void Dispose()
        {
           // driver.Dispose();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
              // driver.Quit();
            }
        }


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Login");

            // this for skip login page
            var usernameField = driver.FindElement(By.Name("usernameOrEmailAddress"));
            var passwordField = driver.FindElement(By.Name("Password"));
            var signInButton = driver.FindElement(By.Id("LoginButton"));
            usernameField.SendKeys("Host_operator");
            passwordField.SendKeys("NpSCiS5X");
            signInButton.Click();

            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Dashboard");
        }

        [Test]
        public void AboutPage_AboutOptionTest()
        {
            var aboutOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[2]/a"));

            Assert.IsTrue(aboutOption.Enabled);
            Assert.IsTrue(aboutOption.Displayed);
            Assert.AreEqual(aboutOption.Text,"About");
            Assert.AreEqual(aboutOption.GetAttribute("target"),"_self");
            Assert.AreEqual(aboutOption.GetAttribute("custom-data"),"About");
            Assert.AreEqual(aboutOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(aboutOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/About");

            var aboutOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[2]/a/i"));
            Assert.IsTrue(aboutOptionIcon.Enabled);
            Assert.IsTrue(aboutOptionIcon.Displayed);
            Assert.AreEqual(aboutOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-interface-10");

            var aboutOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[2]/a/span/span"));
            Assert.IsTrue(aboutOptionText.Enabled);
            Assert.IsTrue(aboutOptionText.Displayed);
            Assert.AreEqual(aboutOptionText.Text,"About");
            Assert.AreEqual(aboutOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void AboutPage_OpenPage()
        {
            var aboutOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[2]/a/span"));
            aboutOption.Click();
        }

        [Test]
        public void AboutPage_TopUserNameTest()
        {
            // to open About page
            AboutPage_OpenPage();

            var HiUserName = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            Assert.IsTrue(HiUserName.Enabled);
            Assert.IsTrue(HiUserName.Displayed);
            Assert.AreEqual(HiUserName.Text, "HI,");
            Assert.AreEqual(HiUserName.GetAttribute("class"), "m-topbar__username");

            var username = driver.FindElement(By.Id("UserName"));
            Assert.True(username.Enabled);
            Assert.True(username.Displayed);
            Assert.AreEqual(username.GetAttribute("style"), "cursor: pointer; margin-bottom: -1.5rem;");
        }

        [Test]
        public void AboutPage_LogoutBtn()
        {
            // to open about page
            AboutPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            hiHostOperator.Click();

            Thread.Sleep(4000);
            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("class"), "btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder");
        }

        [Test]
        public void AboutPage_NotificationIconTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var notificationBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationBtn.Enabled);
            Assert.IsTrue(notificationBtn.Displayed);
            Assert.AreEqual(notificationBtn.GetAttribute("class"), "m-nav__link m-dropdown__toggle");
            Assert.AreEqual(notificationBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a/span[1]/i"));
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.AreEqual(notificationIcon.GetAttribute("class"), "flaticon-bell");

            var unReadMessage = driver.FindElement(By.Id("UnreadChatMessageCount"));
            Assert.IsTrue(unReadMessage.Enabled);
            Assert.IsTrue(unReadMessage.Displayed);
            Assert.AreEqual(unReadMessage.GetAttribute("class"), "m-badge m-badge--danger");
        }

        [Test]
        public void AboutPage_SubHeaderTitleTest()
        {
            // to open about page
            AboutPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "About");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void AboutPage_DashbaordNavigationLinkTest()
        {
            // to open about Page
            AboutPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            
            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text,"Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(dashboardNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Dashboard");
        }

        [Test]
        public void AboutPage_AboutNavigationLinkTest()
        {
            // to open about Page
            AboutPage_OpenPage();

            var aboutNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));

            Assert.IsTrue(aboutNavLink.Enabled);
            Assert.IsTrue(aboutNavLink.Displayed);
            Assert.AreEqual(aboutNavLink.Text,"About");
            Assert.AreEqual(aboutNavLink.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void AboutPagePageTextTest()
        {
            // to open about Page
            AboutPage_OpenPage();

            var pageTextSection = driver.FindElement(By.ClassName("m-portlet__body"));
            Assert.IsNotNull(pageTextSection);
            Assert.IsTrue(pageTextSection.Enabled);
            Assert.IsTrue(pageTextSection.Displayed);

            var aboutPageText = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/p[1]"));
            Assert.IsTrue(aboutPageText.Enabled);
            Assert.IsTrue(aboutPageText.Displayed);
            Assert.AreEqual(aboutPageText.Text, "The Transit Asset Management Database is a relational database that integrates the asset inventory and condition data used to develop Connecticut DOT’s Transit Asset Management Plan (TAMP), as well as the Group TAMP for Tier II providers in Connecticut. Using a web-based user interface, agencies can enter data with review and approval by CTDOT.");

            var purposeMessage = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/p[2]"));
            Assert.IsTrue(purposeMessage.Enabled);
            Assert.IsTrue(purposeMessage.Displayed);
            Assert.AreEqual(purposeMessage.Text, "The purpose of the system is threefold:");

            var purposeItemMessage = driver.FindElements(By.ClassName("about"));
            foreach(var item in purposeItemMessage)
            {
                Assert.IsTrue(item.Enabled);
                Assert.IsTrue(item.Displayed);
            }

            var text1 = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/p[3]"));
            Assert.IsTrue(text1.Enabled);
            Assert.IsTrue(text1.Displayed);
            Assert.AreEqual(text1.Text, "The Database stores data on facilities, revenue vehicles, fixed guideway, and equipment.");

            var text2 = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div/div/p[4]"));
            Assert.IsTrue(text2.Enabled);
            Assert.IsTrue(text2.Displayed);
            Assert.AreEqual(text2.Text, "Group Plan members update the Database with inventory, condition, and other data for revenue vehicles (rolling stock) and equipment (non-revenue service vehicles).");
        }

        [Test]
        public void AboutPage_SideLeftMinimizeToggle()
        {
            // to open about Page
            AboutPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(sideLeft.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-desktop-inline-block  ");
            sideLeft.Click();
        }

        [Test]
        public void AboutPage_CopyRightTest()
        {
            // to open about Page
            AboutPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));

            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

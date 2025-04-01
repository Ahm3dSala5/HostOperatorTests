using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HostOperator.Tests
{
    public class HostOperatorVisualizationTests : IDisposable
    {
        private IWebDriver driver;
        public void Dispose()
        {
            driver.Dispose();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
               driver.Quit();
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
        public void AssetWheelPage_TestVisualizationOption()
        {
            var Visualization = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/a"));
            Assert.AreEqual(Visualization.Text, "Visualization");
            Assert.AreEqual(Visualization.GetAttribute("custom-data"), "Visualization");
            Assert.IsTrue(Visualization.Displayed);
            Assert.IsTrue(Visualization.Enabled);
            var URLBeforeClick = driver.Url;
            Visualization.Click();
            var URLAfterClick = driver.Url;
            Assert.AreEqual(URLBeforeClick, $"{URLAfterClick}");
            Assert.AreEqual(Visualization.GetAttribute("href"), $"{URLAfterClick}#");
        }

        [Test]
        public void VisualizationPage_AssetWheelOptionTest()
        {
            // to click on Visualization option 
            AssetWheelPage_TestVisualizationOption();
            // to click on Asset Wheel option
            var AssetWheelOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/nav/ul/li/a"));
            Assert.AreEqual(AssetWheelOption.GetAttribute("custom-data"), "Asset Wheel");
            var AssetWheelURL = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Visualization";
            Assert.AreEqual(AssetWheelOption.GetAttribute("href"), $"{AssetWheelURL}");
            Assert.AreEqual(AssetWheelOption.GetAttribute("target"), "_self");
            Assert.IsTrue(AssetWheelOption.Enabled);
            AssetWheelOption.Click();
        }

        [Test]
        public void AssetWheelPage_OpenPage()
        {
            var Visualization = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/a"));
            Visualization.Click();

            var AssetWheelOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/nav/ul/li/a"));
            AssetWheelOption.Click();
        }

        [Test]
        public void AssetWheelPage_TableBarTest()
        {
            // to open Asset Wheel page
            AssetWheelPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            Assert.AreEqual(hiHostOperator.Text, "HI,");
            Assert.True(hiHostOperator.Displayed);
            Assert.True(hiHostOperator.Enabled);

            var username = driver.FindElement(By.Id("UserName"));
            Assert.True(username.Displayed);
            Assert.True(username.Enabled);
        }

        [Test]
        public void AssetWheelPagePLogoutBtnTest()
        {
            // to open Asset Wheel page
            AssetWheelPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/a/span[1]"));
            hiHostOperator.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");

            var UrlBeforeClickOnLogout = driver.Url;
            logoutBtn.Click();
            var UrlAfterClickOnLogout = driver.Url;
            Assert.AreNotEqual(UrlBeforeClickOnLogout, UrlAfterClickOnLogout);
        }

        [Test]
        public void AssetWheelPage_NotificationTest()
        {
            // to open Asset Wheel page
            AssetWheelPage_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void AssetWheelPage_TestPageTitle()
        {
            // to open Asset Wheel page
            AssetWheelPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Visualization");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        // must be enabled and when click must open same page
        // this link go to dashboard page this it name must be DASHBOARD 
        [Test]
        public void AssetWheelPage_AssetWheelBtnTest()
        {
            // to open System messages page
            AssetWheelPage_OpenPage();

            var AssetWhelBtn = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li/a/span"));
            Assert.AreEqual(AssetWhelBtn.Text, "Asset Wheel");
            Assert.IsTrue(AssetWhelBtn.Displayed);
            Assert.IsTrue(AssetWhelBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            AssetWhelBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void AssetWheelPage_SunburstChartTest()
        {
            // to open Asset Wheel Page
            AssetWheelPage_OpenPage();

            var chart = driver.FindElement(By.Id("SunburstChart"));
            Assert.IsTrue(chart.Enabled);
        }

        [Test]
        public void AssetWheelPage_SideLeftMinimizeToggle()
        {
            // to open Asset Wheel Page
            AssetWheelPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}

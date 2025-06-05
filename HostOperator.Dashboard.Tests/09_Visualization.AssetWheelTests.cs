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
        public void AssetWheelPage_VisualizationOptioTest()
        {
            var visualizationOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/a"));
            Assert.IsTrue(visualizationOption.Enabled);
            Assert.IsTrue(visualizationOption.Displayed);
            Assert.AreEqual(visualizationOption.Text, "Visualization");
            Assert.AreEqual(visualizationOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(visualizationOption.GetAttribute("href"),$"{driver.Url}#");
            Assert.AreEqual(visualizationOption.GetAttribute("custom-data"), "Visualization");
            Assert.AreEqual(visualizationOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var visulizationOoptionTextArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/a/i[2]"));
            Assert.IsTrue(visulizationOoptionTextArrow.Enabled);
            Assert.IsTrue(visulizationOoptionTextArrow.Displayed);
            Assert.AreEqual(visulizationOoptionTextArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var visulizationOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/a/i[1]"));
            Assert.IsTrue(visulizationOptionIcon.Enabled);
            Assert.IsTrue(visulizationOptionIcon.Displayed);
            Assert.AreEqual(visulizationOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-suitcase");

            var visulizationOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/a/span/span"));
            Assert.IsTrue(visulizationOptionText.Enabled);
            Assert.IsTrue(visulizationOptionText.Displayed);
            Assert.AreEqual(visulizationOptionText.Text, "Visualization");
            Assert.AreEqual(visulizationOptionText.GetAttribute("class"),"title");
        }

        [Test] 
        public void AssetWheelPage_AssetWheelOptionTest()
        {
            var visualizationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/a"));
            visualizationOption.Click();

            var assetWheelOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/nav/ul/li/a"));
            Assert.IsTrue(assetWheelOption.Enabled);
            Assert.IsTrue(assetWheelOption.Displayed);
            Assert.AreEqual(assetWheelOption.Text, "Asset Wheel");
            Assert.AreEqual(assetWheelOption.GetAttribute("target"),"_self");
            Assert.AreEqual(assetWheelOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(assetWheelOption.GetAttribute("custom-data"), "Asset Wheel");
            Assert.AreEqual(assetWheelOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(assetWheelOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Visualization");

            var assetWheelOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/nav/ul/li/a/i"));
            Assert.IsTrue(assetWheelOptionIcon.Enabled);
            Assert.IsTrue(assetWheelOptionIcon.Displayed);
            Assert.AreEqual(assetWheelOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var assetWheelOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[9]/nav/ul/li/a/span/span"));
            Assert.IsTrue(assetWheelOptionText.Enabled);
            Assert.IsTrue(assetWheelOptionText.Displayed);
            Assert.AreEqual(assetWheelOptionText.Text, "Asset Wheel");
            Assert.AreEqual(assetWheelOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void AssetWheelPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Visualization");
        }

        [Test]
        public void AssetWheelPage_TopUserNameTest()
        {
            // to open Asset Wheel page
            AssetWheelPage_OpenPage();

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
        public void AssetWheelPage_NotificationIconTest()
        {
            // to open Asset Wheel page
            AssetWheelPage_OpenPage();

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
        public void AssetWheelPage_SubHeaderTitleTest()
        {
            // to open Asset Wheel page
            AssetWheelPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Visualization");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void AssetWheelPage_AssetWheelNavigationLinkTest()
        {
            // to open Asset Wheel page
            AssetWheelPage_OpenPage();

            var AssetWhelBtn = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li/a"));
            Assert.IsTrue(AssetWhelBtn.Enabled);
            Assert.IsTrue(AssetWhelBtn.Displayed);
            Assert.AreEqual(AssetWhelBtn.Text, "Asset Wheel");
            Assert.AreEqual(AssetWhelBtn.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(AssetWhelBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");
        }

        [Test]
        public void AssetWheelPage_ChartTest()
        {
            // to open Asset Wheel Page
            AssetWheelPage_OpenPage();

            var chart = driver.FindElement(By.Id("SunburstChart"));
            Assert.IsTrue(chart.Enabled);

            var chartItems = driver.FindElements(By.TagName("g"));
            foreach(var item in chartItems)
            {
                Assert.IsTrue(item.Enabled);
                Assert.IsTrue(item.Displayed);

                var pathElement = driver.FindElement(By.TagName("path"));
                Assert.IsNotNull(pathElement);
                Assert.IsTrue(pathElement.Enabled);
                Assert.IsTrue(pathElement.Displayed);
                var pathData = pathElement.GetAttribute("d");
                Assert.IsNotNull(pathData, "The <path> element should have a 'd' attribute");

                var pathText = driver.FindElement(By.TagName("text"));
                Assert.IsNotNull(pathText);
                Assert.IsTrue(pathText.Enabled);
                Assert.IsTrue(pathText.Displayed);
                 var transformAttribute = pathText.GetAttribute("transform");
                Assert.IsNotNull(transformAttribute, "The <text> element should have a 'transform' attribute");
            }
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

        [Test]
        public void AssetWheelPage_CopyRightTest()
        {
            // to open Asset Wheel Page
            AssetWheelPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

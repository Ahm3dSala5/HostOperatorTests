using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorConfigurationTests : IDisposable
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
        public void AttributesPage_OpenAttributesPage()
        {
            var configurationOption = driver.FindElement
            (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            configurationOption.Click();

            var attributesOtion = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li/a"));
            attributesOtion.Click();
        }

        [Test]
        public void AttributesPage_HiHostOperatorTest()
        {
            // to open attributes page
            AttributesPage_OpenAttributesPage();

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
        public void AttributesPage_LogoutBtn()
        {
            // to open attributes page
            AttributesPage_OpenAttributesPage();

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
        public void AttributesPage_ConfigurationOptionTest()
        {
            var configurationOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            configurationOption.Click();
            Assert.IsTrue(configurationOption.Displayed);
            Assert.IsTrue(configurationOption.Enabled);
            Assert.AreEqual(configurationOption.Text, "Configuration");
        }

        [Test]
        public void AttributesPage_AttributesOptionTest()
        {
            var configurationOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            configurationOption.Click();

            var attributesOtion = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li/a"));
            Assert.IsTrue(attributesOtion.Displayed);
            Assert.IsTrue(attributesOtion.Enabled);
            Assert.AreEqual(attributesOtion.GetAttribute("target"),"_self");
            Assert.AreEqual(attributesOtion.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetsConfigaration");
            attributesOtion.Click();
        }

        [Test]
        public void ConfigurationAttributesPage_PageTitleTest()
        {
            // to open attributes page
            AttributesPage_OpenAttributesPage();

            var pageTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(pageTitle.Text, "Configuration - Attributes");
            Assert.IsTrue(pageTitle.Enabled);
            Assert.IsTrue(pageTitle.Displayed);
        }

        [Test]
        public void AttributesPage_AssetClassDropdownlistTest()
        {
            // to open attributes page
            AttributesPage_OpenAttributesPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[1]/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text,"Asset Class");
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);

            var assetClassInput = driver.FindElement(By.Id("AssetClassIdChange"));
            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(1);
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            var requiredMessage = "The ClassId field is required.";
            Assert.AreEqual(assetClassInput.GetAttribute("data-val-required"), requiredMessage);
        }

        [Test]
        public void AttributesPage_AssetSubClassDropdownlistTest()
        {
            // to open attributes page
            AttributesPage_OpenAttributesPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            var selectedAssetSubClass = new SelectElement(assetSubClassInput);
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.IsTrue(assetSubClassInput.Displayed);
            var requiredMessage = "The SubClassId field is required.";
            Assert.AreEqual(assetSubClassInput.GetAttribute("data-val-required"), requiredMessage);
        }

        [Test]
        public void AttributesPage_AssetTypeDropdownlistTest()
        {
            // to open attributes page
            AttributesPage_OpenAttributesPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            var assetTypeInput = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            var selectedAssetTypeClass = new SelectElement(assetTypeInput);
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.IsTrue(assetTypeInput.Displayed);
            var requiredMessage = "The TypeId field is required.";
            Assert.AreEqual(assetTypeInput.GetAttribute("data-val-required"), requiredMessage);
        }

        [Test]
        public void AttributesPage_SideLeftMinimizeToggle()
        {
            // to open attributes page
            AttributesPage_OpenAttributesPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}

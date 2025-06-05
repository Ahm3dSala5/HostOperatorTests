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
        public void AttributesPage_ConfigurationOptionTest()
        {
            var configurationOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a"));
            Assert.IsTrue(configurationOption.Enabled);
            Assert.IsTrue(configurationOption.Displayed);
            Assert.AreEqual(configurationOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(configurationOption.GetAttribute("href"),$"{driver.Url}#");
            Assert.AreEqual(configurationOption.GetAttribute("custom-data"), "Configuration");
            Assert.AreEqual(configurationOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var configurationOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/i[1]"));
            Assert.IsTrue(configurationOptionIcon.Enabled);
            Assert.IsTrue(configurationOptionIcon.Displayed);
            Assert.AreEqual(configurationOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var configurationOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/i[2]"));
            Assert.IsTrue(configurationOptionArrow.Enabled);
            Assert.IsTrue(configurationOptionArrow.Displayed);
            Assert.AreEqual(configurationOptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var configurationOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a/span/span"));
            Assert.IsTrue(configurationOptionText.Enabled);
            Assert.IsTrue(configurationOptionText.Displayed);
            Assert.AreEqual(configurationOptionText.Text,"Configuratuion");
            Assert.AreEqual(configurationOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void AttributesPage_AttributesOptionTest()
        {
            var configurationOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/a"));
            configurationOption.Click();

            var attributesOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li/a"));
            Assert.IsTrue(attributesOption.Enabled);
            Assert.IsTrue(attributesOption.Displayed);
            Assert.AreEqual(attributesOption.GetAttribute("target"),"_self");
            Assert.AreEqual(attributesOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(attributesOption.GetAttribute("custom-data"),"Attributes");
            Assert.AreEqual(attributesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(attributesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetsConfigaration");

            var attributesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li/a/i"));
            Assert.IsTrue(attributesOptionIcon.Enabled);
            Assert.IsTrue(attributesOptionIcon.Displayed);
            Assert.AreEqual(attributesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-list-1");

            var attributesOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[3]/nav/ul/li/a/span/span"));
            Assert.IsTrue(attributesOptionText.Enabled);
            Assert.IsTrue(attributesOptionText.Displayed);
            Assert.AreEqual(attributesOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void AttributesPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/AssetsConfigaration");
        }

        [Test]
        public void AttributesPage_TopUserNameTest()
        {
            // to open attributes page
            AttributesPage_OpenPage();

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
        public void AttributesPage_LogoutBtn()
        {
            // to open attributes page
            AttributesPage_OpenPage();

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
        public void AttributesPage_TenantHeadTest()
        {
            // to open attributes page
            AttributesPage_OpenPage();

            var tenantHead = driver.FindElement(By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[3]/a/div/span"));
            tenantHead.Click();
        }

        [Test]
        public void AttributesPage_NotificationIconTest()
        {
            // to open attributes page
            AttributesPage_OpenPage();
            
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
        public void AttributesPage_SubHeaderTitleTest()
        {
            // to open attributes page
            AttributesPage_OpenPage();

            var subTitle = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));
            Assert.IsTrue(subTitle.Enabled);
            Assert.IsTrue(subTitle.Displayed);
            Assert.AreEqual(subTitle.Text, "Configuration - Attributes");
            Assert.AreEqual(subTitle.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void AttributesPage_AssetClassDropdownlistTest()
        {
            // to open attributes page
            AttributesPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[1]/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text,"Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"),"form-label");

            var assetClassInput = driver.FindElement(By.Id("AssetClassIdChange"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("data-val"),"true");
            Assert.AreEqual(assetClassInput.GetAttribute("class"),"form-control form-line");
            Assert.AreEqual(assetClassInput.GetAttribute("data-val-required"), "The ClassId field is required.");

            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(0);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetClassIdChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"Choose Class");
        }

        [Test]
        public void AttributesPage_AssetSubClassDropdownlistTest()
        {
            // to open attributes page
            AttributesPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[2]/div/div/label"));
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");

            var assetSubClassInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.AreEqual(assetSubClassInput.GetAttribute("data-val"),"true");
            Assert.AreEqual(assetSubClassInput.GetAttribute("class"),"form-control form-line");
            Assert.AreEqual(assetSubClassInput.GetAttribute("data-val-required"), "The SubClassId field is required.");
            
            var selectedAssetSubClass = new SelectElement(assetSubClassInput);
            
            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetSubClassDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"No Select Subclass");
        }

        [Test]
        public void AttributesPage_AssetTypeDropdownlistTest()
        {
            // to open attributes page
            AttributesPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div[1]/div[3]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeInput = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.IsTrue(assetTypeInput.Displayed);
            Assert.AreEqual(assetTypeInput.GetAttribute("data-val"),"true");
            Assert.AreEqual(assetTypeInput.GetAttribute("class"),"form-control form-line");
            Assert.AreEqual(assetTypeInput.GetAttribute("data-val-required"), "The TypeId field is required.");
            
            var selectedAssetTypeClass = new SelectElement(assetTypeInput);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "No Select Types");
        }

        [Test]
        public void AttributesPage_SideLeftMinimizeToggle()
        {
            // to open attributes page
            AttributesPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.AreEqual(sideLeft.GetAttribute("class"), "m-brand__icon m-brand__toggler m-brand__toggler--left m--visible-tablet-and-mobile-inline-block");
            sideLeft.Click();
        }

        [Test]
        public void AttributesPage_CopyRightTest()
        {
            // to open Attributes Page
            AttributesPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}
// tenant Head 
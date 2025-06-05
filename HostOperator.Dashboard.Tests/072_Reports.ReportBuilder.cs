using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorReportsReportBuilder : IDisposable
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
        public void ReportBuilderPage_ReportsOptionTest()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            Assert.IsTrue(reportOption.Enabled);
            Assert.IsTrue(reportOption.Displayed);
            Assert.AreEqual(reportOption.Text, "Reports");
            Assert.AreEqual(reportOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(reportOption.GetAttribute("href"), $"{driver.Url}#");
            Assert.AreEqual(reportOption.GetAttribute("custom-data"), "Reports");
            Assert.AreEqual(reportOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var reportsOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a/i[1]"));
            Assert.IsTrue(reportsOptionIcon.Enabled);
            Assert.IsTrue(reportsOptionIcon.Displayed);
            Assert.AreEqual(reportsOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var reportsOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a/i[2]"));
            Assert.IsTrue(reportsOptionArrow.Enabled);
            Assert.IsTrue(reportsOptionArrow.Displayed);
            Assert.AreEqual(reportsOptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var reportsOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a/span/span"));
            Assert.IsTrue(reportsOptionText.Enabled);
            Assert.IsTrue(reportsOptionText.Displayed);
            Assert.AreEqual(reportsOptionText.Text, "Reports");
            Assert.AreEqual(reportsOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void ReportBuilderPage_ReportBuilderOptionTest()
        {
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var reportBuilderOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[2]/a"));
            Assert.IsTrue(reportBuilderOption.Enabled);
            Assert.IsTrue(reportBuilderOption.Displayed);
            Assert.AreEqual(reportBuilderOption.Text, "Report Builder");
            Assert.AreEqual(reportBuilderOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(reportBuilderOption.GetAttribute("target"), "_self");
            Assert.AreEqual(reportBuilderOption.GetAttribute("custom-data"), "Report Builder");
            Assert.AreEqual(reportBuilderOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/ReportBuilder");

            var reportBuilderOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[2]/a/i"));
            Assert.IsTrue(reportBuilderOptionIcon.Enabled);
            Assert.IsTrue(reportBuilderOptionIcon.Displayed);
            Assert.AreEqual(reportBuilderOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var reportBuilderOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[2]/a/span/span"));
            Assert.IsTrue(reportBuilderOptionText.Enabled);
            Assert.IsTrue(reportBuilderOptionText.Displayed);
            Assert.AreEqual(reportBuilderOptionText.Text,"Report Builder");
            Assert.AreEqual(reportBuilderOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void ReportBuilderPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/ReportBuilder");
        }

        [Test]
        public void ReportBuilderPage_TopUserNameTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

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
        public void ReportBuilderPage_LogoutBtn()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.ClassName("m-topbar__username"));
            hiHostOperator.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Thread.Sleep(5000);

            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("class"), "btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder");
        }

        [Test]
        public void ReportBuilderPage_NotificationIconTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

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
        public void AssetAuditPage_SubHeaderTitleTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Report Builder");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void ReportBuilderPage_DashboardNavLinkTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text, "Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void ReportBuilderPage_SelectAgenciesLabelTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var agenciesLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[1]/div/div/label"));
            Assert.IsTrue(agenciesLabel.Enabled);
            Assert.IsTrue(agenciesLabel.Displayed);
            Assert.AreEqual(agenciesLabel.Text, "Select Agencies");
            Assert.AreEqual(agenciesLabel.GetAttribute("for"), "AssetState");
            Assert.AreEqual(agenciesLabel.GetAttribute("class"),"form-label");
        }

        [Test]
        public void ReportBuilderPage_SelectAgenciesInputTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var agenciesInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[1]/div/div/input[1]"));
            Assert.IsTrue(agenciesInput.Enabled);
            Assert.IsTrue(agenciesInput.Displayed);
            Assert.AreEqual(agenciesInput.GetAttribute("type"),"text");
            Assert.AreEqual(agenciesInput.GetAttribute("class"), "form-control tenantsBox");
            Assert.AreEqual(agenciesInput.GetAttribute("placeholder"), "Click to select agencies");
        }

        [Test]
        public void ReportBuilderPage_SelectAgenciesFormTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var agenciesInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[1]/div/div/input[1]"));
            agenciesInput.Click();

            
            var tier1 = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[2]/div[1]/div[2]/label/input"));
            tier1.Click();
            Assert.IsTrue(tier1.Enabled);
            Assert.IsTrue(tier1.Displayed);
            Assert.AreEqual(tier1.GetAttribute("class"),"tiers");
            Assert.AreEqual(tier1.GetAttribute("type"), "checkbox");

            var tier2 = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[2]/div[1]/div[3]/label/input"));
            tier2.Click();
            Assert.IsTrue(tier2.Enabled);
            Assert.IsTrue(tier2.Displayed);
            Assert.AreEqual(tier2.GetAttribute("class"),"tiers");
            Assert.AreEqual(tier2.GetAttribute("type"), "checkbox");

            var selectAgenciesBtn = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[3]/button[1]"));
            Assert.IsTrue(selectAgenciesBtn.Enabled);
            Assert.IsTrue(selectAgenciesBtn.Displayed);
            Assert.AreEqual(selectAgenciesBtn.Text,"Select Agencies");
            Assert.AreEqual(selectAgenciesBtn.GetAttribute("type"),"button");
            Assert.AreEqual(selectAgenciesBtn.GetAttribute("class"), "btn btn-primary waves-effect myModalSubmit");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[3]/button[2]"));
            Assert.IsTrue(cancelBtn.Enabled);
            Assert.IsTrue(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"),"button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect myModalClose");
        }

        [Test]
        public void ReportBuilderPage_AssetClassDropdownlistTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[2]/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"),"form-label");

            var assetClassInput = driver.FindElement(By.Id("AssetClassIdChange"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("class"),"form-control form-line");

            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(1);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetClassIdChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"Choose Class");
        }

        [Test]
        public void ReportBuilderPage_AssetSubClassDropdownlistTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[3]/div/div/label"));
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"),"form-label");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"),"AssetSubClass");

            var assetSubClassInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.AreEqual(assetSubClassInput.GetAttribute("class"),"form-control form-line");

            var selectedAssetSubClass = new SelectElement(assetSubClassInput);

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Choose Subclass");
        }

        [Test]
        public void ReportBuilderPage_AssetTypeDropdownlistTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[4]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"), "AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeInput = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.IsTrue(assetTypeInput.Displayed);
            Assert.AreEqual(assetTypeInput.GetAttribute("class"), "form-control form-line");

            var selectedAssetTypeClass = new SelectElement(assetTypeInput);

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Choose Type");
        }

        [Test]
        public void ReportBuilderPage_SideLeftMinimizeToggle()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }

        [Test]
        public void ReportBuilderPagee_CopyRightTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

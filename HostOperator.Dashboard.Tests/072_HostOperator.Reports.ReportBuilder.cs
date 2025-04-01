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
        public void ReportBuilderPage_ReportOptionTest()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            Assert.AreEqual(reportOption.Text, "Reports");
            Assert.AreEqual(reportOption.GetAttribute("custom-data"), "Reports");
            Assert.IsTrue(reportOption.Displayed);
            Assert.IsTrue(reportOption.Enabled);
            reportOption.Click();
        }

        [Test]
        public void ReportBuilderPage_ReportBuilderOptionTest()
        {
            // to click on report option 
            ReportBuilderPage_ReportOptionTest();

            var reportBuilderOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[2]/a"));
            Assert.AreEqual(reportBuilderOption.Text, "Report Builder");
            Assert.AreEqual(reportBuilderOption.GetAttribute("custom-data"), "Report Builder");
            Assert.AreEqual(reportBuilderOption.GetAttribute("target"), "_self");
            Assert.AreEqual(reportBuilderOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/ReportBuilder");
            Assert.IsTrue(reportBuilderOption.Displayed);
            Assert.IsTrue(reportBuilderOption.Enabled);
            reportBuilderOption.Click();
        }

        [Test]
        public void ReportBuilderPage_OpenReportBuilderPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            var reportBuilderPage = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[2]/a"));
            reportOption.Click();
            reportBuilderPage.Click();
        }

        [Test]
        public void ReportBuilderPage_HiHostOperatorTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

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
        public void ReportBuilderPage_LogoutBtn()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

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
        public void ReportBuilderPage_NotificationTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void ReportBuilderPage_DashboardBtnTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

            var dashboardBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.AreEqual(dashboardBtn.Text, "Dashboard");
            Assert.IsTrue(dashboardBtn.Displayed);
            Assert.IsTrue(dashboardBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            dashboardBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void ReportBuilderPage_PageTitleTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Report Builder");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void ReportBuilderPage_SelectAgenciesLabelTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

            var agenciesLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[1]/div/div/label"));
            Assert.AreEqual(agenciesLabel.Text, "Select Agencies");
            Assert.IsTrue(agenciesLabel.Displayed);
            Assert.IsTrue(agenciesLabel.Enabled);
        }

        [Test]
        public void ReportBuilderPage_SelectAgenciesInputTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

            var agenciesInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[1]/div/div/input[1]"));
            Assert.IsTrue(agenciesInput.Displayed);
            Assert.IsTrue(agenciesInput.Enabled);
            Assert.AreEqual(agenciesInput.GetAttribute("placeholder"), "Click to select agencies");
            agenciesInput.Click();
        }

        [Test]
        public void ReportBuilderPage_SelectAgenciesFormTest()
        {
            // to open report builder page and click on select agencies input
            ReportBuilderPage_OpenReportBuilderPage();
            var agenciesInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[1]/div/div/input[1]"));
            agenciesInput.Click();

            var formTilte = driver.FindElement(By.XPath("//*[@id=\"myModal\"]/div/div/div[1]/h4"));
            Assert.IsTrue(formTilte.Displayed);
            Assert.IsTrue(formTilte.Enabled);
            Assert.AreEqual(formTilte.Text, "Agencies");

            var tier1Label = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[2]/div[1]/div[2]/label"));
            Assert.IsTrue(tier1Label.Displayed);
            Assert.IsTrue(tier1Label.Displayed);
            Assert.AreEqual(tier1Label.Text, "Tier 1");

            var tier1CheckBox = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[2]/div[1]/div[2]/label/input"));
            Assert.AreEqual(tier1CheckBox.GetAttribute("type"), "checkbox");
            Assert.IsTrue(tier1CheckBox.Displayed);
            Assert.IsTrue(tier1CheckBox.Enabled);
            tier1CheckBox.Click();

            var tier2Label = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[2]/div[1]/div[3]/label"));
            Assert.IsTrue(tier2Label.Displayed);
            Assert.IsTrue(tier2Label.Displayed);
            Assert.AreEqual(tier2Label.Text, "Tier 2");

            var tier2CheckBox = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[2]/div[1]/div[3]/label/input"));
            Assert.AreEqual(tier2CheckBox.GetAttribute("type"), "checkbox");
            Assert.IsTrue(tier2CheckBox.Displayed);
            Assert.IsTrue(tier2CheckBox.Enabled);
            tier2CheckBox.Click();

            var selectAgenciesBtn = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[3]/button[1]"));
            Assert.IsTrue(selectAgenciesBtn.Displayed);
            Assert.IsTrue(selectAgenciesBtn.Enabled);
            Assert.AreEqual(selectAgenciesBtn.Text,"Select Agencies");

            var cancelBtn = driver.FindElement
                (By.XPath("//*[@id=\"myModal\"]/div/div/div[3]/button[2]"));
            Assert.IsTrue(cancelBtn.Displayed);
            Assert.IsTrue(cancelBtn.Enabled);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
        }



        [Test]
        public void ReportBuilderPage_AssetClassDropdownlistTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[2]/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);

            var assetClassInput = driver.FindElement(By.Id("AssetClassIdChange"));
            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(1);
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
        }

        [Test]
        public void ReportBuilderPage_AssetSubClassDropdownlistTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[3]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            var selectedAssetSubClass = new SelectElement(assetSubClassInput);
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.IsTrue(assetSubClassInput.Displayed);
        }

        [Test]
        public void ReportBuilderPage_AssetTypeDropdownlistTest()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[4]/div/div/div[1]/div[1]/div[4]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            var assetTypeInput = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            var selectedAssetTypeClass = new SelectElement(assetTypeInput);
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.IsTrue(assetTypeInput.Displayed);
        }

        [Test]
        public void ReportBuilderPage_SideLeftMinimizeToggle()
        {
            // to open report builder page
            ReportBuilderPage_OpenReportBuilderPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorReportsAuditTests : IDisposable
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
        public void ReportOption_TestOption()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            Assert.AreEqual(reportOption.Text,"Reports");
            Assert.AreEqual(reportOption.GetAttribute("custom-data"),"Reports");
            Assert.IsTrue(reportOption.Displayed);
            Assert.IsTrue(reportOption.Enabled);
            reportOption.Click();
        }

        [Test]
        public void AssetAuditPage_AssetAuditOptionTest()
        {
            // to click on audit option 
            ReportOption_TestOption();

            var assetAuditOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[1]/a"));
            Assert.AreEqual(assetAuditOption.Text, "Asset Audit");
            Assert.AreEqual(assetAuditOption.GetAttribute("custom-data"), "Asset Audit");
            Assert.AreEqual(assetAuditOption.GetAttribute("target"), "_self");
            Assert.IsTrue(assetAuditOption.Displayed);
            Assert.IsTrue(assetAuditOption.Enabled);
            assetAuditOption.Click();
        }

        [Test]
        public void  AssetAuditPage_OpenAssetAuditPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            var assetAuditOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[1]/a"));
            reportOption.Click();
            assetAuditOption.Click();
        }

        [Test]
        public void AssetAuditPage_HiHostOperatorTest()
        {
            // to open asset audit page
            AssetAuditPage_OpenAssetAuditPage();

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
        public void AssetAuditPage_LogoutBtn()
        {
            // to open asset audit page
            AssetAuditPage_OpenAssetAuditPage();

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
        public void AssetAuditPage_NotificationTest()
        {
            // to open asset audit page
            AssetAuditPage_OpenAssetAuditPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void AssetAuditPage_DashboardBtnTest()
        {
            // to open asset audit page
            AssetAuditPage_OpenAssetAuditPage();

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
        public void AssetAuditPage_PageTitleTest()
        {
            // to open asset audit page
            AssetAuditPage_OpenAssetAuditPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Asset Audit");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void AssetAuditPage_AgencyNameTest()
        {
            // to open asset audit
            AssetAuditPage_AssetAuditOptionTest();

            var agencyNameLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/label"));
            Assert.IsTrue(agencyNameLabel.Displayed);
            Assert.IsTrue(agencyNameLabel.Enabled);
            Assert.AreEqual(agencyNameLabel.Text, "Select Agency Name");
            agencyNameLabel.Click();

            var agencyName = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/button"));
            Assert.IsTrue(agencyName.Displayed);
            Assert.IsTrue(agencyName.Enabled);
            Assert.AreEqual(agencyName.GetAttribute("title"), "None selected");
            Assert.AreEqual(agencyName.GetAttribute("data-toggle"), "dropdown");
            agencyName.Click();
        }

        [Test]
        public void AssetAuditPage_AssetClassDropdownlistTest()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[1]/div/div[1]/label"));
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            assetClassLabel.Click();

            var assetClassInput = driver.FindElement
                (By.Id("AssetClassIdChange"));
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.IsTrue(assetClassInput.Enabled);
            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(0);
        }

        [Test]
        public void AssetAuditPage_AssetSubclassDropdownlistTest()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[2]/div/div[1]/label"));
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            assetSubClassLabel.Click();

            var assetSubClassInput = driver.FindElement
                (By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.IsTrue(assetSubClassInput.Enabled);
            var selectedAssetSubClass = new SelectElement(assetSubClassInput);
            selectedAssetSubClass.SelectByIndex(0);
        }

        [Test]
        public void AssetAuditPage_AssetTypeDropdownlistTest()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[3]/div/div[1]/label"));
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            assetTypeLabel.Click();

            var assetTypeInout = driver.FindElement
                (By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeInout.Displayed);
            Assert.IsTrue(assetTypeInout.Enabled);
            var selectedAssetType = new SelectElement(assetTypeInout);
            selectedAssetType.SelectByIndex(0);
        }

        [Test]
        public void AssetAuditPage_AssetStateDropdownlist()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var assetStateLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[4]/div/div/label"));
            Assert.IsTrue(assetStateLabel.Displayed);
            Assert.IsTrue(assetStateLabel.Enabled);
            Assert.AreEqual(assetStateLabel.Text, "Asset State");
            assetStateLabel.Click();

            var assetStateInout = driver.FindElement
                (By.Id("AssetStateIdChange"));
            Assert.IsTrue(assetStateInout.Displayed);
            Assert.IsTrue(assetStateInout.Enabled);
            var selectedAssetState = new SelectElement(assetStateInout);
            selectedAssetState.SelectByIndex(0);
        }

        [Test]
        public void AssetAuditPage_StartDateTest()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var startDateLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[5]/div/div/label"));
            Assert.IsTrue(startDateLabel.Displayed);
            Assert.IsTrue(startDateLabel.Enabled);
            Assert.AreEqual(startDateLabel.Text, "Start Date");
            startDateLabel.Click();

            var startDataInout = driver.FindElement(By.Id("StartDate"));
            Assert.IsTrue(startDataInout.Displayed);
            Assert.IsTrue(startDataInout.Enabled);
            Assert.AreEqual(startDataInout.GetAttribute("type"),"date");
            Assert.AreEqual(startDataInout.GetAttribute("max"), 
                $"{DateTime.Now.Year}-0{DateTime.Now.Month}-{DateTime.Now.Day}");
        }

        [Test]
        public void AssetAuditPage_EndDateTest()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var endDateLabel = driver.FindElement
                (By.XPath("//*[@id=\"New Filter\"]/div[6]/div/div/label"));
            Assert.IsTrue(endDateLabel.Displayed);
            Assert.IsTrue(endDateLabel.Enabled);
            Assert.AreEqual(endDateLabel.Text, "End Date");
            endDateLabel.Click();

            var startDataInout = driver.FindElement(By.Id("EndDate"));
            Assert.IsTrue(startDataInout.Displayed);
            Assert.IsTrue(startDataInout.Enabled);
            Assert.AreEqual(startDataInout.GetAttribute("type"), "date");
            Assert.AreEqual(startDataInout.GetAttribute("max"), "9999-12-31");
            startDataInout.Click();
        }

        [Test]
        public void AssetAuditPage_SubmitBtnTest()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var submitBtn = driver.FindElement(By.Id("subbtn"));
            Assert.IsTrue(submitBtn.Displayed);
            Assert.IsTrue(submitBtn.Enabled);
            Assert.AreEqual(submitBtn.Text, "Submit");
            submitBtn.Click();
        }

        [Test]
        public void AssetAuditPage_DataTableLengthTest()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"AssetsTable_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("AssetsTable_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void AssetAuditPage_DataTableFilterTest()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("AssetsTable_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void AssetAuditPage_PaginateTest()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var previousBtn = driver.FindElement(By.Id("AssetsTable_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);

            var nextBtn = driver.FindElement(By.Id("AssetsTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
        }

        [Test]
        public void AssetAuditPage_SideLeftMinimizeToggle()
        {
            // to open asset audit
            AssetAuditPage_OpenAssetAuditPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}

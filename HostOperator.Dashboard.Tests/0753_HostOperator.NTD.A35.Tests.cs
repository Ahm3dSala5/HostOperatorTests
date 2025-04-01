using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Script;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorNTDA35Tests : IDisposable
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
        public void A35Page_TestReportOption()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            Assert.AreEqual(reportOption.Text, "Reports");
            Assert.AreEqual(reportOption.GetAttribute("custom-data"), "Reports");
            Assert.IsTrue(reportOption.Displayed);
            Assert.IsTrue(reportOption.Enabled);
            var URLBeforeClick = driver.Url;
            reportOption.Click();
            var URLAfterClick = driver.Url;
            Assert.AreEqual(URLBeforeClick, $"{URLAfterClick}");
            Assert.AreEqual(reportOption.GetAttribute("href"), $"{URLAfterClick}#");
        }

        [Test]
        public void A35Page_TestNTDOption()
        {
            // to click on report option 
            A35Page_TestReportOption();

            var NTDOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            Assert.AreEqual(NTDOption.GetAttribute("custom-data"), "NTD");
            var currentUrl = driver.Url;
            Assert.AreEqual(NTDOption.GetAttribute("href"), $"{currentUrl}#");
            Assert.IsTrue(NTDOption.Displayed);
            Assert.IsTrue(NTDOption.Enabled);
            NTDOption.Click();
        }

        [Test]
        public void A35Page_TestA30Btn()
        {
            // to click on report option 
            A35Page_TestReportOption();
            // to click on NTD option
            var NTDOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var A35Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[3]/a"));
            Assert.AreEqual(A35Option.GetAttribute("custom-data"), "A-35");
            var A35URl = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/A35Details";
            Assert.AreEqual(A35Option.GetAttribute("href"), $"{A35URl}");
            Assert.AreEqual(A35Option.GetAttribute("target"), "_self");
            Assert.IsTrue(A35Option.Enabled);
            A35Option.Click();
        }

        // to open page
        [Test]
        public void A35Page_OpenPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var A35Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[3]/a"));
            A35Option.Click();
        }

        [Test]
        public void A30Page_TableBarTest()
        {
            // to open A30 page
            A35Page_OpenPage();

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
        public void A35Page_LogoutBtnTest()
        {
            // to open A35 page
            A35Page_OpenPage();

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
        public void A35Page_NotificationTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void A35Page_TestPageTitle()
        {
            // to open A35 page
            A35Page_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "A-35");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void A35Page_ReportBtnTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var reportBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.AreEqual(reportBtn.Text, "Reports");
            Assert.IsTrue(reportBtn.Displayed);
            Assert.IsTrue(reportBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            reportBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }

        // must be enabled and when click must open same page
        [Test]
        public void A35_NTDBtnTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var NTDBtn = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a/span"));
            Assert.AreEqual(NTDBtn.Text, "NTD");
            Assert.IsTrue(NTDBtn.Displayed);
            Assert.IsTrue(NTDBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            NTDBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        // this button also must opne same page
        [Test]
        public void A35Page_A35BtnTest()
        {
            // to open A30 page
            A35Page_OpenPage();

            var A15Btn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a/span"));
            Assert.AreEqual(A15Btn.Text, "A-35");
            Assert.IsTrue(A15Btn.Displayed);
            Assert.IsTrue(A15Btn.Enabled);
            var UrlBeforeClick = driver.Url;
            A15Btn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void A35Page_DataTableLengthTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"a35Details_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("a35Details_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void A35Page_DataTableFilterTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("a35Details_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"a35Details_filter\"]/label"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void A35Page_AssetClassParagraphTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);

            var assetClassInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/b"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.Text, "Equipment");
        }

        [Test]
        public void A35Page_AssetSubClassDropdownlistTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
              Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Service Vehicles");
        }

        [Test]
        public void A35Page_AssetTypeDropdownlistTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            var assetTypeValue = driver.FindElement
            (By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            var selectedAssetSubClass = new SelectElement(assetTypeValue);
            selectedAssetSubClass.SelectByIndex(0);
        }

        [Test]
        public void A35Page_ReOrderTableTest()
        {
            // to open A35 page
            ////////////////////////////////////
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var A35Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[3]/a"));
            A35Option.Click();
            ////////////////////////////////////


            var columns = driver.FindElements(By.Id("a35Details"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Displayed);
            Assert.IsTrue(RowNo.Enabled);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var NTDId = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[2]"));
            Assert.IsTrue(NTDId.Displayed);
            Assert.IsTrue(NTDId.Enabled);
            Assert.AreEqual(NTDId.Text, "NTD Id");
            Assert.AreEqual(NTDId.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(NTDId.GetAttribute("aria-label"), "NTD Id: activate to sort column ascending");
            //NTDId.Click();

            var FleetId = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[3]"));
            Assert.IsTrue(FleetId.Displayed);
            Assert.IsTrue(FleetId.Enabled);
            Assert.AreEqual(FleetId.Text, "Fleet Id");
            Assert.AreEqual(FleetId.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(FleetId.GetAttribute("aria-label"), "Fleet Id: activate to sort column ascending");
            //FleetId.Click(); 

            var FleetName = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[4]"));
            Assert.IsTrue(FleetName.Displayed);
            Assert.IsTrue(FleetName.Enabled);
            Assert.AreEqual(FleetName.Text, "Fleet Name");
            Assert.AreEqual(FleetName.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(FleetName.GetAttribute("aria-label"), "Fleet Name: activate to sort column ascending");
            //FleetName.Click(); 

            var VehicleType = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[5]"));
            Assert.IsTrue(VehicleType.Displayed);
            Assert.IsTrue(VehicleType.Enabled);
            Assert.AreEqual(VehicleType.Text, "Vehicle Type");
            Assert.AreEqual(VehicleType.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(VehicleType.GetAttribute("aria-label"), "Vehicle Type: activate to sort column ascending");
            //VehicleType.Click(); 

            var PrimaryMode = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[6]"));
            Assert.IsTrue(PrimaryMode.Displayed);
            Assert.IsTrue(VehicleType.Enabled);
            Assert.AreEqual(PrimaryMode.Text, "Primary Mode");
            Assert.AreEqual(PrimaryMode.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(PrimaryMode.GetAttribute("aria-label"), "Primary Mode: activate to sort column ascending");
            //PrimaryMode.Click(); 

            var YearManufactured = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[7]"));
            Assert.IsTrue(YearManufactured.Displayed);
            Assert.IsTrue(YearManufactured.Enabled);
            Assert.AreEqual(YearManufactured.Text, "Year Manufactured");
            Assert.AreEqual(YearManufactured.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(YearManufactured.GetAttribute("aria-label"), "Year Manufactured: activate to sort column ascending");
            //YearManufactured.Click(); 

            var EstimatedCost = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[8]"));
            Assert.IsTrue(EstimatedCost.Displayed);
            Assert.IsTrue(EstimatedCost.Enabled);
            Assert.AreEqual(EstimatedCost.Text, "Estimated Cost");
            Assert.AreEqual(EstimatedCost.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(EstimatedCost.GetAttribute("aria-label"), "Estimated Cost: activate to sort column ascending");
            //EstimatedCost.Click(); 

            var UsefulLifeBenchmark = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[9]"));
            Assert.IsTrue(UsefulLifeBenchmark.Displayed);
            Assert.IsTrue(UsefulLifeBenchmark.Enabled);
            Assert.AreEqual(UsefulLifeBenchmark.Text, "Useful Life Benchmark");
            Assert.AreEqual(UsefulLifeBenchmark.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(UsefulLifeBenchmark.GetAttribute("aria-label"), "Useful Life Benchmark: activate to sort column ascending");
            //UsefulLifeBenchmark.Click(); 

            var UsefulLifeRemaining = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[10]"));
            Assert.IsTrue(UsefulLifeRemaining.Displayed);
            Assert.IsTrue(UsefulLifeRemaining.Enabled);
            Assert.AreEqual(UsefulLifeRemaining.Text, "Useful Life Remaining");
            Assert.AreEqual(UsefulLifeRemaining.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(UsefulLifeRemaining.GetAttribute("aria-label"), "Useful Life Remaining: activate to sort column ascending");
            //UsefulLifeRemaining.Click(); 

            var TransitAgencyCapitalResponsibility = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[11]"));
            Assert.IsTrue(TransitAgencyCapitalResponsibility.Displayed);
            Assert.IsTrue(TransitAgencyCapitalResponsibility.Enabled);
            Assert.AreEqual(TransitAgencyCapitalResponsibility.Text, "Transit Agency Capital Responsibility");
            Assert.AreEqual(TransitAgencyCapitalResponsibility.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(TransitAgencyCapitalResponsibility.GetAttribute("aria-label"), "Transit Agency Capital Responsibility: activate to sort column ascending");
            //TransitAgencyCapitalResponsibility.Click(); 

            var YearDollarsEstimatedCost = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[12]"));
            Assert.IsTrue(YearDollarsEstimatedCost.Displayed);
            Assert.IsTrue(YearDollarsEstimatedCost.Enabled);
            Assert.AreEqual(YearDollarsEstimatedCost.Text, "Year Dollars Estimated Cost");
            Assert.AreEqual(YearDollarsEstimatedCost.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(YearDollarsEstimatedCost.GetAttribute("aria-label"), "Year Dollars Estimated Cost: activate to sort column ascending");
            //YearDollarsEstimatedCost.Click(); 

            var SecondaryMode = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[13]"));
            Assert.IsTrue(SecondaryMode.Displayed);
            Assert.IsTrue(SecondaryMode.Enabled);
            Assert.AreEqual(SecondaryMode.Text, "Secondary Mode");
            Assert.AreEqual(SecondaryMode.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(SecondaryMode.GetAttribute("aria-label"), "Secondary Mode: activate to sort column ascending");
            //SecondaryMode.Click(); 

            var Notes = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[14]"));
            Assert.IsTrue(Notes.Displayed);
            Assert.IsTrue(Notes.Enabled);
            Assert.AreEqual(Notes.Text, "Notes");
            Assert.AreEqual(Notes.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(Notes.GetAttribute("aria-label"), "Notes: activate to sort column ascending");
            
            //Notes.Click(); 
            var Status = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[15]"));
            Assert.IsTrue(Status.Displayed);
            Assert.IsTrue(Status.Enabled);
            Assert.AreEqual(Status.Text, "Status");
            Assert.AreEqual(Status.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(Status.GetAttribute("aria-label"), "Status: activate to sort column ascending");
            //Status.Click(); 
        }

        [Test]
        public void A35Page_PaginateTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var previousBtn = driver.FindElement(By.Id("a35Details_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("a35Details_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            nextBtn.Click();
        }

        [Test]
        public void A35Page_ExportBtnTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void A35Page_SideLeftMinimizeToggle()
        {
            // to open A35 page
            A35Page_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Script;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorNTDA15Tests : IDisposable
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
        public void A15Page_TestReportOption()
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
        public void A15Page_TestNTDOption()
        {
            // to click on report option 
            A15Page_TestReportOption();

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
        public void A15Page_TestA15Btn()
        {
            // to click on report option 
            A15Page_TestReportOption();
            // to click on NTD option
            var NTDOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var A15Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[1]/a"));
            Assert.AreEqual(A15Option.GetAttribute("custom-data"), "A-15");
            var A15URl = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/A15Details";
            Assert.AreEqual(A15Option.GetAttribute("href"), $"{A15URl}");
            Assert.AreEqual(A15Option.GetAttribute("target"), "_self");
            Assert.IsTrue(A15Option.Enabled);
            A15Option.Click();
        }

        // to open page
        [Test]
        public void A15Page_OpenPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var A15Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[1]/a"));
            A15Option.Click();
        }

        [Test]
        public void A15Page_TableBarTest()
        {
            // to open A15 page
            A15Page_OpenPage();

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
        public void A15Page_LogoutBtnTest()
        {
            // to open A15 page
            A15Page_OpenPage();

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
        public void A15Page_NotificationTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void A15Page_TestPageTitle()
        {
            // to open A15 page
            A15Page_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "A-15");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void A15Page_ReportBtnTest()
        {
            // to open A15 page
            A15Page_OpenPage();

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
        public void A30Page_NTDBtnTest()
        {
            // to open A15 page
            A15Page_OpenPage();

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
        public void A15Page_A15BtnTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var A15Btn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a/span"));
            Assert.AreEqual(A15Btn.Text, "A-15");
            Assert.IsTrue(A15Btn.Displayed);
            Assert.IsTrue(A15Btn.Enabled);
            var UrlBeforeClick = driver.Url;
            A15Btn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void A15Page_DataTableLengthTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"a15Details_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("a15Details_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void A15Page_DataTableFilterTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("a15Details_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"a15Details_filter\"]/label"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void A15Page_AssetClassParagraphTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/label"));
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);

            var assetClassInput = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/b"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.Text, "Facility");
        }

        [Test]
        public void A15Page_AssetSubClassDropdownlistTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);

            var selectedAssetSubClass = new SelectElement(assetSubClassValue);
            selectedAssetSubClass.SelectByIndex(0);
        }

        [Test]
        public void A15Page_AssetTypeDropdownlistTest()
        {
            // to open A15 page
            A15Page_OpenPage();

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
        public void A15Page_ReOrderTableTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var columns = driver.FindElements(By.Id("a15Details"));
            foreach( var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Enabled);
            Assert.IsTrue(RowNo.Displayed);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var FacilityId = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[2]"));
            Assert.IsTrue(FacilityId.Displayed);
            Assert.IsTrue(FacilityId.Enabled);
            Assert.AreEqual(FacilityId.Text, "Facility Id");
            Assert.AreEqual(FacilityId.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(FacilityId.GetAttribute("aria-label"), "Facility Id: activate to sort column ascending");
            //FacilityId.Click();

            var Name = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[3]"));
            Assert.IsTrue(Name.Displayed);
            Assert.IsTrue(Name.Enabled);
            Assert.AreEqual(Name.Text, "Name");
            Assert.AreEqual(Name.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(Name.GetAttribute("aria-label"), "Name: activate to sort column ascending");
            //Name.Click();

            var SectionOfLargerFacility = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[4]"));
            Assert.IsTrue(SectionOfLargerFacility.Displayed);
            Assert.IsTrue(SectionOfLargerFacility.Enabled);
            Assert.AreEqual(SectionOfLargerFacility.Text, "Section Of Larger Facility");
            Assert.AreEqual(SectionOfLargerFacility.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(SectionOfLargerFacility.GetAttribute("aria-label"), "Section Of Larger Facility: activate to sort column ascending");
            //SectionOfLargerFacility.Click();

            var Street = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[5]"));
            Assert.IsTrue(Street.Displayed);
            Assert.IsTrue(Street.Enabled);
            Assert.AreEqual(Street.Text, "Street");
            Assert.AreEqual(Street.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(Street.GetAttribute("aria-label"), "Street: activate to sort column ascending");
            //Street.Click();

            var City = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[6]"));
            Assert.IsTrue(City.Displayed);
            Assert.IsTrue(City.Enabled);
            Assert.AreEqual(City.Text, "City");
            Assert.AreEqual(City.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(City.GetAttribute("aria-label"), "City: activate to sort column ascending");
            //City.Click();

            var State = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[7]"));
            Assert.IsTrue(State.Displayed);
            Assert.IsTrue(State.Enabled);
            Assert.AreEqual(State.Text, "State");
            Assert.AreEqual(State.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(State.GetAttribute("aria-label"), "State: activate to sort column ascending");
            //State.Click();

            var Zip = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[8]"));
            Assert.IsTrue(Zip.Displayed);
            Assert.IsTrue(Zip.Enabled);
            Assert.AreEqual(Zip.Text, "Zip");
            Assert.AreEqual(Zip.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(Zip.GetAttribute("aria-label"), "Zip: activate to sort column ascending");
            //Zip.Click();

            var Lat = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[9]"));
            Assert.IsTrue(Lat.Displayed);
            Assert.IsTrue(Lat.Enabled);
            Assert.AreEqual(Lat.Text, "Lat");
            Assert.AreEqual(Lat.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(Lat.GetAttribute("aria-label"), "Lat: activate to sort column ascending");
            //Lat.Click();

            var Long = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[10]"));
            Assert.IsTrue(Zip.Displayed);
            Assert.IsTrue(Zip.Enabled);
            Assert.AreEqual(Zip.Text, "Zip");
            Assert.AreEqual(Zip.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(Zip.GetAttribute("aria-label"), "Zip: activate to sort column ascending");
            //Zip.Click();

            var ConditionAssessment = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[11]"));
            Assert.IsTrue(ConditionAssessment.Displayed);
            Assert.IsTrue(ConditionAssessment.Enabled);
            Assert.AreEqual(ConditionAssessment.Text, "Condition Assessment");
            Assert.AreEqual(ConditionAssessment.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(ConditionAssessment.GetAttribute("aria-label"), "Condition Assessment: activate to sort column ascending");
            //ConditionAssessment.Click();

            var ConditionAssessmentDate = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[12]"));
            Assert.IsTrue(ConditionAssessmentDate.Displayed);
            Assert.IsTrue(ConditionAssessmentDate.Enabled);
            Assert.AreEqual(ConditionAssessmentDate.Text, "Condition Assessment Date");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-label"), "Condition Assessment Date: activate to sort column ascending");
            //ConditionAssessmentDate.Click();

            var PrimaryMode = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[13]"));
            Assert.IsTrue(PrimaryMode.Displayed);
            Assert.IsTrue(PrimaryMode.Enabled);
            Assert.AreEqual(PrimaryMode.Text, "Primary Mode");
            Assert.AreEqual(PrimaryMode.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(PrimaryMode.GetAttribute("aria-label"), "Primary Mode: activate to sort column ascending");
            //PrimaryMode.Click();

            var NonAgencyMode = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[14]"));
            Assert.IsTrue(NonAgencyMode.Displayed);
            Assert.IsTrue(NonAgencyMode.Enabled);
            Assert.AreEqual(NonAgencyMode.Text, "Non Agency Mode");
            Assert.AreEqual(NonAgencyMode.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(NonAgencyMode.GetAttribute("aria-label"), "Non Agency Mode: activate to sort column ascending");
            //NonAgencyMode.Click();

            var SecondaryMode = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[15]"));
            Assert.IsTrue(SecondaryMode.Displayed);
            Assert.IsTrue(SecondaryMode.Enabled);
            Assert.AreEqual(SecondaryMode.Text, "Secondary Mode");
            Assert.AreEqual(SecondaryMode.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(SecondaryMode.GetAttribute("aria-label"), "Secondary Mode: activate to sort column ascending");
            //SecondaryMode.Click();

            var PrivateMode = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[16]"));
            Assert.IsTrue(PrivateMode.Displayed);
            Assert.IsTrue(PrivateMode.Enabled);
            Assert.AreEqual(PrivateMode.Text, "Private Mode");
            Assert.AreEqual(PrivateMode.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(PrivateMode.GetAttribute("aria-label"), "Private Mode: activate to sort column ascending");
            //PrivateMode.Click();

            var FacilityType = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[17]"));
            Assert.IsTrue(FacilityType.Displayed);
            Assert.IsTrue(FacilityType.Enabled);
            Assert.AreEqual(FacilityType.Text, "Facility Type");
            Assert.AreEqual(FacilityType.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(FacilityType.GetAttribute("aria-label"), "Facility Type: activate to sort column ascending");
            //FacilityType.Click();

            var YearBuiltOrReconstructed = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[18]"));
            Assert.IsTrue(YearBuiltOrReconstructed.Displayed);
            Assert.IsTrue(YearBuiltOrReconstructed.Enabled);
            Assert.AreEqual(YearBuiltOrReconstructed.Text, "Year Built Or Reconstructed");
            Assert.AreEqual(YearBuiltOrReconstructed.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(YearBuiltOrReconstructed.GetAttribute("aria-label"), "Year Built Or Reconstructed: activate to sort column ascending");
            //YearBuiltOrReconstructed.Click();

            var SquareFeet = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[19]"));
            Assert.IsTrue(SquareFeet.Displayed);
            Assert.IsTrue(SquareFeet.Enabled);
            Assert.AreEqual(SquareFeet.Text, "Square Feet");
            Assert.AreEqual(SquareFeet.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(SquareFeet.GetAttribute("aria-label"), "Square Feet: activate to sort column ascending");
            //SquareFeet.Click();

            var ParkingSpaces = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[20]"));
            Assert.IsTrue(ParkingSpaces.Displayed);
            Assert.IsTrue(ParkingSpaces.Enabled);
            Assert.AreEqual(ParkingSpaces.Text, "Parking Spaces");
            Assert.AreEqual(ParkingSpaces.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(ParkingSpaces.GetAttribute("aria-label"), "Parking Spaces: activate to sort column ascending");
            //ParkingSpaces.Click();

            var CapitalResponsibilityPct = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[21]"));
            Assert.IsTrue(CapitalResponsibilityPct.Displayed);
            Assert.IsTrue(CapitalResponsibilityPct.Enabled);
            Assert.AreEqual(CapitalResponsibilityPct.Text, "Capital Responsibility Pct");
            Assert.AreEqual(CapitalResponsibilityPct.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(CapitalResponsibilityPct.GetAttribute("aria-label"), "Capital Responsibility Pct: activate to sort column ascending");
            //CapitalResponsibilityPct.Click();

            var Notes = driver.FindElement(By.XPath("//*[@id=\"a15Details\"]/thead/tr/th[22]"));
            Assert.IsTrue(Notes.Displayed);
            Assert.IsTrue(Notes.Enabled);
            Assert.AreEqual(Notes.Text, "Notes");
            Assert.AreEqual(Notes.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(Notes.GetAttribute("aria-label"), "Notes: activate to sort column ascending");
            //Notes.Click();
        }

        [Test]
        public void A15Page_PaginateTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var previousBtn = driver.FindElement(By.Id("a15Details_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("a15Details_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            nextBtn.Click();
        }

        [Test]
        public void A15Page_ExportBtnTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void A30Page_SideLeftMinimizeToggle()
        {
            // to open A15 page
            A15Page_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}

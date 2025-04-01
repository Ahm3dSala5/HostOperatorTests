using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorFacilityAdminMaintFacilitiesTests : IDisposable
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
        public void AdminMaintFacilityPage_TestReportOption()
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
            Assert.AreEqual(reportOption.GetAttribute("href"),$"{URLAfterClick}#");
        }

        [Test]
        public void AdminMaintFacility_TestFacilityOption()
        {
            // to click on report option 
            AdminMaintFacilityPage_TestReportOption();

            var FacilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Assert.AreEqual(FacilityOption.Text, "Facility");
            Assert.AreEqual(FacilityOption.GetAttribute("custom-data"), "Facility");
            var currentUrl = driver.Url;
            Assert.AreEqual(FacilityOption.GetAttribute("href"), $"{currentUrl}#");
            Assert.IsTrue(FacilityOption.Displayed);
            Assert.IsTrue(FacilityOption.Enabled);
            FacilityOption.Click();
        }

        [Test]
        public void AdminMaintFaclittyPage_TestAdminMaintFacilityOption()
        {
            // to click on report option 
            AdminMaintFacilityPage_TestReportOption();
            // to click on equipment option
            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var adminMauntFacilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[2]/a"));
            Assert.AreEqual(adminMauntFacilityOption.GetAttribute("custom-data"), "Admin/Maint Facilities");
            var adminMaintFaclityURL = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/Facilities";
            Assert.AreEqual(adminMauntFacilityOption.GetAttribute("href"), $"{adminMaintFaclityURL}");
            Assert.IsTrue(adminMauntFacilityOption.Enabled);
            adminMauntFacilityOption.Click();
        }

        // to open page
        [Test]
        public void AdminMaintFacilityPage_OpenPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var adminMauntFacilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[2]/a"));
            adminMauntFacilityOption.Click();
        }

        [Test]
        public void AdminMaintFacilityPage_HiHostOperatorTest()
        {
            // to open admin maint faclility page
            AdminMaintFacilityPage_OpenPage();

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
        public void AdminMaintFaclilityPage_ServiceVehiclesPage_LogoutBtn()
        {
            // to open admin maint faclility page
            AdminMaintFacilityPage_OpenPage();

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
        public void AdminMaintFaclilityPage_NotificationTest()
        {
            // to open admin maint faclility page
            AdminMaintFacilityPage_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void AdminMaintFaclilityPage_TestPageTitle()
        {
            // to open admin maint faclility page
            AdminMaintFacilityPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Facilities");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void AdminMaintFacilityPage_ReportsBtnTest()
        {
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

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
        public void AdminMaintFaclilitiesPage_FacilityBtnTest()
        {
            // to open admin maint Facilites page
            AdminMaintFacilityPage_OpenPage();

            var facilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Assert.AreEqual(facilityOption.Text, "Facility");
            Assert.IsTrue(facilityOption.Displayed);
            Assert.IsTrue(facilityOption.Enabled);
            var UrlBeforeClick = driver.Url;
            facilityOption.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        // this button also must opne same page
        [Test]
        public void AdminMaintFacilitesPage_FacilitesBtnTest()
        {
            // to open admin maint Facilites page
            AdminMaintFacilityPage_OpenPage();

            var FacillitesBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.AreEqual(FacillitesBtn.Text, "Facilities");
            Assert.IsTrue(FacillitesBtn.Displayed);
            Assert.IsTrue(FacillitesBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            FacillitesBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void AdminMaintFacilitesPage_DataTableLengthTest()
        {
            // to open admin maint Facilites page
            AdminMaintFacilityPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"facilities_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("facilities_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void AdminMaintFacilitesPage_DataTableFilterTest()
        {
            // to open admin maint facilities page
            AdminMaintFacilityPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("facilities_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"facilities_filter\"]/label"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void AdminMainntFacilitesPage_AssetClassParagraphTest()
        {
            // to open admin maint facilities page
            AdminMaintFacilityPage_OpenPage();

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
        public void AdminMaintFacilitesPage_AssetSubClassParagraphTest()
        {
            // to open admin maint Facilites page
            AdminMaintFacilityPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Administrative/Maintenance Facilities");
        }

        [Test]
        public void AdminMaintBuildingsPage_AssetTypeParagraphTest()
        {
            // to open admin maint Facilites page
            AdminMaintFacilityPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            var assetTypeParagraph = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/b"));
            Assert.IsTrue(assetTypeParagraph.Enabled);
            Assert.IsTrue(assetTypeParagraph.Displayed);
            Assert.AreEqual(assetTypeParagraph.Text, "Administrative/Maintenance Facility");
        }

        [Test]
        public void AdminMaintFacilitesPage_ReOrderTableTest()
        {
            // to open admin maint Facilites page
            /////////////////////////////////////
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var adminMauntFacilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[2]/a"));
            adminMauntFacilityOption.Click();
            /////////////////////////////////////

            var columns = driver.FindElements(By.Id("facilities"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }
            
            var RowNo = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Displayed);
            Assert.IsTrue(RowNo.Enabled);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var FacilityId = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[2]"));
            Assert.IsTrue(FacilityId.Displayed);
            Assert.IsTrue(FacilityId.Enabled);
            Assert.AreEqual(FacilityId.Text, "Facility Id");
            Assert.AreEqual(FacilityId.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(FacilityId.GetAttribute("aria-label"), "Facility Id: activate to sort column ascending");
            //FacilityId.Click();

            var FacilityName = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[3]"));
            Assert.IsTrue(FacilityName.Displayed);
            Assert.IsTrue(FacilityName.Enabled);
            Assert.AreEqual(FacilityName.Text, "Facility Name");
            Assert.AreEqual(FacilityName.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(FacilityName.GetAttribute("aria-label"), "Facility Name: activate to sort column ascending");
            //FacilityName.Click();

            var Type = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[4]"));
            Assert.IsTrue(Type.Displayed);
            Assert.IsTrue(Type.Enabled);
            Assert.AreEqual(Type.Text, "Type");
            Assert.AreEqual(Type.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(Type.GetAttribute("aria-label"), "Type: activate to sort column ascending");
            //Type.Click();

            var StreetAddress = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[5]"));
            Assert.IsTrue(StreetAddress.Displayed);
            Assert.IsTrue(StreetAddress.Enabled);
            Assert.AreEqual(StreetAddress.Text, "Street Address");
            Assert.AreEqual(StreetAddress.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(StreetAddress.GetAttribute("aria-label"), "Street Address: activate to sort column ascending");
            //StreetAddress.Click();


            var City = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[6]"));
            Assert.IsTrue(City.Displayed);
            Assert.IsTrue(City.Enabled);
            Assert.AreEqual(City.Text, "City");
            Assert.AreEqual(City.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(City.GetAttribute("aria-label"), "City: activate to sort column ascending");
            //StreetAddress.Click();


            var State = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[7]"));
            Assert.IsTrue(State.Displayed);
            Assert.IsTrue(State.Enabled);
            Assert.AreEqual(State.Text, "State");
            Assert.AreEqual(State.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(State.GetAttribute("aria-label"), "State: activate to sort column ascending");
            //State.Click();

            var Zip = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[8]"));
            Assert.IsTrue(Zip.Displayed);
            Assert.IsTrue(Zip.Enabled);
            Assert.AreEqual(Zip.Text, "Zip");
            Assert.AreEqual(Zip.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(Zip.GetAttribute("aria-label"), "Zip: activate to sort column ascending");
            //Zip.Click();

            var YearBuiltOrReconstructed = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[9]"));
            Assert.IsTrue(YearBuiltOrReconstructed.Displayed);
            Assert.IsTrue(YearBuiltOrReconstructed.Enabled);
            Assert.AreEqual(YearBuiltOrReconstructed.Text, "Year Built Or Reconstructed");
            Assert.AreEqual(YearBuiltOrReconstructed.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(YearBuiltOrReconstructed.GetAttribute("aria-label"), "Year Built Or Reconstructed: activate to sort column ascending");
            //YearBuiltOrReconstructed.Click();

            var FacilityArea = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[10]"));
            Assert.IsTrue(FacilityArea.Displayed);
            Assert.IsTrue(FacilityArea.Enabled);
            Assert.AreEqual(FacilityArea.Text, "Facility Area");
            Assert.AreEqual(FacilityArea.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(FacilityArea.GetAttribute("aria-label"), "Facility Area: activate to sort column ascending");
            //FacilityArea.Click();

            var OverallCondition = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[11]"));
            Assert.IsTrue(OverallCondition.Displayed);
            Assert.IsTrue(OverallCondition.Enabled);
            Assert.AreEqual(OverallCondition.Text, "Overall Condition");
            Assert.AreEqual(OverallCondition.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(OverallCondition.GetAttribute("aria-label"), "Overall Condition: activate to sort column ascending");
            //OverallCondition.Click();

            var ConditionAssessmentDate = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[12]"));
            Assert.IsTrue(ConditionAssessmentDate.Displayed);
            Assert.IsTrue(ConditionAssessmentDate.Enabled);
            Assert.AreEqual(ConditionAssessmentDate.Text, "Condition Assessment Date");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-label"), "Condition Assessment Date: activate to sort column ascending");
            //ConditionAssessmentDate.Click();
        }

        [Test]
        public void adminMaintFacilityPage_PaginateTest()
        {
            // to open admin maint Facilities page
            AdminMaintFacilityPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("facilities_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("facilities_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            nextBtn.Click();
        }

        [Test]
        public void AdminMaintFacilitiesPage_ExportBtnTest()
        {
            // to open admin maint Facilities page
            AdminMaintFacilityPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void AdminMaintFacilitiesPage_SideLeftMinimizeToggle()
        {
            // to open admin maint Facilities page
            AdminMaintFacilityPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}

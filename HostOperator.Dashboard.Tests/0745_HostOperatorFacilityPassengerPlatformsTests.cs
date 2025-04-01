using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorFacilityPassengerPlatformsTests : IDisposable
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
        public void PassengerPlatformPage_TestReportOption()
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
        public void PassengerPlatformPage_TestFacilityOption()
        {
            // to click on report option 
            PassengerPlatformPage_TestReportOption();

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
        public void PassengerPlatformPage_TestPassengerPlatformOption()
        {
            // to click on report option 
            PassengerPlatformPage_TestReportOption();
            // to click on equipment option
            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var PassengerPlatformOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[5]/a"));
            Assert.AreEqual(PassengerPlatformOption.GetAttribute("custom-data"), "Passenger Platforms");
            var PassengerPlatformURL = "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/PassengerPlatforms";
            Assert.AreEqual(PassengerPlatformOption.GetAttribute("href"), $"{PassengerPlatformURL}");
            Assert.AreEqual(PassengerPlatformOption.GetAttribute("target"), "_self");
            Assert.IsTrue(PassengerPlatformOption.Enabled);
            PassengerPlatformOption.Click();
        }

        // to open page
        [Test]
        public void PassengerPlatformPage_OpenPage()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var PassengerBuildingsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[5]/a"));
            PassengerBuildingsOption.Click();
        }

        [Test]
        public void PassengerPlatformssPage_TableBarTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

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
        public void PassengerPlatformsPage_LogoutBtnTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

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
        public void PassengerPlatformsPage_NotificationTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var notificationIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[1]/a"));
            Assert.IsTrue(notificationIcon.Displayed);
            Assert.IsTrue(notificationIcon.Enabled);
            Assert.AreEqual(notificationIcon.GetAttribute("href"),
                "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Messages");
            notificationIcon.Click();
        }

        [Test]
        public void PassengerPlatformsPage_TestPageTitle()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var title = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Passenger Platforms");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void PassengerPlatformsPage_ReportBtnTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

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
        public void PassengerPlatformsPage_FacilityBtnTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var facilityBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Assert.AreEqual(facilityBtn.Text, "Facility");
            Assert.IsTrue(facilityBtn.Displayed);
            Assert.IsTrue(facilityBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            facilityBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        // this button also must opne same page
        [Test]
        public void PassengerPlatformsPage_PassengerPlatformssBtnTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var PassengerPlatformsBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a/span"));
            Assert.AreEqual(PassengerPlatformsBtn.Text, "Passenger Platforms");
            Assert.IsTrue(PassengerPlatformsBtn.Displayed);
            Assert.IsTrue(PassengerPlatformsBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            PassengerPlatformsBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void PassengerPlatformsPage_DataTableLengthTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("passengerPlatforms_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void PassengerPlatformsPage_DataTableFilterTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("passengerPlatforms_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"passengerPlatforms_filter\"]/label"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void PassengerPlatformsPage_AssetClassParagraphTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

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
        public void PassengerPlatformsPage_AssetSubClassParagraphTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Passenger Facilities");
        }

        [Test]
        public void PassengerPlatformsPage_AssetTypeParagraphTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);

            var assetTypeParagraph = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/b"));
            Assert.IsTrue(assetTypeParagraph.Enabled);
            Assert.IsTrue(assetTypeParagraph.Displayed);
            Assert.AreEqual(assetTypeParagraph.Text, "Rail Platform");
        }

        [Test]
        public void aAssengerPlatformsPage_ReOrderTableTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var rowNo = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[1]"));
            rowNo.Click();
            Assert.AreEqual(rowNo.Text, "Row No");
            Assert.IsTrue(rowNo.Displayed);
            Assert.IsTrue(rowNo.Enabled);

            var PlatformDesc = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[2]"));
            PlatformDesc.Click();
            Assert.AreEqual(PlatformDesc.Text, "Platform Desc");
            Assert.IsTrue(PlatformDesc.Displayed);
            Assert.IsTrue(PlatformDesc.Enabled);

            var ConditionAssessmentDate = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[3]"));
            ConditionAssessmentDate.Click();
            Assert.AreEqual(ConditionAssessmentDate.Text, "Condition Assessment Date");
            Assert.IsTrue(ConditionAssessmentDate.Displayed);
            Assert.IsTrue(ConditionAssessmentDate.Enabled);

            var StructureRating = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[4]"));
            StructureRating.Click();
            Assert.AreEqual(StructureRating.Text, "Structure Rating");
            Assert.IsTrue(StructureRating.Displayed);
            Assert.IsTrue(StructureRating.Enabled);

            var CanopyRating = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[5]"));
            CanopyRating.Click();
            Assert.AreEqual(CanopyRating.Text, "Canopy Rating");
            Assert.IsTrue(CanopyRating.Displayed);
            Assert.IsTrue(CanopyRating.Enabled);

            var ElectricalRating = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[6]"));
            ElectricalRating.Click();
            Assert.AreEqual(ElectricalRating.Text, "Electrical Rating");
            Assert.IsTrue(ElectricalRating.Displayed);
            Assert.IsTrue(ElectricalRating.Enabled);

            var StructureCost = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[7]"));
            StructureCost.Click();
            Assert.AreEqual(StructureCost.Text, "Structure Cost");
            Assert.IsTrue(StructureCost.Displayed);
            Assert.IsTrue(StructureCost.Enabled);

            var CanopyCost = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[8]"));
            CanopyCost.Click();
            Assert.AreEqual(CanopyCost.Text, "Canopy Cost");
            Assert.IsTrue(CanopyCost.Displayed);
            Assert.IsTrue(CanopyCost.Enabled);

            var ElectricalCost = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[9]"));
            ElectricalCost.Click();
            Assert.AreEqual(ElectricalCost.Text, "Electrical Cost");
            Assert.IsTrue(ElectricalCost.Displayed);
            Assert.IsTrue(ElectricalCost.Enabled);
        }

        [Test]
        public void PassengerPlatformsPage_PaginateTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("passengerPlatforms_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("passengerPlatforms_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);
            nextBtn.Click();
        }

        [Test]
        public void PassengerPlatformssPage_ExportBtnTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsTrue(exportBtn.Displayed);
            Assert.IsTrue(exportBtn.Enabled);
            exportBtn.Click();
        }

        [Test]
        public void PassengerPlatformsPage_SideLeftMinimizeToggle()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}

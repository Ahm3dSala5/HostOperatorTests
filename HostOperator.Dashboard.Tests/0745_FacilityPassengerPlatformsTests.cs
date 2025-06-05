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
        public void PassengerPlatformPage_ReportsOptionTest()
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
        public void PassengerPlatformPage_FacilityOptionTest()
        {
            // to click on report option 
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            Assert.IsTrue(facilityOption.Enabled);
            Assert.IsTrue(facilityOption.Displayed);
            Assert.AreEqual(facilityOption.Text, "Facility");
            Assert.AreEqual(facilityOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(facilityOption.GetAttribute("href"), $"{driver.Url}#");
            Assert.AreEqual(facilityOption.GetAttribute("custom-data"), "Facility");
            Assert.AreEqual(facilityOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var facilityOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a/i[2]"));
            Assert.IsTrue(facilityOptionArrow.Enabled);
            Assert.IsTrue(facilityOptionArrow.Displayed);
            Assert.AreEqual(facilityOptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var facilityOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a/i[1]"));
            Assert.IsTrue(facilityOptionIcon.Enabled);
            Assert.IsTrue(facilityOptionIcon.Displayed);
            Assert.AreEqual(facilityOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var facilityOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a/span/span"));
            Assert.IsTrue(facilityOptionText.Enabled);
            Assert.IsTrue(facilityOptionText.Displayed);
            Assert.AreEqual(facilityOptionText.Text, "Facility");
            Assert.AreEqual(facilityOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void PassengerPlatformPage_PassengerFacilitiesOptionTest()
        {
            var reportOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var passengerPlatformOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[5]/a"));
            Assert.IsTrue(passengerPlatformOption.Enabled);
            Assert.IsTrue(passengerPlatformOption.Displayed);
            Assert.AreEqual(passengerPlatformOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(passengerPlatformOption.GetAttribute("custom-data"), "Passenger Platforms");
            Assert.AreEqual(passengerPlatformOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(passengerPlatformOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/PassengerPlatforms");

            var passengerPlatformIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[5]/a/i"));
            Assert.IsTrue(passengerPlatformIcon.Enabled);
            Assert.IsTrue(passengerPlatformIcon.Displayed);
            Assert.AreEqual(passengerPlatformIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var passengerPlatformText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[5]/a/span/span"));
            Assert.IsTrue(passengerPlatformText.Enabled);
            Assert.IsTrue(passengerPlatformText.Displayed);
            Assert.AreEqual(passengerPlatformText.Text, "Passenger Platforms");
            Assert.AreEqual(passengerPlatformText.GetAttribute("class"), "title");
        }

        // to open page
        [Test]
        public void PassengerPlatformPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/PassengerPlatforms");
        }

        [Test]
        public void PassengerPlatformPage_TopUserNameTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

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
        public void PassengerPlatformPage_LogoutBtnTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.ClassName("m-topbar__username"));
            hiHostOperator.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Thread.Sleep(9000);
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("class"), "btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder");
        }

        [Test]
        public void PassengerPlatformPage_NotificationIconTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

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
        public void PassengerPlatformPage_SubHeaderTitleTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Passenger Platforms");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void PassengerPlatformsPage_ReportNaviationLinkTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var reportsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportsNavLink.Enabled);
            Assert.IsTrue(reportsNavLink.Displayed);
            Assert.AreEqual(reportsNavLink.Text, "Reports");
            Assert.AreEqual(reportsNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");
        }

        [Test]
        public void PassengerPlatformsPage_FacilityNavigationLinkTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var facilityNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(facilityNavLink.Enabled);
            Assert.IsTrue(facilityNavLink.Displayed);
            Assert.AreEqual(facilityNavLink.Text, "Facility");
            Assert.AreEqual(facilityNavLink.GetAttribute("class"), "m-nav__link");
        }

        // this button also must opne same page
        [Test]
        public void PassengerPlatformsPage_PassengerPlatformsNavigationLinkTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var passengerPlatformsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(passengerPlatformsNavLink.Enabled);
            Assert.IsTrue(passengerPlatformsNavLink.Displayed);
            Assert.AreEqual(passengerPlatformsNavLink.Text, "Passenger Platforms");
            Assert.AreEqual(passengerPlatformsNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void PassengerPlatformsPage_DataTableLengthTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("passengerPlatforms_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "passengerPlatforms");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void PassengerPlatformsPage_DataTableFilterTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("passengerPlatforms_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"passengerPlatforms_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "passengerPlatforms");
        }

        [Test]
        public void PassengerPlatformsPage_AssetClassDropdownListTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"),"form-label");

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
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"),"form-label");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"),"AssetSubClass");

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Passenger Facilities");
        }

        // this pice contains error in asset type label it must be linked with asset type label 
        // but it link with asset subclass
        [Test]
        public void PassengerPlatformsPage_AssetTypeParagraphTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("form"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeParagraph = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/b"));
            Assert.IsTrue(assetTypeParagraph.Enabled);
            Assert.IsTrue(assetTypeParagraph.Displayed);
            Assert.AreEqual(assetTypeParagraph.Text, "Rail Platform");
        }

        [Test]
        public void PassengerPlatformsPage_PassengerPlatformsTableTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var table = driver.FindElement(By.Id("passengerPlatforms"));
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "passengerPlatforms_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");

            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var rowNo = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[1]"));
            rowNo.Click();
            Assert.IsTrue(rowNo.Enabled);
            Assert.IsTrue(rowNo.Displayed);
            Assert.AreEqual(rowNo.Text, "Row No");
            Assert.AreEqual(rowNo.GetAttribute("class"), "sorting_asc");
            Assert.AreEqual(rowNo.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(rowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");

            var PlatformDesc = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[2]"));
            PlatformDesc.Click();
            Assert.IsTrue(PlatformDesc.Enabled);
            Assert.IsTrue(PlatformDesc.Displayed);
            Assert.AreEqual(PlatformDesc.Text, "Platform Desc");
            Assert.AreEqual(PlatformDesc.GetAttribute("class"), "sorting");
            Assert.AreEqual(PlatformDesc.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(PlatformDesc.GetAttribute("aria-label"), "Platform Desc: activate to sort column ascending");

            var ConditionAssessmentDate = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[3]"));
            ConditionAssessmentDate.Click();
            Assert.IsTrue(ConditionAssessmentDate.Enabled);
            Assert.IsTrue(ConditionAssessmentDate.Displayed);
            Assert.AreEqual(ConditionAssessmentDate.Text, "Condition Assessment Date");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("class"), "sorting");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(ConditionAssessmentDate.GetAttribute("aria-label"), "Condition Assessment Date: activate to sort column ascending");

            var StructureRating = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[4]"));
            StructureRating.Click();
            Assert.IsTrue(StructureRating.Enabled);
            Assert.IsTrue(StructureRating.Displayed);
            Assert.AreEqual(StructureRating.Text, "Structure Rating");
            Assert.AreEqual(StructureRating.GetAttribute("class"), "sorting");
            Assert.AreEqual(StructureRating.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(StructureRating.GetAttribute("aria-label"), "Structure Rating: activate to sort column ascending");

            var CanopyRating = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[5]"));
            CanopyRating.Click();
            Assert.IsTrue(CanopyRating.Enabled);
            Assert.IsTrue(CanopyRating.Displayed);
            Assert.AreEqual(CanopyRating.Text, "Canopy Rating");
            Assert.AreEqual(CanopyRating.GetAttribute("class"), "sorting");
            Assert.AreEqual(CanopyRating.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(CanopyRating.GetAttribute("aria-label"), "Canopy Rating: activate to sort column ascending");

            var ElectricalRating = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[6]"));
            ElectricalRating.Click();
            Assert.IsTrue(ElectricalRating.Enabled);
            Assert.IsTrue(ElectricalRating.Displayed);
            Assert.AreEqual(ElectricalRating.Text, "Electrical Rating");
            Assert.AreEqual(ElectricalRating.GetAttribute("class"), "sorting");
            Assert.AreEqual(ElectricalRating.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(ElectricalRating.GetAttribute("aria-label"), "Electrical Rating: activate to sort column ascending");

            var StructureCost = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[7]"));
            StructureCost.Click();
            Assert.IsTrue(StructureCost.Enabled);
            Assert.IsTrue(StructureCost.Displayed);
            Assert.AreEqual(StructureCost.Text, "Structure Cost");
            Assert.AreEqual(StructureCost.GetAttribute("class"), "sorting");
            Assert.AreEqual(StructureCost.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(StructureCost.GetAttribute("aria-label"), "Structure Cost: activate to sort column ascending");

            var CanopyCost = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[8]"));
            CanopyCost.Click();
            Assert.IsTrue(CanopyCost.Enabled);
            Assert.IsTrue(CanopyCost.Displayed);
            Assert.AreEqual(CanopyCost.Text, "Canopy Cost");
            Assert.AreEqual(CanopyCost.GetAttribute("class"), "sorting");
            Assert.AreEqual(CanopyCost.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(CanopyCost.GetAttribute("aria-label"), "Canopy Cost: activate to sort column ascending");

            var ElectricalCost = driver.FindElement(By.XPath("//*[@id=\"passengerPlatforms\"]/thead/tr/th[9]"));
            ElectricalCost.Click();
            Assert.IsTrue(ElectricalCost.Enabled);
            Assert.IsTrue(ElectricalCost.Displayed);
            Assert.AreEqual(ElectricalCost.Text, "Electrical Cost");
            Assert.AreEqual(ElectricalCost.GetAttribute("class"), "sorting");
            Assert.AreEqual(ElectricalCost.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(ElectricalCost.GetAttribute("aria-label"), "Electrical Cost: activate to sort column ascending");
        }

        [Test]
        public void PassengerPlatformsPage_PaginateTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("passengerPlatforms_previous"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("passengerPlatforms_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "passengerPlatforms");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();
        }

        [Test]
        public void PassengerPlatformssPage_ExportBtnTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
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

        [Test]
        public void PassengerPlatformPage_DataTableInfoTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("passengerPlatforms_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
        }

        [Test]
        public void PassengerPlatformPage_CopyRightTest()
        {
            // to open passenger Platforms page
            PassengerPlatformPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

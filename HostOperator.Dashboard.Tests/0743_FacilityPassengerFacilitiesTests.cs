using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorFacilityPassengerFacilitiesTests :IDisposable
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
        public void PassengerFacilitiesPage_ReportsOptionTest()
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
        public void PassengerFacilitiesPage_FacilityOptionTest()
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
        public void PassengerFacilitiesPage_PassengerFacilitiesOptionTest()
        {
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var passengerFacilitiesOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[4]/a"));
            Assert.IsTrue(passengerFacilitiesOption.Enabled);
            Assert.IsTrue(passengerFacilitiesOption.Displayed);
            Assert.AreEqual(passengerFacilitiesOption.Text, "Passenger ");
            Assert.AreEqual(passengerFacilitiesOption.GetAttribute("target"), "_self");
            Assert.AreEqual(passengerFacilitiesOption.GetAttribute("custom-data"), "Passenger Facilities");
            Assert.AreEqual(passengerFacilitiesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(passengerFacilitiesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/Facilities");

            var passengerFacilitiesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[4]/a/i"));
            Assert.IsTrue(passengerFacilitiesOptionIcon.Enabled);
            Assert.IsTrue(passengerFacilitiesOptionIcon.Displayed);
            Assert.AreEqual(passengerFacilitiesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var passengerFacilityOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[4]/a/span/span"));
            Assert.IsTrue(passengerFacilityOptionText.Enabled);
            Assert.IsTrue(passengerFacilityOptionText.Displayed);
            Assert.AreEqual(passengerFacilityOptionText.Text, "Admin/Maint Facilities");
            Assert.AreEqual(passengerFacilityOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void PassengerFacilitiesPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/PassengerFacilities");
        }

        [Test]
        public void PassengerFacilitiesPage_TopUserNameTest()
        {
            // to open  passenger Faclilities page
            PassengerFacilitiesPage_OpenPage();

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
        public void PassengerFacilitiesPage_LogoutBtnTest()
        {
            // to open  passenger Faclilities page
            PassengerFacilitiesPage_OpenPage();

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
        public void PassengerFacilitiesPage_NotificationIconTest()
        {
            // to open  passenger Faclilities page
            PassengerFacilitiesPage_OpenPage();

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
        public void PassengerFacilitiesPage_SubHeaderTitleTest()
        {
            // to open  passenger Faclilities page
            PassengerFacilitiesPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Passenger Facilities");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void PassengerFacilitiesPage_ReportNavigationLinkTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var reportNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportNavLink.Enabled);
            Assert.IsTrue(reportNavLink.Displayed);
            Assert.AreEqual(reportNavLink.Text, "Reports");
            Assert.AreEqual(reportNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(reportNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");
        }

        [Test]
        public void PassengerFacilitiesPage_Seperator1Test()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var Seperator = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text,">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void PassengerFacilitiesPage_FacilitiesNavigationLinkTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var facilityNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(facilityNavLink.Enabled);
            Assert.IsTrue(facilityNavLink.Displayed);
            Assert.AreEqual(facilityNavLink.Text, "Facility");
            Assert.NotNull(facilityNavLink.GetAttribute("href"));
            Assert.AreEqual(facilityNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void PassengerFacilitiesPage_Seperator2Test()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var Seperator = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[4]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text, ">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void PassengerFacilitiesPage_PassengerFacilitiesBtnTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var passengerPacilitiesNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(passengerPacilitiesNavLink.Enabled);
            Assert.IsTrue(passengerPacilitiesNavLink.Displayed);
            Assert.IsNotNull(passengerPacilitiesNavLink.GetAttribute("href"));
            Assert.AreEqual(passengerPacilitiesNavLink.Text, "Passenger Facilities");
            Assert.AreEqual(passengerPacilitiesNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void PassengerFacilitiesPage_DataTableLengthTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("passengerFacilities_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "passengerFacilities");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void PassengerFacilitesPage_DataTableFilterTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("passengerFacilities_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"passengerFacilities_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "passengerFacilities"); 
        }

        [Test]
        public void  PassengerFacilitesPage_AssetClassDropdownlistTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

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
        public void PassengerFacilitesPage_AssetSubClassDropdownlistTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

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

        // asset type label must linked with asset type
        // but it was linked with asset subclass
        [Test]
        public void PassengerFacilitiesPage_AssetTypeDropdownlistTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeParagraph = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/b"));
            Assert.IsTrue(assetTypeParagraph.Enabled);
            Assert.IsTrue(assetTypeParagraph.Displayed);
            Assert.AreEqual(assetTypeParagraph.Text, "Passenger Facility");
        }

        [Test]
        public void PassengerFacilitesPage_PassengerFacilityTableTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var table = driver.FindElement(By.Id("passengerFacilities"));
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "passengerFacilities_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");

            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Enabled);
            Assert.IsTrue(RowNo.Displayed);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //rowNo.Click();

            var FacilityId = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[2]"));
            Assert.IsTrue(FacilityId.Enabled);
            Assert.IsTrue(FacilityId.Displayed);
            Assert.AreEqual(FacilityId.Text, "Facility Id");
            Assert.AreEqual(FacilityId.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(FacilityId.GetAttribute("aria-label"), "Facility Id: activate to sort column ascending");
            //FacilityId.Click();

            var facilityName = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[3]"));
            Assert.IsTrue(facilityName.Enabled);
            Assert.IsTrue(facilityName.Displayed);
            Assert.AreEqual(facilityName.Text, "Facility Name");
            Assert.AreEqual(facilityName.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(facilityName.GetAttribute("aria-label"), "Facility Name: activate to sort column ascending");
            //facilityName.Click();

            var Type = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[4]"));
            Assert.IsTrue(Type.Enabled);
            Assert.IsTrue(Type.Displayed);
            Assert.AreEqual(Type.Text, "Type");
            Assert.AreEqual(Type.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(Type.GetAttribute("aria-label"), "Type: activate to sort column ascending");
            //Type.Click();

            var streatAddresss = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[5]"));
            Assert.IsTrue(streatAddresss.Enabled);
            Assert.IsTrue(streatAddresss.Displayed);
            Assert.AreEqual(streatAddresss.Text, "Street Address");
            Assert.AreEqual(streatAddresss.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(streatAddresss.GetAttribute("aria-label"), "Street Address: activate to sort column ascending");
            //streatAddresss.Click();

            var City = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[6]"));
            Assert.IsTrue(City.Enabled);
            Assert.IsTrue(City.Displayed);
            Assert.AreEqual(City.Text, "City");
            Assert.AreEqual(City.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(City.GetAttribute("aria-label"), "City: activate to sort column ascending");
            //City.Click();

            var state = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[7]"));
            Assert.IsTrue(state.Enabled);
            Assert.IsTrue(state.Displayed);
            Assert.AreEqual(state.Text, "State");
            Assert.AreEqual(state.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(state.GetAttribute("aria-label"), "State: activate to sort column ascending");
            //state.Click();

            var Zip = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[8]"));
            Assert.IsTrue(Zip.Enabled);
            Assert.IsTrue(Zip.Displayed);
            Assert.AreEqual(Zip.Text, "Zip");
            Assert.AreEqual(Zip.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(Zip.GetAttribute("aria-label"), "Zip: activate to sort column ascending");
            //Zip.Click();

            var YearBuiltOrReconstructed = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[9]"));
            Assert.IsTrue(YearBuiltOrReconstructed.Enabled); 
            Assert.IsTrue(YearBuiltOrReconstructed.Displayed);
            Assert.AreEqual(YearBuiltOrReconstructed.Text, "Year Built Or Reconstructed");
            Assert.AreEqual(YearBuiltOrReconstructed.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(YearBuiltOrReconstructed.GetAttribute("aria-label"), "Year Built Or Reconstructed: activate to sort column ascending");
            //YearBuiltOrReconstructed.Click();

            var FacilityArea = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[10]"));
            Assert.IsTrue(FacilityArea.Enabled);
            Assert.IsTrue(FacilityArea.Displayed);
            Assert.AreEqual(FacilityArea.Text, "Facility Area");
            Assert.AreEqual(FacilityArea.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(FacilityArea.GetAttribute("aria-label"), "Facility Area: activate to sort column ascending");
            //FacilityArea.Click();

            var OverallCondition = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[11]"));
            Assert.IsTrue(OverallCondition.Enabled);
            Assert.IsTrue(OverallCondition.Displayed);
            Assert.AreEqual(OverallCondition.Text, "Overall Condition");
            Assert.AreEqual(OverallCondition.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(OverallCondition.GetAttribute("aria-label"), "Overall Condition: activate to sort column ascending");
            //OverallCondition.Click();

            var condtionAssessmentDate = driver.FindElement(By.XPath("//*[@id=\"passengerFacilities\"]/thead/tr/th[12]"));
            Assert.IsTrue(condtionAssessmentDate.Enabled);
            Assert.IsTrue(condtionAssessmentDate.Displayed);
            Assert.AreEqual(condtionAssessmentDate.Text, "Condition Assessment Date");
            Assert.AreEqual(condtionAssessmentDate.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(condtionAssessmentDate.GetAttribute("aria-label"), "Condition Assessment Date: activate to sort column ascending");
            //condtionAssessmentDate.Click();
        }

        [Test]
        public void PassengerFacilitiesPage_PaginateTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("passengerFacilities_previous"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("passengerFacilities_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "passengerFacilities");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();

            var pages = driver.FindElements(By.Id("passengerFacilities_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Enabled);
                Assert.IsTrue(page.Displayed);
            }
        }

        [Test]
        public void PassengerFacilitiesPage_ExportBtnTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.IsNotNull(exportBtn.GetAttribute("href"));
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
            exportBtn.Click();
        }

        [Test]
        public void PassengerFacilitiessPage_SideLeftMinimizeToggle()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            sideLeft.Click();
        }

        [Test]
        public void PassengerFacilitiesPage_DataTableInfoTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("passengerFacilities_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
        }

        [Test]
        public void PassengerFacilitiesPage_CopyRightTest()
        {
            // to open passenger Facilities page
            PassengerFacilitiesPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

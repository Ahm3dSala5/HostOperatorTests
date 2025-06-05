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
        public void AdminMaintFacilitiesPage_ReportsOptionTest()
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
        public void AdminMaintFacilitiesPage_FacilityOptionTest()
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
        public void AdminMaintFacilitiesPage_AdminMaintFacilitiesOptionTest()
        {
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var facilityOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/a"));
            facilityOption.Click();

            var adminMaintFacilitiesOption = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[2]/a"));
            Assert.IsTrue(adminMaintFacilitiesOption.Enabled);
            Assert.IsTrue(adminMaintFacilitiesOption.Displayed);
            Assert.AreEqual(adminMaintFacilitiesOption.Text, "Admin/Maint Facilities");
            Assert.AreEqual(adminMaintFacilitiesOption.GetAttribute("target"), "_self");
            Assert.AreEqual(adminMaintFacilitiesOption.GetAttribute("custom-data"), "Admin/Maint Facilities");
            Assert.AreEqual(adminMaintFacilitiesOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(adminMaintFacilitiesOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/Facilities");

            var adminMaintFacilitiesOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[2]/a/i"));
            Assert.IsTrue(adminMaintFacilitiesOptionIcon.Enabled);
            Assert.IsTrue(adminMaintFacilitiesOptionIcon.Displayed);
            Assert.AreEqual(adminMaintFacilitiesOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var adminMaintFacilitiesOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[4]/nav/ul/li[2]/a/span/span"));
            Assert.IsTrue(adminMaintFacilitiesOptionText.Enabled);
            Assert.IsTrue(adminMaintFacilitiesOptionText.Displayed);
            Assert.AreEqual(adminMaintFacilitiesOptionText.Text, "Admin/Maint Facilities");
            Assert.AreEqual(adminMaintFacilitiesOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void AdminMaintFacilityPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/Facilities");
        }

        [Test]
        public void AdminMaintFacilityPage_TopUserNameTest()
        {
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

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
        public void AdminMaintFacilityPage_LogoutBtnTest()
        {
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

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
        public void AdminMaintFacilityPage_NotificationIconTest()
        {
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

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
        public void AdminMaintFacilityPage_SubHeaderTitleTest()
        {
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Facilities");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void AdminMaintFacilityPage_ReportsNavigationLinkTest()
        {
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

            var reportsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportsNavLink.Enabled);
            Assert.IsTrue(reportsNavLink.Displayed);
            Assert.AreEqual(reportsNavLink.Text, "Reports");
            Assert.AreEqual(reportsNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void AdminMaintFacilityPage_Seperator1Test()
        { 
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

            var Seperator = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text, ">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AdminMaintFacilityPage_FacilityNavigationLinkTest()
        {
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

            var facilityNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(facilityNavLink.Enabled);
            Assert.IsTrue(facilityNavLink.Displayed);
            Assert.AreEqual(facilityNavLink.Text, "Facility");
            Assert.AreEqual(facilityNavLink.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            facilityNavLink.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void AdminMaintFacilityPage_Seperator2Test()
        {
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

            var Seperator = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[4]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text, ">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void AdminMaintFacilityPage_FacilitiesNavigationLinkTest()
        {
            // to open admin maint Faclilities page
            AdminMaintFacilityPage_OpenPage();

            var facilitiesNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(facilitiesNavLink.Enabled);
            Assert.IsTrue(facilitiesNavLink.Displayed);
            Assert.AreEqual(facilitiesNavLink.Text, "Facilities");
            Assert.AreEqual(facilitiesNavLink.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            facilitiesNavLink.Click();
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
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("facilities_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "facilities");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void AdminMaintFacilitesPage_DataTableFilterTest()
        {
            // to open admin maint facilities page
            AdminMaintFacilityPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("facilities_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"facilities_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "facilities");
        }

        [Test]
        public void AdminMainntFacilitesPage_AssetClassParagraphTest()
        {
            // to open admin maint facilities page
            AdminMaintFacilityPage_OpenPage();

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
        public void AdminMaintFacilitesPage_AssetSubClassParagraphTest()
        {
            // to open admin maint Facilites page
            AdminMaintFacilityPage_OpenPage();

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
            Assert.AreEqual(assetSubClassValue.Text, "Administrative/Maintenance Facilities");
        }
        
        // this pice contains error in asset type label
        // it should be Asset Type not Asset Class
        [Test]
        public void AdminMaintFacilitiesPage_AssetTypeParagraphTest()
        {
            // to open admin maint Facilites page
            AdminMaintFacilityPage_OpenPage();

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
            Assert.AreEqual(assetTypeParagraph.Text, "Administrative/Maintenance Facility");
        }

        [Test]
        public void AdminMaintFacilitesPage_AdminMaintFacilitiesTableTest()
        {
            // to open admin maint Facilites page
            AdminMaintFacilityPage_OpenPage();

            var table = driver.FindElement(By.Id("facilities"));
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "facilities_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");

            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }
            
            var RowNo = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Enabled);
            Assert.IsTrue(RowNo.Displayed);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var FacilityId = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[2]"));
            Assert.IsTrue(FacilityId.Enabled);
            Assert.IsTrue(FacilityId.Displayed);
            Assert.AreEqual(FacilityId.Text, "Facility Id");
            Assert.AreEqual(FacilityId.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(FacilityId.GetAttribute("aria-label"), "Facility Id: activate to sort column ascending");
            //FacilityId.Click();

            var FacilityName = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[3]"));
            Assert.IsTrue(FacilityName.Enabled);
            Assert.IsTrue(FacilityName.Displayed);
            Assert.AreEqual(FacilityName.Text, "Facility Name");
            Assert.AreEqual(FacilityName.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(FacilityName.GetAttribute("aria-label"), "Facility Name: activate to sort column ascending");
            //FacilityName.Click();

            var Type = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[4]"));
            Assert.IsTrue(Type.Enabled);
            Assert.IsTrue(Type.Displayed);
            Assert.AreEqual(Type.Text, "Type");
            Assert.AreEqual(Type.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(Type.GetAttribute("aria-label"), "Type: activate to sort column ascending");
            //Type.Click();

            var StreetAddress = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[5]"));
            Assert.IsTrue(StreetAddress.Enabled);
            Assert.IsTrue(StreetAddress.Displayed);
            Assert.AreEqual(StreetAddress.Text, "Street Address");
            Assert.AreEqual(StreetAddress.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(StreetAddress.GetAttribute("aria-label"), "Street Address: activate to sort column ascending");
            //StreetAddress.Click();


            var City = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[6]"));
            Assert.IsTrue(City.Enabled);
            Assert.IsTrue(City.Displayed);
            Assert.AreEqual(City.Text, "City");
            Assert.AreEqual(City.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(City.GetAttribute("aria-label"), "City: activate to sort column ascending");
            //StreetAddress.Click();


            var State = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[7]"));
            Assert.IsTrue(State.Enabled);
            Assert.IsTrue(State.Displayed);
            Assert.AreEqual(State.Text, "State");
            Assert.AreEqual(State.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(State.GetAttribute("aria-label"), "State: activate to sort column ascending");
            //State.Click();

            var Zip = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[8]"));
            Assert.IsTrue(Zip.Enabled);
            Assert.IsTrue(Zip.Displayed);
            Assert.AreEqual(Zip.Text, "Zip");
            Assert.AreEqual(Zip.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(Zip.GetAttribute("aria-label"), "Zip: activate to sort column ascending");
            //Zip.Click();

            var YearBuiltOrReconstructed = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[9]"));
            Assert.IsTrue(YearBuiltOrReconstructed.Enabled);
            Assert.IsTrue(YearBuiltOrReconstructed.Displayed);
            Assert.AreEqual(YearBuiltOrReconstructed.Text, "Year Built Or Reconstructed");
            Assert.AreEqual(YearBuiltOrReconstructed.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(YearBuiltOrReconstructed.GetAttribute("aria-label"), "Year Built Or Reconstructed: activate to sort column ascending");
            //YearBuiltOrReconstructed.Click();

            var FacilityArea = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[10]"));
            Assert.IsTrue(FacilityArea.Enabled);
            Assert.IsTrue(FacilityArea.Displayed);
            Assert.AreEqual(FacilityArea.Text, "Facility Area");
            Assert.AreEqual(FacilityArea.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(FacilityArea.GetAttribute("aria-label"), "Facility Area: activate to sort column ascending");
            //FacilityArea.Click();

            var OverallCondition = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[11]"));
            Assert.IsTrue(OverallCondition.Enabled);
            Assert.IsTrue(OverallCondition.Displayed);
            Assert.AreEqual(OverallCondition.Text, "Overall Condition");
            Assert.AreEqual(OverallCondition.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(OverallCondition.GetAttribute("aria-label"), "Overall Condition: activate to sort column ascending");
            //OverallCondition.Click();

            var ConditionAssessmentDate = driver.FindElement(By.XPath("//*[@id=\"facilities\"]/thead/tr/th[12]"));
            Assert.IsTrue(ConditionAssessmentDate.Enabled);
            Assert.IsTrue(ConditionAssessmentDate.Displayed);
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
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("facilities_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "facilities");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();
        }

        [Test]
        public void AdminMaintFacilitiesPage_ExportBtnTest()
        {
            // to open admin maint Facilities page
            AdminMaintFacilityPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
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

        [Test]
        public void AdminMaintFacilityPage_DataTableInfoTest()
        {
            // to open admin maint Facilities page
            AdminMaintFacilityPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("facilities_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
        }

        [Test]
        public void AdminMaintFacilityPage_CopyRightTest()
        {
            // to open admin maint Facilities page
            AdminMaintFacilityPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

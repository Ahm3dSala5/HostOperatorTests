using OpenQA.Selenium;
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
        public void A15Page_ReportsOptionTest()
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
        public void A15Page_NTDOptionTest()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            Assert.IsTrue(NTDOption.Enabled);
            Assert.IsTrue(NTDOption.Displayed);
            Assert.AreEqual(NTDOption.Text,"NTD");
            Assert.AreEqual(NTDOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(NTDOption.GetAttribute("custom-data"),"NTD");
            Assert.AreEqual(NTDOption.GetAttribute("href"),$"{driver.Url}#");
            Assert.AreEqual(NTDOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var NTDOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a/i[1]"));
            Assert.IsTrue(NTDOptionIcon.Enabled);
            Assert.IsTrue(NTDOptionIcon.Displayed);
            Assert.AreEqual(NTDOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var NTDOptionArrwo = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a/i[2]"));
            Assert.IsTrue(NTDOptionArrwo.Enabled);
            Assert.IsTrue(NTDOptionArrwo.Displayed);
            Assert.AreEqual(NTDOptionArrwo.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var NTDOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a/span/span"));
            Assert.IsTrue(NTDOptionText.Enabled);
            Assert.IsTrue(NTDOptionText.Displayed);
            Assert.AreEqual(NTDOptionText.Text,"NTD");
            Assert.AreEqual(NTDOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void A15Page_A15OptionTest()
        {
            var reportOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();
            var NTDOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var A15Option = driver.FindElement(By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[1]/a"));
            Assert.IsTrue(A15Option.Enabled);
            Assert.IsTrue(A15Option.Displayed);
            Assert.AreEqual(A15Option.Text,"A-15");
            Assert.AreEqual(A15Option.GetAttribute("target"),"_self");
            Assert.AreEqual(A15Option.GetAttribute("role"),"menuitem");
            Assert.AreEqual(A15Option.GetAttribute("custom-data"),"A-15");
            Assert.AreEqual(A15Option.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(A15Option.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/A15Details");

            var A15OptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[1]/a/i"));
            Assert.IsTrue(A15OptionIcon.Enabled);
            Assert.IsTrue(A15OptionIcon.Displayed);
            Assert.AreEqual(A15OptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var A15OptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[1]/a/span/span"));
            Assert.IsTrue(A15OptionText.Enabled);
            Assert.IsTrue(A15OptionText.Displayed);
            Assert.AreEqual(A15OptionText.Text,"A-15");
            Assert.AreEqual(A15OptionText.GetAttribute("class"),"title");
        }

        // to open page
        [Test]
        public void A15Page_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/A15Details");
        }

        [Test]
        public void A15Page_TopUserNameTest()
        {
            // to open A15 page
            A15Page_OpenPage();

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
        public void A15Page_LogoutBtnTest()
        {
            // to open A15 page
            A15Page_OpenPage();

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
        public void A15Page_NotificationIconTest()
        {
            // to open A15 page
            A15Page_OpenPage();

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
        public void A15Page_SubHeaderTitleTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "A-15");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void A15Page_ReportNavigationLinkTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var reportsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportsNavLink.Enabled);
            Assert.IsTrue(reportsNavLink.Displayed);
            Assert.AreEqual(reportsNavLink.Text, "Reports");
            Assert.AreEqual(reportsNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(reportsNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");
        }

        [Test]
        public void A15Page_SeperatorTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var Seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text,">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        // must be enabled and when click must open same page
        [Test]
        public void A30Page_NTDNavigationLinkTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var NTDNavLink = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(NTDNavLink.Enabled);
            Assert.IsTrue(NTDNavLink.Displayed);
            Assert.AreEqual(NTDNavLink.Text, "NTD");
            Assert.AreEqual(NTDNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void A15Page_Seperator2Test()
        {
            // to open A15 page
            A15Page_OpenPage();

            var Seperator = driver.FindElement
               (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[4]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text, ">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        // this button also must opne same page
        [Test]
        public void A15Page_A15BNavigationLinkTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var A15NavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(A15NavLink.Enabled);
            Assert.IsTrue(A15NavLink.Displayed);
            Assert.AreEqual(A15NavLink.Text, "A-15");
            Assert.AreEqual(A15NavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void A15Page_DataTableLengthTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"a15Details_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("a15Details_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "a15Details");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void A15Page_DataTableFilterTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("a15Details_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"a15Details_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "a15Details");
        }

        [Test]
        public void A15Page_AssetClassDropdownlistTest()
        {
            // to open A15 page
            A15Page_OpenPage();

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
        public void A15Page_AssetSubClassDropdownlistTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"),"form-label");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"),"AssetSubClass");

            var assetSubClassValue = driver.FindElement
                (By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.GetAttribute("class"),"form-control");

            var selectedAssetSubClass = new SelectElement(assetSubClassValue);
            selectedAssetSubClass.SelectByIndex(0);

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetSubClassDropDownChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Select Asset Subclass");
        }

        [Test]
        public void A15Page_AssetTypeDropdownlistTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeValue = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            Assert.AreEqual(assetTypeValue.GetAttribute("class"),"form-control");

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Select Asset Type");
        }

        [Test]
        public void A15Page_A15TableTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var table = driver.FindElement(By.Id("a15Details"));
            Assert.IsNotNull(table);
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "a15Details_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");

            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach( var column in columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
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
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("a15Details_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "a15Details");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();
        }

        [Test]
        public void A15Page_ExportBtnTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
            exportBtn.Click();
        }

        [Test]
        public void A30Page_SideLeftMinimizeToggle()
        {
            // to open A15 page
            A15Page_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            sideLeft.Click();
        }

        [Test]
        public void A15Pag_DataTableInfoTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var tableInfo = driver.FindElement(By.Id("a15Details_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
        }

        [Test]
        public void A15Pag_CopyRightTest()
        {
            // to open A15 page
            A15Page_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

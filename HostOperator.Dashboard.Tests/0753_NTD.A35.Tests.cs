using System.Xml.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Script;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V130.Network;
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
        public void A30Page_ReportsOptionTest()
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
        public void A30Page_NTDOptionTest()
        {
            var reportOption = driver.FindElement
              (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            Assert.IsTrue(NTDOption.Enabled);
            Assert.IsTrue(NTDOption.Displayed);
            Assert.AreEqual(NTDOption.Text, "NTD");
            Assert.AreEqual(NTDOption.GetAttribute("role"), "menuitem");
            Assert.AreEqual(NTDOption.GetAttribute("custom-data"), "NTD");
            Assert.AreEqual(NTDOption.GetAttribute("href"), $"{driver.Url}#");
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
            Assert.AreEqual(NTDOptionText.Text, "NTD");
            Assert.AreEqual(NTDOptionText.GetAttribute("class"), "title");
        }

        [Test]
        public void A35Page_A35OptionTest()
        {
            var reportOption = driver.FindElement
             (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var NTDOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/a"));
            NTDOption.Click();

            var a35Option = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[3]/a"));
            Assert.IsTrue(a35Option.Enabled);
            Assert.IsTrue(a35Option.Displayed);
            Assert.AreEqual(a35Option.Text, "A-35");
            Assert.AreEqual(a35Option.GetAttribute("target"), "_self");
            Assert.AreEqual(a35Option.GetAttribute("role"),"menuitem");
            Assert.AreEqual(a35Option.GetAttribute("custom-data"), "A-35");
            Assert.AreEqual(a35Option.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(a35Option.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/A35Details");

            var a35OptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[3]/a/i"));
            Assert.IsTrue(a35OptionIcon.Enabled);
            Assert.IsTrue(a35OptionIcon.Displayed);
            Assert.AreEqual(a35OptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var a35OptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[5]/nav/ul/li[3]/a/span/span"));
            Assert.IsTrue(a35OptionText.Enabled);
            Assert.IsTrue(a35OptionText.Displayed);
            Assert.AreEqual(a35OptionText.Text,"A-35");
            Assert.AreEqual(a35OptionText.GetAttribute("class"),"title");
        }

        // to open page
        [Test]
        public void A35Page_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/A35Details");
        }

        [Test]
        public void A35Pag_TopUserNameTest()
        {
            // to open A35 page
            A35Page_OpenPage();

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
        public void A35Pag_LogoutBtnTest()
        {
            // to open A35 page
            A35Page_OpenPage();

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
        public void A35Pag_NotificationIconTest()
        {
            // to open A35 page
            A35Page_OpenPage();

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
        public void A35Page_SubHeaderTitleTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "A-35");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void A35Page_ReportsNavigationLink()
        {
            // to open A35 page
            A35Page_OpenPage();

            var reportsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportsNavLink.Enabled);
            Assert.IsTrue(reportsNavLink.Displayed);
            Assert.AreEqual(reportsNavLink.Text, "Reports");
            Assert.AreEqual(reportsNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(reportsNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/");

        }

        // must be enabled and when click must open same page
        [Test]
        public void A35_NTDNavigationLinkTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var NTDNavLink = driver.FindElement
                  (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(NTDNavLink.Enabled);
            Assert.IsTrue(NTDNavLink.Displayed);
            Assert.AreEqual(NTDNavLink.Text, "NTD");
            Assert.AreEqual(NTDNavLink.GetAttribute("class"), "m-nav__link");
        }

        // this button also must opne same page
        [Test]
        public void A35Page_A35NavigationLinkTest()
        {
            // to open A30 page
            A35Page_OpenPage();

            var A15NavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(A15NavLink.Enabled);
            Assert.IsTrue(A15NavLink.Displayed);
            Assert.AreEqual(A15NavLink.Text, "A-35");
            Assert.AreEqual(A15NavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void A35Page_DataTableLengthTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"a35Details_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("a35Details_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "a35Details");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void A35Page_DataTableFilterTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("a35Details_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"a35Details_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "a35Details");
        }

        [Test]
        public void A35Page_AssetClassDropdownlistTest()
        {
            // to open A35 page
            A35Page_OpenPage();

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
            Assert.AreEqual(assetClassInput.Text, "Equipment");
        }

        [Test]
        public void A35Page_AssetSubClassDropdownlistTest()
        {
            // to open A35 page
            A35Page_OpenPage();

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
            Assert.AreEqual(assetSubClassValue.Text, "Service Vehicles");
        }

        [Test]
        public void A35Page_AssetTypeDropdownlistTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeValue = driver.FindElement
            (By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            Assert.AreEqual(assetTypeValue.GetAttribute("class"),"form-controls");

            var selectedAssetSubClass = new SelectElement(assetTypeValue);
            selectedAssetSubClass.SelectByIndex(0);

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"Select Asser Type");
        }

        [Test]
        public void A35Page_ReOrderTableTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var table = driver.FindElement(By.Id("a35Details"));
            Assert.IsNotNull(table);
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "a35Details_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");


            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach(var column in columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Enabled);
            Assert.IsTrue(RowNo.Displayed);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var NTDId = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[2]"));
            Assert.IsTrue(NTDId.Enabled);
            Assert.IsTrue(NTDId.Displayed);
            Assert.AreEqual(NTDId.Text, "NTD Id");
            Assert.AreEqual(NTDId.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(NTDId.GetAttribute("aria-label"), "NTD Id: activate to sort column ascending");
            //NTDId.Click();

            var FleetId = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[3]"));
            Assert.IsTrue(FleetId.Enabled);
            Assert.IsTrue(FleetId.Displayed);
            Assert.AreEqual(FleetId.Text, "Fleet Id");
            Assert.AreEqual(FleetId.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(FleetId.GetAttribute("aria-label"), "Fleet Id: activate to sort column ascending");
            //FleetId.Click(); 

            var FleetName = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[4]"));
            Assert.IsTrue(FleetName.Enabled);
            Assert.IsTrue(FleetName.Displayed);
            Assert.AreEqual(FleetName.Text, "Fleet Name");
            Assert.AreEqual(FleetName.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(FleetName.GetAttribute("aria-label"), "Fleet Name: activate to sort column ascending");
            //FleetName.Click(); 

            var VehicleType = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[5]"));
            Assert.IsTrue(VehicleType.Enabled);
            Assert.IsTrue(VehicleType.Displayed);
            Assert.AreEqual(VehicleType.Text, "Vehicle Type");
            Assert.AreEqual(VehicleType.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(VehicleType.GetAttribute("aria-label"), "Vehicle Type: activate to sort column ascending");
            //VehicleType.Click(); 

            var PrimaryMode = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[6]"));
            Assert.IsTrue(VehicleType.Enabled);
            Assert.IsTrue(PrimaryMode.Displayed);
            Assert.AreEqual(PrimaryMode.Text, "Primary Mode");
            Assert.AreEqual(PrimaryMode.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(PrimaryMode.GetAttribute("aria-label"), "Primary Mode: activate to sort column ascending");
            //PrimaryMode.Click(); 

            var YearManufactured = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[7]"));
            Assert.IsTrue(YearManufactured.Enabled);
            Assert.IsTrue(YearManufactured.Displayed);
            Assert.AreEqual(YearManufactured.Text, "Year Manufactured");
            Assert.AreEqual(YearManufactured.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(YearManufactured.GetAttribute("aria-label"), "Year Manufactured: activate to sort column ascending");
            //YearManufactured.Click(); 

            var EstimatedCost = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[8]"));
            Assert.IsTrue(EstimatedCost.Enabled);
            Assert.IsTrue(EstimatedCost.Displayed);
            Assert.AreEqual(EstimatedCost.Text, "Estimated Cost");
            Assert.AreEqual(EstimatedCost.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(EstimatedCost.GetAttribute("aria-label"), "Estimated Cost: activate to sort column ascending");
            //EstimatedCost.Click(); 

            var UsefulLifeBenchmark = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[9]"));
            Assert.IsTrue(UsefulLifeBenchmark.Enabled);
            Assert.IsTrue(UsefulLifeBenchmark.Displayed);
            Assert.AreEqual(UsefulLifeBenchmark.Text, "Useful Life Benchmark");
            Assert.AreEqual(UsefulLifeBenchmark.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(UsefulLifeBenchmark.GetAttribute("aria-label"), "Useful Life Benchmark: activate to sort column ascending");
            //UsefulLifeBenchmark.Click(); 

            var UsefulLifeRemaining = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[10]"));
            Assert.IsTrue(UsefulLifeRemaining.Enabled);
            Assert.IsTrue(UsefulLifeRemaining.Displayed);
            Assert.AreEqual(UsefulLifeRemaining.Text, "Useful Life Remaining");
            Assert.AreEqual(UsefulLifeRemaining.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(UsefulLifeRemaining.GetAttribute("aria-label"), "Useful Life Remaining: activate to sort column ascending");
            //UsefulLifeRemaining.Click(); 

            var TransitAgencyCapitalResponsibility = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[11]"));
            Assert.IsTrue(TransitAgencyCapitalResponsibility.Enabled);
            Assert.IsTrue(TransitAgencyCapitalResponsibility.Displayed);
            Assert.AreEqual(TransitAgencyCapitalResponsibility.Text, "Transit Agency Capital Responsibility");
            Assert.AreEqual(TransitAgencyCapitalResponsibility.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(TransitAgencyCapitalResponsibility.GetAttribute("aria-label"), "Transit Agency Capital Responsibility: activate to sort column ascending");
            //TransitAgencyCapitalResponsibility.Click(); 

            var YearDollarsEstimatedCost = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[12]"));
            Assert.IsTrue(YearDollarsEstimatedCost.Enabled);
            Assert.IsTrue(YearDollarsEstimatedCost.Displayed);
            Assert.AreEqual(YearDollarsEstimatedCost.Text, "Year Dollars Estimated Cost");
            Assert.AreEqual(YearDollarsEstimatedCost.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(YearDollarsEstimatedCost.GetAttribute("aria-label"), "Year Dollars Estimated Cost: activate to sort column ascending");
            //YearDollarsEstimatedCost.Click(); 

            var SecondaryMode = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[13]"));
            Assert.IsTrue(SecondaryMode.Enabled);
            Assert.IsTrue(SecondaryMode.Displayed);
            Assert.AreEqual(SecondaryMode.Text, "Secondary Mode");
            Assert.AreEqual(SecondaryMode.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(SecondaryMode.GetAttribute("aria-label"), "Secondary Mode: activate to sort column ascending");
            //SecondaryMode.Click(); 

            var Notes = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[14]"));
            Assert.IsTrue(Notes.Enabled);
            Assert.IsTrue(Notes.Displayed);
            Assert.AreEqual(Notes.Text, "Notes");
            Assert.AreEqual(Notes.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(Notes.GetAttribute("aria-label"), "Notes: activate to sort column ascending");
            
            //Notes.Click(); 
            var Status = driver.FindElement(By.XPath("//*[@id=\"a35Details\"]/thead/tr/th[15]"));
            Assert.IsTrue(Status.Enabled);
            Assert.IsTrue(Status.Displayed);
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
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("a35Details_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "a35Details");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();
        }

        [Test]
        public void A35Page_ExportBtnTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
            exportBtn.Click();
        }

        [Test]
        public void A35Page_SideLeftMinimizeToggle()
        {
            // to open A35 page
            A35Page_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            sideLeft.Click();
        }

        [Test]
        public void A35Page_DataTableInfoTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var tableInfo = driver.FindElement(By.Id("a35Details_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && tableInfo.Text.Contains("entries"));
        }

        [Test]
        public void A35Page_CopyRightTest()
        {
            // to open A35 page
            A35Page_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

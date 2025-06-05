using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorOhterEquipmentTests : IDisposable
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
        public void OtherEquipmentsPage_ReportsOptionTest()
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
        public void OtherEquipmentPage_EquipmentOptionTest()
        {
            // to click on report option 
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var equipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            Assert.IsTrue(equipmentOption.Enabled);
            Assert.IsTrue(equipmentOption.Displayed);
            Assert.AreEqual(equipmentOption.Text, "Equipment");
            Assert.AreEqual(equipmentOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(equipmentOption.GetAttribute("href"),$"{driver.Url}#");
            Assert.AreEqual(equipmentOption.GetAttribute("custom-data"), "Equipment");
            Assert.AreEqual(equipmentOption.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var equipmentOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a/i[2]"));
            Assert.IsTrue(equipmentOptionArrow.Enabled);
            Assert.IsTrue(equipmentOptionArrow.Displayed);
            Assert.AreEqual(equipmentOptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var equipmentOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a/i[1]"));
            Assert.IsTrue(equipmentOptionIcon.Enabled);
            Assert.IsTrue(equipmentOptionIcon.Displayed);
            Assert.AreEqual(equipmentOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var equipmentOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a/span/span"));
            Assert.IsTrue(equipmentOptionText.Enabled);
            Assert.IsTrue(equipmentOptionText.Displayed);
            Assert.AreEqual(equipmentOptionText.Text,"Equipment");
            Assert.AreEqual(equipmentOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void OtherEquipemtnPage_OtherEquipmentOptionTest()
        {
            // to click on report option 
            var reportOption = driver.FindElement
                 (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/a"));
            reportOption.Click();

            var equipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/a"));
            equipmentOption.Click();

            var otherEquipmentOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[1]/a"));
            Assert.IsTrue(otherEquipmentOption.Enabled);
            Assert.IsTrue(otherEquipmentOption.Displayed);
            Assert.AreEqual(otherEquipmentOption.Text, "Other Equipment");
            Assert.AreEqual(otherEquipmentOption.GetAttribute("target"), "_self");
            Assert.AreEqual(otherEquipmentOption.GetAttribute("custom-data"), "Other Equipment");
            Assert.AreEqual(otherEquipmentOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(otherEquipmentOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/OtherEquipmentDetails");

            var otherEquipmentOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[1]/a/i"));
            Assert.IsTrue(otherEquipmentOptionIcon.Enabled);
            Assert.IsTrue(otherEquipmentOptionIcon.Displayed);
            Assert.AreEqual(otherEquipmentOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var otherEquipmentOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[7]/nav/ul/li[3]/nav/ul/li[1]/a/span/span"));
            Assert.IsTrue(otherEquipmentOptionText.Enabled);
            Assert.IsTrue(otherEquipmentOptionText.Displayed);
            Assert.AreEqual(otherEquipmentOptionText.Text, "Other Equipment");
            Assert.AreEqual(otherEquipmentOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void OtherEquipmentPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Report/OtherEquipmentDetails");
        }

        [Test]
        public void ReportBuilderPage_TopUserNameTest()
        {
            // to open report other equipment page
            OtherEquipmentPage_OpenPage();

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
        public void ReportBuilderPage_LogoutBtn()
        {
            // to open report other equipment page
            OtherEquipmentPage_OpenPage();

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
        public void OtherEquipmentPage_NotificationIconTest()
        {
            // to open report other equipment page
            OtherEquipmentPage_OpenPage();

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
        public void OtherEquipmentPage_SubHeaderTitleTest()
        {
            // to open report other equipment page
            OtherEquipmentPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Other Equipment Details");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void OtherEquipmentPage_ReportsNavigationLinkTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenPage();

            var reportsNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(reportsNavLink.Enabled);
            Assert.IsTrue(reportsNavLink.Displayed);
            Assert.AreEqual(reportsNavLink.Text, "Reports");
            Assert.AreEqual(reportsNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void OtherEquipemtPage_Seperator1Test()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenPage();

            var Seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[2]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text,">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void OtherEquipmentPage_EquipmentNavigationLinkTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenPage();

            var equipmentNavLinkTest = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/a"));
            Assert.IsTrue(equipmentNavLinkTest.Enabled);
            Assert.IsTrue(equipmentNavLinkTest.Displayed);
            Assert.AreEqual(equipmentNavLinkTest.Text,"Equipment");
            Assert.AreEqual(equipmentNavLinkTest.GetAttribute("class"), "m-nav__link");

            var UrlBeforeClick = driver.Url;
            equipmentNavLinkTest.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreEqual(UrlBeforeClick, UrlAfterClick);
        }

        [Test]
        public void OtherEquipmentPage_Seperator2Test()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenPage();

            var Seperator = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[4]"));
            Assert.IsTrue(Seperator.Enabled);
            Assert.IsTrue(Seperator.Displayed);
            Assert.AreEqual(Seperator.Text, ">");
            Assert.AreEqual(Seperator.GetAttribute("class"), "m-nav__separator");
        }

        [Test]
        public void OtherEquipmentPage_OtherEquipmentDetailsNavigationLinkTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenPage();

            var equipmentNavLinkTest = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[5]/a"));
            Assert.IsTrue(equipmentNavLinkTest.Enabled);
            Assert.IsTrue(equipmentNavLinkTest.Displayed);
            Assert.AreEqual(equipmentNavLinkTest.Text, "Other Equipment Details");
            Assert.AreEqual(equipmentNavLinkTest.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void OtherEquipemtPage_AssetClassDropdownlistTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenPage();

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
        public void OtherEquipmentPage_AssetSubClassDropdownlistTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenPage();

            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"),"form-label");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"),"AssetSubClass");

            var assetSubClassValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/b"));
            Assert.IsTrue(assetSubClassValue.Enabled);
            Assert.IsTrue(assetSubClassValue.Displayed);
            Assert.AreEqual(assetSubClassValue.Text, "Other Equipment");
        }


        // this pice contains error asset type label must be linked with asset asset type
        // but it linked with asset sub class
        [Test]
        public void OtherEquipmentPage_AssetTypeDropdownlistTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenPage();

            var assetTypeLabel
                = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"),"form-label");

            var assetTypeValue = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/b"));
            Assert.IsTrue(assetTypeValue.Enabled);
            Assert.IsTrue(assetTypeValue.Displayed);
            Assert.AreEqual(assetTypeValue.Text, "Equipment - Other");
        }

        [Test]
        public void OtherEquipmentPage_DataTableLengthTest()
        {
            // to open other equipment page
            OtherEquipmentPage_OpenPage();

            var lengthLabel = driver.FindElement
                (By.XPath("//*[@id=\"otherEquipmentDetails_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("otherEquipmentDetails_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "otherEquipmentDetails");

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void OtherEquipmentPage_DataTableFilterTest()
        {
            // to open equipment page
            OtherEquipmentPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("otherEquipmentDetails_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text, "Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"otherEquipmentDetails_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "otherEquipmentDetails");
        }

        [Test]
        public void OtherEquipemtPage_OtherEquipmentTable()
        {
            // to open equipment page
            OtherEquipmentPage_OpenPage();

            var table = driver.FindElement(By.Id("otherEquipmentDetails"));
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "otherEquipmentDetails_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");

            var columns = driver.FindElements(By.ClassName("sorting"));
            foreach (var column in columns)
            {
                Assert.IsTrue(column.Enabled);
                Assert.IsTrue(column.Displayed);
            }

            var RowNo = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[1]"));
            Assert.IsTrue(RowNo.Enabled);
            Assert.IsTrue(RowNo.Displayed);
            Assert.AreEqual(RowNo.Text, "Row No");
            Assert.AreEqual(RowNo.GetAttribute("aria-sort"), "ascending");
            Assert.AreEqual(RowNo.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(RowNo.GetAttribute("aria-label"), "Row No: activate to sort column descending");
            //RowNo.Click();

            var Year = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[2]"));
            Assert.IsTrue(Year.Enabled);
            Assert.IsTrue(Year.Displayed);
            Assert.AreEqual(Year.Text, "Year");
            Assert.AreEqual(Year.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Year.GetAttribute("aria-label"), "Year: activate to sort column ascending");
            //Year.Click();

            var Equipment = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[3]"));
            Assert.IsTrue(Equipment.Enabled);
            Assert.IsTrue(Equipment.Displayed);
            Assert.AreEqual(Equipment.Text, "Equipment #");
            Assert.AreEqual(Equipment.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Equipment.GetAttribute("aria-label"), "Equipment #: activate to sort column ascending");
            //Equipment.Click();

            var Make = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[4]"));
            Assert.IsTrue(Make.Enabled);
            Assert.IsTrue(Make.Displayed);
            Assert.AreEqual(Make.Text, "Make");
            Assert.AreEqual(Make.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Make.GetAttribute("aria-label"), "Make: activate to sort column ascending");
            //Make.Click();

            var Model = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[5]"));
            Assert.IsTrue(Model.Enabled);
            Assert.IsTrue(Model.Displayed);
            Assert.AreEqual(Model.Text, "Model");
            Assert.AreEqual(Model.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Model.GetAttribute("aria-label"), "Model: activate to sort column ascending");
            //Model.Click();

            var Type = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[6]"));
            Assert.IsTrue(Type.Enabled);
            Assert.IsTrue(Type.Displayed);
            Assert.AreEqual(Type.Text, "Type");
            Assert.AreEqual(Type.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Type.GetAttribute("aria-label"), "Type: activate to sort column ascending");
            //Type.Click();

            var Vin = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[7]"));
            Assert.IsTrue(Vin.Enabled);
            Assert.IsTrue(Vin.Displayed);
            Assert.AreEqual(Vin.Text, "Vin #");
            Assert.AreEqual(Vin.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Vin.GetAttribute("aria-label"), "Vin #: activate to sort column ascending");
            //Vin.Click();

            var Reg = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[8]"));
            Assert.IsTrue(Reg.Enabled);
            Assert.IsTrue(Reg.Displayed);
            Assert.AreEqual(Reg.Text, "Reg");
            Assert.AreEqual(Reg.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Reg.GetAttribute("aria-label"), "Reg: activate to sort column ascending");
            //Reg.Click();

            var serviceType = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[9]"));
            Assert.IsTrue(serviceType.Enabled);
            Assert.IsTrue(serviceType.Displayed);
            Assert.AreEqual(serviceType.Text, "Service Type");
            Assert.AreEqual(serviceType.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(serviceType.GetAttribute("aria-label"), "Service Type: activate to sort column ascending");
            //serviceType.Click();

            var UsefulLife = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[10]"));
            Assert.IsTrue(UsefulLife.Enabled);
            Assert.IsTrue(UsefulLife.Displayed);
            Assert.AreEqual(UsefulLife.Text, "Useful Life");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(UsefulLife.GetAttribute("aria-label"), "Useful Life: activate to sort column ascending");
            //UsefulLife.Click();

            var Grant = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[11]"));
            Assert.IsTrue(Grant.Enabled);
            Assert.IsTrue(Grant.Displayed);
            Assert.AreEqual(Grant.Text, "Grant #");
            Assert.AreEqual(Grant.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Grant.GetAttribute("aria-label"), "Grant #: activate to sort column ascending");
            //Grant.Click();

            var PurchasePrice = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[12]"));
            Assert.IsTrue(PurchasePrice.Enabled);
            Assert.IsTrue(PurchasePrice.Displayed);
            Assert.AreEqual(PurchasePrice.Text, "Purchase Price");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(PurchasePrice.GetAttribute("aria-label"), "Purchase Price: activate to sort column ascending");
            //PurchasePrice.Click();

            var DeliveryDate = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[13]"));
            Assert.IsTrue(DeliveryDate.Enabled);
            Assert.IsTrue(DeliveryDate.Displayed);
            Assert.AreEqual(DeliveryDate.Text, "Delivery Date");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(DeliveryDate.GetAttribute("aria-label"), "Delivery Date: activate to sort column ascending");
            //DeliveryDate.Click();

            var AcceptanceServiceDate = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[14]"));
            Assert.IsTrue(AcceptanceServiceDate.Enabled);
            Assert.IsTrue(AcceptanceServiceDate.Displayed);
            Assert.AreEqual(AcceptanceServiceDate.Text, "Acceptance /Service Date");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(AcceptanceServiceDate.GetAttribute("aria-label"), "Acceptance /Service Date: activate to sort column ascending");
            //AcceptanceServiceDate.Click();

            var ReplacesVIN = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[15]"));
            Assert.IsTrue(ReplacesVIN.Enabled);
            Assert.IsTrue(ReplacesVIN.Displayed);
            Assert.AreEqual(ReplacesVIN.Text, "Replaces VIN #");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(ReplacesVIN.GetAttribute("aria-label"), "Replaces VIN #: activate to sort column ascending");
            //ReplacesVIN.Click();

            var VehicleLeasedTo = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[16]"));
            Assert.IsTrue(VehicleLeasedTo.Enabled);
            Assert.IsTrue(VehicleLeasedTo.Displayed);
            Assert.AreEqual(VehicleLeasedTo.Text, "Vehicle Leased To");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(VehicleLeasedTo.GetAttribute("aria-label"), "Vehicle Leased To: activate to sort column ascending");
            //VehicleLeasedTo.Click();

            var Comments = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[17]"));
            Assert.IsTrue(Comments.Enabled);
            Assert.IsTrue(Comments.Displayed);
            Assert.AreEqual(Comments.Text, "Comments");
            Assert.AreEqual(Comments.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(Comments.GetAttribute("aria-label"), "Comments: activate to sort column ascending");
            //Comments.Click();

            var ColorCode1 = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[18]"));
            Assert.IsTrue(ColorCode1.Enabled);
            Assert.IsTrue(ColorCode1.Displayed);
            Assert.AreEqual(ColorCode1.Text, "Color Code 1");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(ColorCode1.GetAttribute("aria-label"), "Color Code 1: activate to sort column ascending");
            //ColorCode1.Click();

            var ColorCode2 = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[19]"));
            Assert.IsTrue(ColorCode2.Enabled);
            Assert.IsTrue(ColorCode2.Displayed);
            Assert.AreEqual(ColorCode2.Text, "Color Code 2");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(ColorCode2.GetAttribute("aria-label"), "Color Code 2: activate to sort column ascending");
            //ColorCode2.Click();

            var ColorCode3 = driver.FindElement(By.XPath("//*[@id=\"otherEquipmentDetails\"]/thead/tr/th[20]"));
            Assert.IsTrue(ColorCode3.Enabled);
            Assert.IsTrue(ColorCode3.Displayed);
            Assert.AreEqual(ColorCode3.Text, "Color Code 3");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(ColorCode3.GetAttribute("aria-label"), "Color Code 3: activate to sort column ascending");
            //ColorCode3.Click();
        }

        [Test]
        public void OtherEquipmentPage_PaginateTest()
        {
            // to open equipment page
            OtherEquipmentPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("otherEquipmentDetails_previous"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");
            previousBtn.Click();

            var nextBtn = driver.FindElement(By.Id("otherEquipmentDetails_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "otherEquipmentDetails");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");
            nextBtn.Click();

            var pages = driver.FindElements(By.Id("messageTable_paginate"));
            foreach(var page in pages)
            {
                Assert.IsTrue(page.Displayed);
                Assert.IsTrue(page.Enabled);
                page.Click();
            }
        }

        [Test]
        public void OtherEquipmentPage_ExportBtnTest()
        {
            // to open equipment page
            OtherEquipmentPage_OpenPage();

            var exportBtn = driver.FindElement(By.Id("ExportCSVLink"));
            Assert.IsTrue(exportBtn.Enabled);
            Assert.IsTrue(exportBtn.Displayed);
            Assert.AreEqual(exportBtn.Text, "Export CSV");
            Assert.AreEqual(exportBtn.GetAttribute("class"), "btn btn-primary waves-effect mr-4");
            exportBtn.Click();
        }

        [Test]
        public void OtherEquipmentPage_SideLeftMinimizeToggle()
        {
            // to open equipment page
            OtherEquipmentPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            sideLeft.Click();
        }

        [Test]
        public void OtherEquipmentPage_DataTableInfoTest()
        {
            // to open equipment page
            OtherEquipmentPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("otherEquipmentDetails_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void OtherEquipmentPage_CopyRightTest()
        {
            // to open equipment page
            OtherEquipmentPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

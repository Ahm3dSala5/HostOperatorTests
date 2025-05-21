using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorOperationsTests : IDisposable
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
        public void CreateAssetPage_OperationOptionTest()
        {
            var operationsOptions = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/a"));
            Assert.IsTrue(operationsOptions.Enabled);
            Assert.IsTrue(operationsOptions.Displayed);
            Assert.AreEqual(operationsOptions.Text, "Operations");
            Assert.AreEqual(operationsOptions.GetAttribute("role"),"menuitem");
            Assert.AreEqual(operationsOptions.GetAttribute("href"),$"{driver.Url}#");
            Assert.AreEqual(operationsOptions.GetAttribute("custom-data"),"Operations");
            Assert.AreEqual(operationsOptions.GetAttribute("class"), "side-menu-links m-menu__link m-menu__toggle");

            var OperationsIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/a/i[1]"));
            Assert.IsTrue(OperationsIcon.Enabled);
            Assert.IsTrue(OperationsIcon.Displayed);
            Assert.AreEqual(OperationsIcon.GetAttribute("class"), "m-menu__link-icon flaticon-suitcase");

            var operationsOptionArrow = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/a/i[2]"));
            Assert.IsTrue(operationsOptionArrow.Enabled);
            Assert.IsTrue(operationsOptionArrow.Displayed);
            Assert.AreEqual(operationsOptionArrow.GetAttribute("class"), "m-menu__ver-arrow la la-angle-right");

            var OperationOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/a/span/span"));
            Assert.IsTrue(OperationOptionText.Enabled);
            Assert.IsTrue(OperationOptionText.Displayed);
            Assert.AreEqual(OperationOptionText.Text,"Operations");
            Assert.AreEqual(OperationOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void CreateAssetPage_CreateAssetOptionTest()
        {
            // to click on operations option
            var operationsOptions = driver.FindElement
               (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/a"));
            operationsOptions.Click();

            var createAssetOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/nav/ul/li/a"));
            Assert.IsTrue(createAssetOption.Enabled);
            Assert.IsTrue(createAssetOption.Displayed);
            Assert.AreEqual(createAssetOption.Text, "Create Asset");
            Assert.AreEqual(createAssetOption.GetAttribute("target"),"_self");
            Assert.AreEqual(createAssetOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(createAssetOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(createAssetOption.GetAttribute("custom-data"),"Create Asset");
            Assert.AreEqual(createAssetOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/Create");

            var createAssetOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/nav/ul/li/a/i"));
            Assert.IsTrue(createAssetOptionIcon.Enabled);
            Assert.IsTrue(createAssetOptionIcon.Displayed);
            Assert.AreEqual(createAssetOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-cogwheel");

            var createAssetOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[6]/nav/ul/li/a/span/span"));
            Assert.IsTrue(createAssetOptionIcon.Enabled);
            Assert.IsTrue(createAssetOptionText.Displayed);
            Assert.AreEqual(createAssetOptionText.Text,"Create Asset");
            Assert.AreEqual(createAssetOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void CreateAssetPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/Create");
        }

        [Test]
        public void CreatePage_TopUserNameTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

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
        public void CreateAssetPage_LogoutBtn()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.ClassName("m-topbar__username"));
            hiHostOperator.Click();

            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Thread.Sleep(5000);
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("class"), "btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder");
        }

        [Test]
        public void CreateAssetPage_NotificationIconTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

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
        public void CreateAssetPage_SubHeaderTitleTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));

            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Create Asset");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void CreateAssetPage_DashboardNavigationLinkTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a"));
            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text, "Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");
        }

        [Test]
        public void CreateAssetPage_CreateAssetNavigationLinkTest()
        {
            // to opem create asset page 
            CreateAssetPage_OpenPage();

            var createAssetNavLink = driver.FindElement
              (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.IsTrue(createAssetNavLink.Enabled);
            Assert.IsTrue(createAssetNavLink.Displayed);
            Assert.AreEqual(createAssetNavLink.Text, "Create Asset");
            Assert.AreEqual(createAssetNavLink.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void CreateAssetPage_AssetNameTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var assetNameLabel = driver.FindElement
               (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[1]/div/div/div/label"));
            assetNameLabel.Click();
            Assert.IsTrue(assetNameLabel.Enabled);
            Assert.IsTrue(assetNameLabel.Displayed);
            Assert.AreEqual(assetNameLabel.Text, "Asset Name");
            Assert.AreEqual(assetNameLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetNameLabel.GetAttribute("class"), "form-label-default");

            var assetNameValue = driver.FindElement(By.Id("AssetDes"));
            assetNameValue.SendKeys("Test Name");
            Assert.IsTrue(assetNameValue.Enabled);
            Assert.IsTrue(assetNameValue.Displayed);
            Assert.AreEqual(assetNameValue.GetAttribute("type"),"text");
            Assert.AreEqual(assetNameValue.GetAttribute("required"), "true");
            Assert.AreEqual(assetNameValue.GetAttribute("required"), "true");
            Assert.AreEqual(assetNameValue.GetAttribute("maxlength"), "500");
            Assert.AreEqual(assetNameValue.GetAttribute("class"), "textBox");
            Assert.AreEqual(assetNameValue.GetAttribute("data-val-length-max"),"500");
            Assert.AreEqual(assetNameValue.GetAttribute("data-val-length"), "The field AssetDesc must be a string with a maximum length of 500.");
        }

        [Test]
        public void CreateAssetPage_DescriptionInputTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var assetDescriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[2]/div/div/div/label"));
            Assert.IsTrue(assetDescriptionLabel.Enabled);
            Assert.IsTrue(assetDescriptionLabel.Displayed);
            Assert.AreEqual(assetDescriptionLabel.Text, "Asset Description");
            Assert.AreEqual(assetDescriptionLabel.GetAttribute("for"), "Description");
            Assert.AreEqual(assetDescriptionLabel.GetAttribute("class"), "form-label-default ");

            var assetDescriptionValue = driver.FindElement(By.Id("AssetTypesDesc"));
            assetDescriptionValue.SendKeys("Test Name");
            Assert.IsTrue(assetDescriptionValue.Enabled);
            Assert.IsTrue(assetDescriptionValue.Displayed);
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val"),"true");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("maxlength"), "255");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("class"),"form-control");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val-length-max"),"255");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val-required"), "The AssetNote field is required.");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val-length"), "The field AssetNote must be a string with a maximum length of 255.");
        }

        [Test]
        public void CreateAssetPage_ImageTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var assetImageLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[3]/div/div/div[1]/label"));
            Assert.IsTrue(assetImageLabel.Displayed);
            Assert.IsTrue(assetImageLabel.Enabled);
            Assert.AreEqual(assetImageLabel.Text, "Asset Image");
            Assert.AreEqual(assetImageLabel.GetAttribute("for"), "ImagePath");
            Assert.AreEqual(assetImageLabel.GetAttribute("class"), "form-label-default");

            var assetImageValue = driver.FindElement(By.Id("ImagePath"));
            Assert.IsTrue(assetImageValue.Enabled);
            Assert.IsTrue(assetImageValue.Displayed);
            Assert.AreEqual(assetImageValue.GetAttribute("type"), "file");
            Assert.AreEqual(assetImageValue.GetAttribute("accept"), "image/*,.pdf");
            Assert.AreEqual(assetImageValue.GetAttribute("class"), "form-control input");
        }

        [Test]
        public void CreateAssetPage_AssetClassDropdownlistTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var assetClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[4]/div/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"),"form-label");

            var assetClassInput = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("required"), "true");
            Assert.AreEqual(assetClassInput.GetAttribute("class"), "form-control");

            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(0);
        }

        // this pice contains error in Asset Subclass label it Linked with asset class 
        // but is must linked with asset subclass
        [Test]
        public void CreateAssetPage_AssetSubclassDropdownlistTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var assetSubclassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[5]/div/div/div/label"));
            Assert.IsTrue(assetSubclassLabel.Enabled);
            Assert.IsTrue(assetSubclassLabel.Displayed);
            Assert.AreEqual(assetSubclassLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubclassLabel.GetAttribute("for"),"AssetSubclass");
            Assert.AreEqual(assetSubclassLabel.GetAttribute("class"),"form-control");

            var assetSubClassInput = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.AreEqual(assetSubClassInput.GetAttribute("required"),"true");
        }

        // this pice contains error in Asset type label it Linked with asset class 
        // but is must linked with asset subclass
        [Test]
        public void CreateAssetPage_AssetTypeDropdownlistTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var assetTypeLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[6]/div/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"), "form-label-default");

            var assetTypeInput = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.IsTrue(assetTypeInput.Displayed);
            Assert.AreEqual(assetTypeInput.GetAttribute("required"), "true");
        }

        [Test]
        public void CreateAssetPage_AssociatedAttributesTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var header = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[7]/div[1]/div/div/h3"));
            Assert.IsTrue(header.Enabled);
            Assert.IsTrue(header.Displayed);
            Assert.AreEqual(header.Text, "Please Add Associate Attribute");

            var addBtn = driver.FindElement(By.Id("btnAdd"));
            Assert.IsTrue(addBtn.Enabled);
            Assert.IsTrue(addBtn.Displayed);
            Assert.AreEqual(addBtn.Text,"ADD");
            Assert.AreEqual(addBtn.GetAttribute("class"), "btn btn-success");

            var saveBtn = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[9]/button[1]"));
            Assert.IsTrue(saveBtn.Enabled);
            Assert.IsTrue(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.Text,"Save");
            Assert.AreEqual(saveBtn.GetAttribute("type"), "submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement(By.Id("cancle"));
            Assert.IsTrue(cancelBtn.Enabled);
            Assert.IsTrue(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text,"Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"),"button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-success");
        }

        [Test]
        public void CreateAssetPage_AsideMeftMinimizeToggle()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var AsideLeftOffcanvas = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(AsideLeftOffcanvas.Enabled);
            Assert.IsTrue(AsideLeftOffcanvas.Displayed);
            Assert.AreEqual(AsideLeftOffcanvas.GetAttribute("href"), "javascript:;");
            AsideLeftOffcanvas.Click();
        }

        [Test]
        public void CreateAssetPage_CopyRightTest()
        {
            // to open create asset page
            CreateAssetPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

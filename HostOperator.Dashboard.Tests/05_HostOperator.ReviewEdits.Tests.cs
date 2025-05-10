using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HostOperator.Tests
{
    public class HostOperatorReviewEditsTests : IDisposable
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
        public void ReviewEditsPage_ReviewEditsOptionTest()
        {
            var reviewEditsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[5]/a"));
            Assert.IsTrue(reviewEditsOption.Enabled);
            Assert.IsTrue(reviewEditsOption.Displayed);
            Assert.AreEqual(reviewEditsOption.Text, "Review Edits");
            Assert.AreEqual(reviewEditsOption.GetAttribute("target"),"_self");
            Assert.AreEqual(reviewEditsOption.GetAttribute("role"),"menuitem");
            Assert.AreEqual(reviewEditsOption.GetAttribute("class"), "side-menu-links m-menu__link");
            Assert.AreEqual(reviewEditsOption.GetAttribute("custom-data"), "Review Edits");
            Assert.AreEqual(reviewEditsOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/Management");

            var reviewEditsOptionIcon = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[5]/a/i"));
            Assert.IsTrue(reviewEditsOption.Enabled);
            Assert.IsTrue(reviewEditsOptionIcon.Displayed);
            Assert.AreEqual(reviewEditsOptionIcon.GetAttribute("class"), "m-menu__link-icon flaticon-suitcase");

            var reviewEditsOptionText = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[5]/a/span/span"));
            Assert.IsTrue(reviewEditsOptionText.Enabled);
            Assert.IsTrue(reviewEditsOptionText.Displayed);
            Assert.AreEqual(reviewEditsOptionText.GetAttribute("class"),"title");
        }

        [Test]
        public void ReviewEditsPage_OpenPage()
        {
            driver.Navigate().GoToUrl("http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/Management");
        }

        [Test]
        public void ReviewEditsPage_TopUserNameTest()
        {
            // to open review edit page
            ReviewEditsPage_OpenPage();

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
        public void ReviewEditsPage_LogoutBtn()
        {
            // to open review edit page
            ReviewEditsPage_OpenPage();

            var hiHostOperator = driver.FindElement
                (By.ClassName("m-topbar__username"));
            hiHostOperator.Click();

            Thread.Sleep(5000);
            var logoutBtn = driver.FindElement
                (By.XPath("//*[@id=\"m_header_topbar\"]/div/ul/li[4]/div/div/div/div/ul/li[4]/a"));
            Assert.IsTrue(logoutBtn.Enabled);
            Assert.IsTrue(logoutBtn.Displayed);
            Assert.AreEqual(logoutBtn.Text, "Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/Account/Logout");
            Assert.AreEqual(logoutBtn.GetAttribute("class"), "btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--label-brand m-btn--bolder");
        }

        [Test]
        public void ReviwEditsPage_NotificationIconTest()
        {
            // to open review edit page
            ReviewEditsPage_OpenPage();

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
        public void ReviewEditsPage_SubHeaderTitleTest()
        {
            // to open review edit page
            ReviewEditsPage_OpenPage();

            var subTite = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1"));
            
            Assert.IsTrue(subTite.Enabled);
            Assert.IsTrue(subTite.Displayed);
            Assert.AreEqual(subTite.Text, "Review Edits");
            Assert.AreEqual(subTite.GetAttribute("class"), "m-subheader__title m-subheader__title--separator");
        }

        [Test]
        public void ReviewEditsPage_DashboardNavLinkTest()
        {
            // to open review edit page
            ReviewEditsPage_OpenPage();

            var dashboardNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.IsTrue(dashboardNavLink.Enabled);
            Assert.IsTrue(dashboardNavLink.Displayed);
            Assert.AreEqual(dashboardNavLink.Text, "Dashboard");
            Assert.AreEqual(dashboardNavLink.GetAttribute("class"), "m-nav__link");
            Assert.AreEqual(dashboardNavLink.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Dashboard");
        }

        [Test]
        public void ReviewEditPage_ReviewEditsNavigationLinkTest()
        {
            // to open review edit page
            ReviewEditsPage_OpenPage();

            var reviewEditNavLink = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.IsTrue(reviewEditNavLink.Enabled);
            Assert.IsTrue(reviewEditNavLink.Displayed);
            Assert.AreEqual(reviewEditNavLink.Text,"Review Edits");
            Assert.AreEqual(reviewEditNavLink.GetAttribute("class"), "m-nav__link-text");
        }

        [Test]
        public void ReviewEditsPage_AssetStateDropdownlistTest()
        {
            // to open review page 
            ReviewEditsPage_ReviewEditsOptionTest();

            var assetStateLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[3]/span"));
            Assert.IsTrue(assetStateLabel.Enabled);
            Assert.IsTrue(assetStateLabel.Displayed);
            Assert.AreEqual(assetStateLabel.Text, "Asset State");
            Assert.AreEqual(assetStateLabel.GetAttribute("for"),"AssetState");
            Assert.AreEqual(assetStateLabel.GetAttribute("class"),"form-label");

            var assetStateInput = driver.FindElement(By.Id("AssetStateIdChange"));
            Assert.IsTrue(assetStateInput.Enabled);
            Assert.IsTrue(assetStateInput.Displayed);
            Assert.AreEqual(assetStateInput.GetAttribute("class"),"form-control form-line");

            var selectedAssetState = new SelectElement(assetStateInput);
            selectedAssetState.SelectByIndex(0);

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetStateIdChange\"]/option[1]"));
            Assert.AreEqual(defaultOption.Text,"All");
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
        }

        [Test]
        public void ReviewEditsPage_AssetClassDropdownlistTest()
        {
            // to open review page 
            ReviewEditsPage_ReviewEditsOptionTest();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"),"form-label");

            var assetClassInput = driver.FindElement(By.XPath("//*[@id=\"AssetClassIdChange\"]"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("class"),"form-control form-line");

            var selectedAssetclass = new SelectElement(assetClassInput);
            selectedAssetclass.SelectByIndex(0);

            var defaultOption = driver.FindElement
                (By.XPath("//*[@id=\"AssetClassIdChange\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"Select Asset Class");
        }

        [Test]
        public void ReviewEditsPage_AssetSubClassDropdownlistTest()
        {
            // to open review page 
            ReviewEditsPage_ReviewEditsOptionTest();
            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("for"),"AssetSubClass");
            Assert.AreEqual(assetSubClassLabel.GetAttribute("class"),"form-label");

            var assetSubClassInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.AreEqual(assetSubClassInput.GetAttribute("class"),"form-control");

            var defaultOption = driver.FindElement(By.XPath(""));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"No Asset Subclass");
        }

        [Test]
        public void ReviewEditsPage_AssetTypeDropdownlistTest()
        {
            // to open review page 
            ReviewEditsPage_ReviewEditsOptionTest();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[4]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeLabel.GetAttribute("class"), "form-label");

            var assetTypeInput = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.IsTrue(assetTypeInput.Displayed);
            Assert.AreEqual(assetTypeInput.GetAttribute("class"),"form-control");

            var selectedAssetType = new SelectElement(assetTypeInput);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetTypeDropDownChange\"]/option"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"No Asset Types");
        }

        [Test]
        public void ReviewEditsPage_DataTableLengthTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"AssetsTable_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Displayed);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("AssetsTable_length"));
            Assert.IsTrue(lengthValue.Enabled);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.AreEqual(lengthValue.GetAttribute("aria-controls"), "AssetsTable"); 

            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
        }

        [Test]
        public void ReviewEditsPage_DataTableFilterTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("AssetsTable_filter"));
            Assert.IsTrue(tableFilterLabel.Enabled);
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text,"Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Enabled);
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.AreEqual(tableFilterInput.GetAttribute("type"),"search");
            Assert.AreEqual(tableFilterInput.GetAttribute("aria-controls"), "AssetsTable");
        }

        [Test]
        public void ReviewEditsPage_ReviewEditsTableTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var table = driver.FindElement(By.Id("AssetsTable"));
            Assert.IsNotNull(table);
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"), "grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"),"AssetsTable_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable no-footer dataTable");

            var columns = driver.FindElements(By.Id("AssetsTable"));
            foreach (var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }

            var SelectAllCheckBox = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[1]"));
            Assert.IsTrue(SelectAllCheckBox.Enabled);
            Assert.IsTrue(SelectAllCheckBox.Displayed);
            Assert.AreEqual(SelectAllCheckBox.GetAttribute("class"),"sorting_asc");
            Assert.AreEqual(SelectAllCheckBox.GetAttribute("aria-controls"), "AssetsTable");

            var selectAllInput = driver.FindElement(By.Id("btnSelectAll"));
            Assert.IsTrue(selectAllInput.Enabled);
            //Assert.IsTrue(selectAllInput.Displayed);
            Assert.AreEqual(selectAllInput.GetAttribute("type"), "checkbox");

            var AssetId = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(AssetId.Enabled);
            Assert.IsTrue(AssetId.Displayed);
            Assert.AreEqual(AssetId.GetAttribute("class"),"sorting");
            Assert.AreEqual(AssetId.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(AssetId.GetAttribute("aria-label"), "Asset ID: activate to sort column ascending");
            AssetId.Click();

            var AssetClass = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(AssetClass.Enabled);
            Assert.IsTrue(AssetClass.Displayed);
            Assert.AreEqual(AssetClass.Text, "Asset Class");
            Assert.AreEqual(AssetClass.GetAttribute("class"), "sorting");
            Assert.AreEqual(AssetClass.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(AssetClass.GetAttribute("aria-label"), "Asset Class: activate to sort column ascending");
            AssetClass.Click();

            var AssetSubClass = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[4]"));
            Assert.IsTrue(AssetSubClass.Enabled);
            Assert.IsTrue(AssetSubClass.Displayed);
            Assert.AreEqual(AssetSubClass.Text, "Asset Subclass");
            Assert.AreEqual(AssetSubClass.GetAttribute("class"),"sorting");
            Assert.AreEqual(AssetSubClass.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(AssetSubClass.GetAttribute("aria-label"), "Asset Subclass: activate to sort column ascending");
            AssetSubClass.Click();

            var AssetType = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[5]"));
            Assert.IsTrue(AssetType.Enabled);
            Assert.IsTrue(AssetType.Displayed);
            Assert.AreEqual(AssetType.Text, "Asset Type"); 
            Assert.AreEqual(AssetType.GetAttribute("class"),"sorting");
            Assert.AreEqual(AssetType.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(AssetType.GetAttribute("aria-label"), "Asset Type: activate to sort column ascending");
            AssetType.Click();

            var Asset = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[6]"));
            Assert.IsTrue(Asset.Enabled);
            Assert.IsTrue(Asset.Displayed);
            Assert.AreEqual(Asset.Text, "Asset");
            Assert.AreEqual(Asset.GetAttribute("class"),"sorting");
            Assert.AreEqual(Asset.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(Asset.GetAttribute("aria-label"), "Asset: activate to sort column ascending");
            Asset.Click();

            var State = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[7]"));
            Assert.IsTrue(State.Enabled);
            Assert.IsTrue(State.Displayed);
            Assert.AreEqual(State.Text, "State");
            Assert.AreEqual(State.GetAttribute("class"),"sorting");
            Assert.AreEqual(State.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(State.GetAttribute("aria-label"), "State: activate to sort column ascending");
            State.Click();

            var createTime = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[8]"));
            Assert.IsTrue(createTime.Enabled);
            Assert.IsTrue(createTime.Displayed);
            Assert.AreEqual(createTime.Text, "Created Time");
            Assert.AreEqual(createTime.GetAttribute("class"),"sorting");
            Assert.AreEqual(createTime.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(createTime.GetAttribute("aria-label"), "Created Time: activate to sort column ascending");
            createTime.Click();

            var Actions = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[9]"));
            Assert.IsTrue(Actions.Enabled);
            Assert.IsTrue(Actions.Displayed);
            Assert.AreEqual(Actions.Text, "Actions");
            Assert.AreEqual(Actions.GetAttribute("aria-label"), "Actions");
            Assert.AreEqual(Actions.GetAttribute("class"), "sorting_disabled");
        }

        [Test]
        public void ReviewEditsPage_SelectAllCheckBoxTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var selectAll = driver.FindElement(By.Id("btnSelectAll"));
            Assert.IsTrue(selectAll.Enabled);
            Assert.IsTrue(selectAll.Displayed);
            Assert.AreEqual(selectAll.GetAttribute("type"),"checkbox");
            selectAll.Click();
        }

        [Test]
        public void ReviewEditsPage_StatusIConTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var statusAncor = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[3]/td[9]/a[4]"));

            Assert.IsTrue(statusAncor.Enabled);
            Assert.IsTrue(statusAncor.Displayed);
            Assert.AreEqual(statusAncor.GetAttribute("title"), "Status");
            Assert.IsTrue(statusAncor.GetAttribute("onclick").Contains("statusAsset"));

            var Icon = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[3]/td[9]/a[4]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fas fa-print");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
            statusAncor.Click();
        }

        [Test]
        public void ReviewEditsPage_StatusIconFormTest()
        {
            // to open status form page
            ReviewEditsPage_StatusIConTest();

            // modal title 
            var title = driver.FindElement(By.XPath("//*[@id=\"StatusModal\"]/div/div/div[1]/h4"));
            Assert.IsTrue(title.Enabled);
            Assert.IsTrue(title.Displayed);
            Assert.AreEqual(title.Text,"Asset Status");

            // modal title //
            var table = driver.FindElement
                (By.Id("StatusTable"));
            Assert.IsTrue(table.Enabled);
            Assert.IsTrue(table.Displayed);
            Assert.AreEqual(table.GetAttribute("role"),"grid");
            Assert.AreEqual(table.GetAttribute("aria-describedby"), "StatusTable_info");
            Assert.AreEqual(table.GetAttribute("class"), "table m-table table-hover table-checkable dataTable no-footer");


            // table head test
            var State = driver.FindElement
                (By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[1]"));
            Assert.IsTrue(State.Enabled);
            Assert.IsTrue(State.Displayed);
            Assert.AreEqual(State.Text, "State");
            Assert.AreEqual(State.GetAttribute("class"),"sorting");
            Assert.AreEqual(State.GetAttribute("aria-label"),"State");

            var Remarks = driver.FindElement
                (By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(Remarks.Displayed);
            Assert.IsTrue(Remarks.Enabled);
            Assert.AreEqual(Remarks.Text, "Remarks");
            Assert.AreEqual(Remarks.GetAttribute("aria-label"), "Remarks");
            Assert.AreEqual(Remarks.GetAttribute("class"),"sorting_disabled");

            var createdBy = driver.FindElement
                (By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(createdBy.Displayed);
            Assert.IsTrue(createdBy.Enabled);
            Assert.AreEqual(createdBy.Text, "Created By");
            Assert.AreEqual(createdBy.GetAttribute("aria-label"),"Created By");
            Assert.AreEqual(createdBy.GetAttribute("class"),"sorting_disabled");

            var createdTime = driver.FindElement
                (By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[4]"));
            Assert.IsTrue(createdTime.Displayed);
            Assert.IsTrue(createdTime.Enabled);
            Assert.AreEqual(createdTime.Text, "Created Time");
            Assert.AreEqual(createdTime.GetAttribute("class"),"sorting_disabled");
            Assert.AreEqual(createdTime.GetAttribute("aria-label"),"Create Time");

            var View = driver.FindElement
                (By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[5]"));
            Assert.IsTrue(View.Enabled);
            Assert.IsTrue(View.Displayed);
            Assert.AreEqual(View.Text, "View");
            Assert.AreEqual(View.GetAttribute("class"),"sorting");
            Assert.AreEqual(View.GetAttribute("aria-label"),"View");

            /// status table info
            var tableInfo = driver.FindElement
                (By.Id("StatusTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.AreEqual(tableInfo.GetAttribute("role"), "status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"), "polite");
            Assert.IsTrue(tableInfo.Text.Contains("Showing") && table.Text.Contains("entries"));

            var closeIcon = driver.FindElement(By.Id("closeButtonStatus"));
            Assert.IsTrue(closeIcon.Enabled);
            Assert.IsTrue(closeIcon.Displayed);
            Assert.AreEqual(closeIcon.GetAttribute("type"),"button");
            Assert.AreEqual(closeIcon.GetAttribute("class"), "close");  
        }

        [Test]
        public void ReviewEditsPage_EditIconTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var editAncor = driver.FindElement(By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[1]"));
            Assert.IsTrue(editAncor.Enabled);
            Assert.IsTrue(editAncor.Displayed);
            Assert.AreEqual(editAncor.GetAttribute("title"), "Edit");

            var Icon = driver.FindElement(By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[1]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-edit");
        }


        // this method contains some error in asset type Label and Asset Sub Class Label And Comment label
        // all this error in link label by wrong input
        [Test]
        public void ReviewEditsPage_EditAssetTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var editIcon = driver.FindElement(By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[1]"));
            Thread.Sleep(4000);
            editIcon.Click();

            var assetNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[1]/div/div/div/label"));
            Assert.IsTrue(assetNameLabel.Enabled);
            Assert.IsTrue(assetNameLabel.Displayed);
            Assert.AreEqual(assetNameLabel.Text, "Asset Name");
            Assert.AreEqual(assetNameLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetNameLabel.GetAttribute("class"),"form-label");

            var assetNameValue = driver.FindElement(By.Id("AssetDes"));
            assetNameValue.SendKeys("Test Name");
            Assert.IsTrue(assetNameValue.Enabled);
            Assert.IsTrue(assetNameValue.Displayed);
            Assert.AreEqual(assetNameValue.GetAttribute("type"),"text");
            Assert.AreEqual(assetNameValue.GetAttribute("maxlength"), "500");
            Assert.AreEqual(assetNameValue.GetAttribute("data-val"),"true");
            Assert.AreEqual(assetNameValue.GetAttribute("required"), "true");
            Assert.AreEqual(assetNameValue.GetAttribute("data-val-length-max"),"500");
            Assert.AreEqual(assetNameValue.GetAttribute("data-val-length"), "The field AssetDesc must be a string with a maximum length of 500.");

            var assetDescriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[2]/div/div/div/label"));
            Assert.IsTrue(assetDescriptionLabel.Enabled);
            Assert.IsTrue(assetDescriptionLabel.Displayed);
            Assert.AreEqual(assetDescriptionLabel.Text,"Description");
            Assert.AreEqual(assetDescriptionLabel.GetAttribute("for"), "Description");
            Assert.AreEqual(assetDescriptionLabel.GetAttribute("class"),"form-label-default ");

            var assetDescriptionValue = driver.FindElement(By.Id("AssetTypesDesc"));
            assetDescriptionValue.SendKeys("Test Name");
            Assert.IsTrue(assetDescriptionValue.Enabled);
            Assert.IsTrue(assetDescriptionValue.Displayed);
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val"),"true");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("maxlength"), "255");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("class"),"form-control valid");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val-required"), "The AssetNote field is required.");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val-length"), "The field AssetNote must be a string with a maximum length of 255.");

            var assetImageLabel = driver.FindElement
               (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[4]/div/div/div/label"));
            Assert.IsTrue(assetImageLabel.Enabled);
            Assert.IsTrue(assetImageLabel.Displayed);
            Assert.AreEqual(assetImageLabel.Text, "Asset Image");
            Assert.AreEqual(assetImageLabel.GetAttribute("for"),"ImagePath");
            Assert.AreEqual(assetImageLabel.GetAttribute("class"), "form-label-default");

            var Image = driver.FindElement(By.Id("ImagePath"));
            Assert.IsTrue(Image.Enabled);
            Assert.IsTrue(Image.Displayed);
            Assert.AreEqual(Image.GetAttribute("type"),"file");
            Assert.AreEqual(Image.GetAttribute("accept"), "image/*,.pdf");

            var assetClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[5]/div/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"),"AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"),"form-label");

            var assetClassInput = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("required"), "true");
            Assert.AreEqual(assetClassInput.GetAttribute("class"),"form-control valid");

            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(0);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetClassId\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text,"Select Asset Class");

            // error asset subclass label must be linked with Assset Subclass but is linked with asset class
            var assetSubClassDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[6]/div/div/div/label"));
            Assert.IsTrue(assetSubClassDropdownlistLabel.Enabled);
            Assert.IsTrue(assetSubClassDropdownlistLabel.Displayed);
            Assert.AreEqual(assetSubClassDropdownlistLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassDropdownlistLabel.GetAttribute("for"),"AssetSubclass");

            var assetSubClassDropdownlist = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetSubClassDropdownlist.Enabled);
            Assert.IsTrue(assetSubClassDropdownlist.Displayed);
            Assert.AreEqual(assetSubClassDropdownlist.GetAttribute("required"), "true");
            Assert.AreEqual(assetSubClassDropdownlist.GetAttribute("class"), "form-control");

            var AsseetSubclassDefaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetSubClassIdDropdown\"]/option"));
            Assert.IsTrue(AsseetSubclassDefaultOption.Enabled);
            Assert.IsTrue(AsseetSubclassDefaultOption.Displayed);
            Assert.AreEqual(AsseetSubclassDefaultOption.Text, "Please select ...");


            // error asset type label must be linked with Assset Types but is linked with asset class
            var assetTypeDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[7]/div/div/div/label"));
            Assert.IsTrue(assetTypeDropdownlistLabel.Enabled);
            Assert.IsTrue(assetTypeDropdownlistLabel.Displayed);
            Assert.AreEqual(assetTypeDropdownlistLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeDropdownlistLabel.GetAttribute("for"),"AssetType");
            Assert.AreEqual(assetTypeDropdownlistLabel.GetAttribute("class"),"form-label");

            var assetTypeDropdownlistInput = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetTypeDropdownlistInput.Enabled);
            Assert.IsTrue(assetTypeDropdownlistInput.Displayed);
            Assert.AreEqual(assetTypeDropdownlistInput.GetAttribute("required"), "true");

            var defaultOptionAssetType = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeIdDropdown\"]/option[1]"));
            Assert.IsTrue(defaultOptionAssetType.Enabled);
            Assert.IsTrue(defaultOptionAssetType.Displayed);
            Assert.AreEqual(defaultOptionAssetType.Text, "No Asset Types");


            /// error comment label must be linked with comment input but is linked with description
            var commentLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[8]/div/div/div/label"));
            Assert.IsTrue(commentLabel.Enabled);
            Assert.IsTrue(commentLabel.Displayed);
            Assert.AreEqual(commentLabel.Text,"Comments");
            Assert.AreEqual(commentLabel.GetAttribute("for"),"Comments");
            Assert.AreEqual(commentLabel.GetAttribute("class"),"form-label");

            var commentInput = driver.FindElement(By.Id("UnapprovedReason"));
            Assert.IsTrue(commentLabel.Enabled);
            commentInput.SendKeys("Test Comment");
            Assert.IsTrue(commentLabel.Displayed);
            Assert.AreEqual(commentInput.GetAttribute("class"), "form-control valid");

            var addAssociatedAttributeBtn = driver.FindElement(By.Id("btnAdd"));
            Assert.IsTrue(addAssociatedAttributeBtn.Enabled);
            Assert.IsTrue(addAssociatedAttributeBtn.Displayed);
            Assert.AreEqual(addAssociatedAttributeBtn.Text,"ADD");
            Assert.AreEqual(addAssociatedAttributeBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");

            var cancelBtn = driver.FindElement(By.Id("cancle"));
            Assert.IsTrue(cancelBtn.Enabled);
            Assert.IsTrue(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text,"Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"),"button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void ReviewEditsPage_CopyIconTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var copyAncor = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[2]"));
            Assert.IsTrue(copyAncor.Enabled);
            Assert.IsTrue(copyAncor.Displayed);
            Assert.AreEqual(copyAncor.GetAttribute("title"),"Copy");
            Assert.IsTrue(copyAncor.GetAttribute("onclick").Contains("copyAsset"));

            var Icon = driver.FindElement(By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[2]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-clone");
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        // this method contains some error in asset type Label and Asset Sub Class Label And Comment label
        // all this error in link label by wrong input
        [Test]
        public void ReviewEditsPage_CopyAssetTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var copyAncor = driver.FindElement
              (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[2]"));
            Thread.Sleep(4000);
            copyAncor.Click();

            var assetNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[1]/div/div/div/label"));
            Assert.IsTrue(assetNameLabel.Enabled);
            Assert.IsTrue(assetNameLabel.Displayed);
            Assert.AreEqual(assetNameLabel.Text, "Asset Name");
            Assert.AreEqual(assetNameLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetNameLabel.GetAttribute("class"), "form-label");

            var assetNameValue = driver.FindElement(By.Id("AssetDes"));
            assetNameValue.SendKeys("Test Name");
            Assert.IsTrue(assetNameValue.Enabled);
            Assert.IsTrue(assetNameValue.Displayed);
            Assert.AreEqual(assetNameValue.GetAttribute("type"), "text");
            Assert.AreEqual(assetNameValue.GetAttribute("maxlength"), "500");
            Assert.AreEqual(assetNameValue.GetAttribute("data-val"), "true");
            Assert.AreEqual(assetNameValue.GetAttribute("required"), "true");
            Assert.AreEqual(assetNameValue.GetAttribute("data-val-length-max"), "500");
            Assert.AreEqual(assetNameValue.GetAttribute("data-val-length"), "The field AssetDesc must be a string with a maximum length of 500.");

            var assetDescriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[2]/div/div/div/label"));
            Assert.IsTrue(assetDescriptionLabel.Enabled);
            Assert.IsTrue(assetDescriptionLabel.Displayed);
            Assert.AreEqual(assetDescriptionLabel.Text, "Description");
            Assert.AreEqual(assetDescriptionLabel.GetAttribute("for"), "Description");
            Assert.AreEqual(assetDescriptionLabel.GetAttribute("class"), "form-label-default ");

            var assetDescriptionValue = driver.FindElement(By.Id("AssetTypesDesc"));
            assetDescriptionValue.SendKeys("Test Name");
            Assert.IsTrue(assetDescriptionValue.Enabled);
            Assert.IsTrue(assetDescriptionValue.Displayed);
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val"), "true");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("maxlength"), "255");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("class"), "form-control valid");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val-required"), "The AssetNote field is required.");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val-length"), "The field AssetNote must be a string with a maximum length of 255.");

            var assetImageLabel = driver.FindElement
               (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[4]/div/div/div/label"));
            Assert.IsTrue(assetImageLabel.Enabled);
            Assert.IsTrue(assetImageLabel.Displayed);
            Assert.AreEqual(assetImageLabel.Text, "Asset Image");
            Assert.AreEqual(assetImageLabel.GetAttribute("for"), "ImagePath");
            Assert.AreEqual(assetImageLabel.GetAttribute("class"), "form-label-default");

            var Image = driver.FindElement(By.Id("ImagePath"));
            Assert.IsTrue(Image.Enabled);
            Assert.IsTrue(Image.Displayed);
            Assert.AreEqual(Image.GetAttribute("type"), "file");
            Assert.AreEqual(Image.GetAttribute("accept"), "image/*,.pdf");

            var assetClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[5]/div/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");
            Assert.AreEqual(assetClassLabel.GetAttribute("for"), "AssetClass");
            Assert.AreEqual(assetClassLabel.GetAttribute("class"), "form-label");

            var assetClassInput = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.AreEqual(assetClassInput.GetAttribute("required"), "true");
            Assert.AreEqual(assetClassInput.GetAttribute("class"), "form-control valid");

            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(0);

            var defaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetClassId\"]/option[1]"));
            Assert.IsTrue(defaultOption.Enabled);
            Assert.IsTrue(defaultOption.Displayed);
            Assert.AreEqual(defaultOption.Text, "Select Asset Class");

            // error asset subclass label must be linked with Assset Subclass but is linked with asset class
            var assetSubClassDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[6]/div/div/div/label"));
            Assert.IsTrue(assetSubClassDropdownlistLabel.Enabled);
            Assert.IsTrue(assetSubClassDropdownlistLabel.Displayed);
            Assert.AreEqual(assetSubClassDropdownlistLabel.Text, "Asset Subclass");
            Assert.AreEqual(assetSubClassDropdownlistLabel.GetAttribute("for"), "AssetSubclass");

            var assetSubClassDropdownlist = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetSubClassDropdownlist.Enabled);
            Assert.IsTrue(assetSubClassDropdownlist.Displayed);
            Assert.AreEqual(assetSubClassDropdownlist.GetAttribute("required"), "true");
            Assert.AreEqual(assetSubClassDropdownlist.GetAttribute("class"), "form-control");

            var AsseetSubclassDefaultOption = driver.FindElement(By.XPath("//*[@id=\"AssetSubClassIdDropdown\"]/option"));
            Assert.IsTrue(AsseetSubclassDefaultOption.Enabled);
            Assert.IsTrue(AsseetSubclassDefaultOption.Displayed);
            Assert.AreEqual(AsseetSubclassDefaultOption.Text, "Please select ...");


            // error asset type label must be linked with Assset Types but is linked with asset class
            var assetTypeDropdownlistLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[7]/div/div/div/label"));
            Assert.IsTrue(assetTypeDropdownlistLabel.Enabled);
            Assert.IsTrue(assetTypeDropdownlistLabel.Displayed);
            Assert.AreEqual(assetTypeDropdownlistLabel.Text, "Asset Type");
            Assert.AreEqual(assetTypeDropdownlistLabel.GetAttribute("for"), "AssetType");
            Assert.AreEqual(assetTypeDropdownlistLabel.GetAttribute("class"), "form-label");

            var assetTypeDropdownlistInput = driver.FindElement(By.Id("AssetClassId"));
            Assert.IsTrue(assetTypeDropdownlistInput.Enabled);
            Assert.IsTrue(assetTypeDropdownlistInput.Displayed);
            Assert.AreEqual(assetTypeDropdownlistInput.GetAttribute("required"), "true");

            var defaultOptionAssetType = driver.FindElement
                (By.XPath("//*[@id=\"AssetTypeIdDropdown\"]/option[1]"));
            Assert.IsTrue(defaultOptionAssetType.Enabled);
            Assert.IsTrue(defaultOptionAssetType.Displayed);
            Assert.AreEqual(defaultOptionAssetType.Text, "No Asset Types");


            /// error comment label must be linked with comment input but is linked with description
            var commentLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[8]/div/div/div/label"));
            Assert.IsTrue(commentLabel.Enabled);
            Assert.IsTrue(commentLabel.Displayed);
            Assert.AreEqual(commentLabel.Text, "Comments");
            Assert.AreEqual(commentLabel.GetAttribute("for"), "Comments");
            Assert.AreEqual(commentLabel.GetAttribute("class"), "form-label");

            var commentInput = driver.FindElement(By.Id("UnapprovedReason"));
            Assert.IsTrue(commentLabel.Enabled);
            commentInput.SendKeys("Test Comment");
            Assert.IsTrue(commentLabel.Displayed);
            Assert.AreEqual(commentInput.GetAttribute("class"), "form-control valid");

            var addAssociatedAttributeBtn = driver.FindElement(By.Id("btnAdd"));
            Assert.IsTrue(addAssociatedAttributeBtn.Enabled);
            Assert.IsTrue(addAssociatedAttributeBtn.Displayed);
            Assert.AreEqual(addAssociatedAttributeBtn.Text, "ADD");
            Assert.AreEqual(addAssociatedAttributeBtn.GetAttribute("class"), "btn btn-success btn-primary blue m-btn--wide m-btn--air");

            var cancelBtn = driver.FindElement(By.Id("cancle"));
            Assert.IsTrue(cancelBtn.Enabled);
            Assert.IsTrue(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text, "Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"), "button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect");
        }

        [Test]
        public void ReviewEditsPage_DeleteIcomTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var deleteAncor = driver.FindElement
              (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[9]/td[9]/a[3]"));
            Assert.IsTrue(deleteAncor.Enabled);
            Assert.IsTrue(deleteAncor.Displayed);
            Assert.AreEqual(deleteAncor.GetAttribute("title"), "Delete");
            Assert.IsTrue(deleteAncor.GetAttribute("onclick").Contains("deleteAsset"));

            var Icon = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[3]/i"));
            Assert.IsTrue(Icon.Enabled);
            Assert.IsTrue(Icon.Displayed);
            Assert.AreEqual(Icon.GetAttribute("class"), "fa fa-trash"); 
            Assert.AreEqual(Icon.GetAttribute("style"), "cursor: pointer;");
        }

        [Test]
        public void ReviewEditsPage_DeleteIconFormTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var deleteAncor = driver.FindElement
              (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[3]"));
            Thread.Sleep(4000);
            deleteAncor.Click();

            var deleteRequestModalTitle = driver.FindElement(By.XPath("//*[@id=\"DeleteRequestModal\"]/div/div/div[1]/h4"));
            Assert.IsTrue(deleteRequestModalTitle.Enabled);
            Assert.IsTrue(deleteRequestModalTitle.Displayed);
            Assert.AreEqual(deleteRequestModalTitle.Text, "Delete Request");

            var deleteRequestMessage = driver.FindElement(By.Id("DeleteRequestValue"));
            Assert.IsTrue(deleteRequestMessage.Enabled);
            Assert.IsTrue(deleteRequestMessage.Displayed);
            deleteRequestMessage.SendKeys("Test Message");

            var saveBtn = driver.FindElement(By.Id("DeleteRequestBtn"));
            Assert.IsTrue(saveBtn.Enabled);
            Assert.IsTrue(saveBtn.Displayed);
            Assert.AreEqual(saveBtn.GetAttribute("type"),"submit");
            Assert.AreEqual(saveBtn.GetAttribute("class"), "btn btn-primary waves-effect");

            var cancelBtn = driver.FindElement(By.XPath("//*[@id=\"DeleteRequestModal\"]/div/div/div[2]/button[2]"));
            Assert.IsTrue(cancelBtn.Enabled);
            Assert.IsTrue(cancelBtn.Displayed);
            Assert.AreEqual(cancelBtn.Text,"Cancel");
            Assert.AreEqual(cancelBtn.GetAttribute("type"),"button");
            Assert.AreEqual(cancelBtn.GetAttribute("class"), "btn btn-default waves-effect closeButtonDeleteRequest");
        }

        [Test]
        public void ReviewEditsPage_PaginateTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var previousBtn = driver.FindElement(By.Id("AssetsTable_previous"));
            Assert.IsTrue(previousBtn.Enabled);
            Assert.IsTrue(previousBtn.Displayed);
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.AreEqual(previousBtn.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(previousBtn.GetAttribute("class"), "paginate_button previous disabled");

            var nextBtn = driver.FindElement(By.Id("AssetsTable_next"));
            Assert.IsTrue(nextBtn.Enabled);
            Assert.IsTrue(nextBtn.Displayed);
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.AreEqual(nextBtn.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(nextBtn.GetAttribute("class"), "paginate_button next disabled");


            var pages = driver.FindElements(By.Id("AssetsTable_paginate"));
            foreach (var page in pages)
            {
                Assert.IsTrue(page.Displayed);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }
        }

        [Test]
        public void ReviewEditsPage_SideLeftMinimizeToggle()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            sideLeft.Click();
        }

        [Test]
        public void ReviewEditsPage_DataTableInfoTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var tableInfo = driver.FindElement(By.Id("AssetsTable_info"));
            Assert.IsTrue(tableInfo.Enabled);
            Assert.IsTrue(tableInfo.Displayed);
            Assert.IsTrue(tableInfo.Text.Contains("Showing"));
            Assert.IsTrue(tableInfo.Text.Contains("entries"));
            Assert.AreEqual(tableInfo.GetAttribute("role"),"status");
            Assert.AreEqual(tableInfo.GetAttribute("aria-live"),"polite");
            Assert.AreEqual(tableInfo.GetAttribute("class"), "dataTables_info");
        }

        [Test]
        public void ReviewEditsPage_CopyRightTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenPage();

            var copyRight = driver.FindElement
                (By.XPath("/html/body/footer/div/div/div[1]/span"));
            Assert.IsTrue(copyRight.Enabled);
            Assert.IsTrue(copyRight.Displayed);
            Assert.AreEqual(copyRight.Text, "2025 © CTDOT (Ver .)");
            Assert.AreEqual(copyRight.GetAttribute("class"), "m-footer__copyright");
        }
    }
}

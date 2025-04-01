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
        public void ReviewEditsPage_OpenReviewEditsPage()
        {
            var reviewEditsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[5]/a"));
            reviewEditsOption.Click();
        }

        [Test]
        public void ReviewEditPage_ReviewEditOptionTest()
        {
            var reviewEditsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[5]/a"));

            Assert.IsTrue(reviewEditsOption.Displayed);
            Assert.IsTrue(reviewEditsOption.Enabled);
            Assert.AreEqual(reviewEditsOption.Text, "Review Edits");
            Assert.AreEqual(reviewEditsOption.GetAttribute("custom-data"), "Review Edits");
            Assert.AreEqual(reviewEditsOption.GetAttribute("target"),"_self");
            Assert.AreEqual(reviewEditsOption.GetAttribute("href"), "http://ec2-34-226-24-71.compute-1.amazonaws.com/App/Assets/Management");
            reviewEditsOption.Click();
        }

        [Test]
        public void ReviewEditsPage_HiHostOperatorTest()
        {
            // to open review edit page
            ReviewEditsPage_OpenReviewEditsPage();

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
        public void ReviewEditsPage_LogoutBtn()
        {
            // to open review edit page
            ReviewEditsPage_OpenReviewEditsPage();

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
        public void ReviewEditsPage_PageTitleTest()
        {
            // to open review edit page
            ReviewEditsPage_OpenReviewEditsPage();

            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/h1/span"));
            Assert.AreEqual(title.Text, "Review Edits");
            Assert.IsTrue(title.Displayed);
            Assert.IsTrue(title.Enabled);
        }

        [Test]
        public void ReviewEditsPage_DashboardBtnTest()
        {
            // to open review edit page
            ReviewEditsPage_OpenReviewEditsPage();

            var dashboardBtn = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[1]/div/div/ul/li[1]/a/span"));
            Assert.AreEqual(dashboardBtn.Text, "Dashboard");
            Assert.IsTrue(dashboardBtn.Displayed);
            Assert.IsTrue(dashboardBtn.Enabled);
            var UrlBeforeClick = driver.Url;
            dashboardBtn.Click();
            var UrlAfterClick = driver.Url;
            Assert.AreNotEqual(UrlBeforeClick, UrlAfterClick);
        }


        [Test]
        public void ReviewEditsPage_AssetStateTest()
        {
            // to open review page 
            ReviewEditPage_ReviewEditOptionTest();

            var assetStateLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div/div/label"));
            Assert.AreEqual(assetStateLabel.Text, "Asset State");
            Assert.IsTrue(assetStateLabel.Displayed);
            Assert.IsTrue(assetStateLabel.Enabled);

            var assetStateInput = driver.FindElement(By.Id("AssetStateIdChange"));
            var selectedAssetState = new SelectElement(assetStateInput);
            selectedAssetState.SelectByIndex(0);
            Assert.IsTrue(assetStateInput.Displayed);
            Assert.IsTrue(assetStateInput.Enabled);
        }

        [Test]
        public void ReviewEditsPage_AssetClassTest()
        {
            // to open review page 
            ReviewEditPage_ReviewEditOptionTest();

            var assetClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[2]/div/div/label"));
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");

            var assetClassInput = driver.FindElement(By.XPath("//*[@id=\"AssetClassIdChange\"]"));
            var selectedAssetclass = new SelectElement(assetClassInput);
            selectedAssetclass.SelectByIndex(0);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.IsTrue(assetClassInput.Enabled);
        }

        [Test]
        public void ReviewEditsPage_AssetSubClassTest()
        {
            // to open review page 
            ReviewEditPage_ReviewEditOptionTest();
            var assetSubClassLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[3]/div/div/label"));
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");

            var assetSubClassInput = driver.FindElement(By.Id("AssetSubClassDropDownChange"));
            var selectedAssetSubClass = new SelectElement(assetSubClassInput);
            selectedAssetSubClass.SelectByIndex(0);
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.IsTrue(assetSubClassInput.Enabled);
        }

        [Test]
        public void ReviewEditsPage_AssetTypeTest()
        {
            // to open review page 
            ReviewEditPage_ReviewEditOptionTest();

            var assetTypeLabel = driver.FindElement
                (By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div[4]/div/div/label"));
            Assert.IsTrue(assetTypeLabel.Displayed);
            Assert.IsTrue(assetTypeLabel.Enabled);
            Assert.AreEqual(assetTypeLabel.Text, "Asset Type");

            var assetTypeInput = driver.FindElement(By.Id("AssetTypeDropDownChange"));
            var selectedAssetType = new SelectElement(assetTypeInput);
            selectedAssetType.SelectByIndex(0);
            Assert.IsTrue(assetTypeInput.Displayed);
            Assert.IsTrue(assetTypeInput.Enabled);
        }

        [Test]
        public void ReviewEditsPage_DataTableLengthTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            var lengthLabel = driver.FindElement(By.XPath("//*[@id=\"AssetsTable_length\"]/label"));
            Assert.IsTrue(lengthLabel.Enabled);
            Assert.IsTrue(lengthLabel.Text.Contains("Show"));

            var lengthValue = driver.FindElement(By.Name("AssetsTable_length"));
            var selectedLengthValue = new SelectElement(lengthValue);
            selectedLengthValue.SelectByIndex(1);
            Assert.IsTrue(lengthValue.Displayed);
            Assert.IsTrue(lengthValue.Enabled);
        }

        [Test]
        public void ReviewEditsPage_DataTableFilterTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            var tableFilterLabel = driver.FindElement
                (By.Id("AssetsTable_filter"));
            Assert.IsTrue(tableFilterLabel.Displayed);
            Assert.AreEqual(tableFilterLabel.Text,"Search:");

            var tableFilterInput = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable_filter\"]/label/input"));
            tableFilterInput.SendKeys("Code");
            Assert.IsTrue(tableFilterInput.Displayed);
            Assert.IsTrue(tableFilterInput.Enabled);
        }

        [Test]
        public void ReviewEditsPage_ReOrderTableTest()
        {
            // to open reviw edits page
            var reviewEditsOption = driver.FindElement
                (By.XPath("//*[@id=\"m_ver_menu\"]/ul/li[5]/a"));
            reviewEditsOption.Click();

            var columns = driver.FindElements(By.Id("AssetsTable"));
            foreach (var column in columns)
            {
                Assert.IsTrue(column.Displayed);
                Assert.IsTrue(column.Enabled);
            }
            var AssetId = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[1]"));
            Assert.IsTrue(AssetId.Displayed);
            Assert.IsTrue(AssetId.Enabled);
            Assert.AreEqual(AssetId.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(AssetId.GetAttribute("aria-label"), "Asset ID: activate to sort column ascending");
            //AssetId.Click();

            var AssetClass = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(AssetClass.Displayed);
            Assert.IsTrue(AssetClass.Enabled);
            Assert.AreEqual(AssetClass.Text, "Asset Class");
            Assert.AreEqual(AssetClass.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(AssetClass.GetAttribute("aria-label"), "Asset Class: activate to sort column ascending");
            //AssetClass.Click();

            var AssetSubClass = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(AssetSubClass.Displayed);
            Assert.IsTrue(AssetSubClass.Enabled);
            Assert.AreEqual(AssetSubClass.Text, "Asset Subclass");
            Assert.AreEqual(AssetSubClass.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(AssetSubClass.GetAttribute("aria-label"), "Asset Subclass: activate to sort column ascending");
            //AssetSubClass.Click();

            var AssetType = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[4]"));
            Assert.IsTrue(AssetType.Displayed);
            Assert.IsTrue(AssetType.Enabled);
            Assert.AreEqual(AssetType.Text, "Asset Type"); 
            Assert.AreEqual(AssetType.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(AssetType.GetAttribute("aria-label"), "Asset Type: activate to sort column ascending");
            //AssetType.Click();

            var Asset = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[5]"));
            Assert.IsTrue(Asset.Displayed);
            Assert.IsTrue(Asset.Enabled);
            Assert.AreEqual(Asset.Text, "Asset"); 
            Assert.AreEqual(Asset.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(Asset.GetAttribute("aria-label"), "Asset: activate to sort column ascending");
            //Asset.Click();

            var State = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[6]"));
            Assert.IsTrue(State.Displayed);
            Assert.IsTrue(State.Enabled);
            Assert.AreEqual(State.Text, "State");
            Assert.AreEqual(State.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(State.GetAttribute("aria-label"), "State: activate to sort column ascending");
            //State.Click();

            var createTime = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[7]"));
            Assert.IsTrue(createTime.Displayed);
            Assert.IsTrue(createTime.Enabled);
            Assert.AreEqual(createTime.Text, "Created Time");
            Assert.AreEqual(createTime.GetAttribute("aria-controls"), "AssetsTable");
            Assert.AreEqual(createTime.GetAttribute("aria-label"), "Created Time: activate to sort column ascending");
            //createTime.Click();

            var Actions = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/thead/tr/th[8]"));
            Assert.IsTrue(Actions.Displayed);
            Assert.IsTrue(Actions.Enabled);
            Assert.AreEqual(Actions.Text, "Actions");
        }

        [Test]
        public void ReviewEditsPage_StatusIConTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            Thread.Sleep(4000);
            var statusIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[4]"));
            Assert.AreEqual(statusIcon.GetAttribute("title"), "Status");
            statusIcon.Click();
            Assert.IsTrue(statusIcon.Displayed);
            Assert.IsTrue(statusIcon.Enabled);
            Assert.AreEqual(statusIcon.GetAttribute("onclick"), "statusAsset(16003)");
        }

        [Test]
        public void ReviewEditsPage_StatusAssetTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            Thread.Sleep(4000);
            var statusIcon = driver.FindElement(By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[4]"));
            statusIcon.Click();

            var state = driver.FindElement(By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[1]"));
            Assert.IsTrue(state.Displayed);
            Assert.IsTrue(state.Enabled);
            Assert.AreEqual(state.Text, "State");

            var remarks = driver.FindElement(By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[2]"));
            Assert.IsTrue(remarks.Displayed);
            Assert.IsTrue(remarks.Enabled);
            Assert.AreEqual(remarks.Text, "Remarks");

            var createdBy = driver.FindElement(By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[3]"));
            Assert.IsTrue(createdBy.Displayed);
            Assert.IsTrue(createdBy.Enabled);
            Assert.AreEqual(createdBy.Text, "Created By");

            var createdTime = driver.FindElement(By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[4]"));
            Assert.IsTrue(createdTime.Displayed);
            Assert.IsTrue(createdTime.Enabled);
            Assert.AreEqual(createdTime.Text, "Created Time");

            var View = driver.FindElement(By.XPath("//*[@id=\"StatusTable\"]/thead/tr/th[5]"));
            Assert.IsTrue(View.Displayed);
            Assert.IsTrue(View.Enabled);
            Assert.AreEqual(View.Text, "View");

            var closeIcon = driver.FindElement(By.Id("closeButtonStatus"));
            Assert.AreEqual(closeIcon.GetAttribute("type"), "button");
            Assert.IsTrue(closeIcon.Displayed);
            Assert.IsTrue(closeIcon.Enabled);
        }

        [Test]
        public void ReviewEditsPage_EditIconTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            var editIcon = driver.FindElement(By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[1]"));
            Assert.AreEqual(editIcon.GetAttribute("title"), "Edit");
            Assert.AreEqual(editIcon.GetAttribute("style"), "cursor:pointer");
            Assert.IsTrue(editIcon.Displayed);
            Assert.IsTrue(editIcon.Enabled);
            editIcon.Click();
        }

        [Test]
        public void ReviewEditsPage_EditAssetTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            var editIcon = driver.FindElement(By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[2]/td[9]/a[1]"));
            Thread.Sleep(4000);
            editIcon.Click();

            var assetNameLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[1]/div/div/div/label"));
            Assert.IsTrue(assetNameLabel.Enabled);

            var assetNameValue = driver.FindElement(By.Id("AssetDes"));
            var requiredNameLength = "The field AssetDesc must be a string with a maximum length of 500.";
            assetNameValue.SendKeys("Test Name");
            Assert.AreEqual(requiredNameLength, assetNameValue.GetAttribute("data-val-length"));
            Assert.AreEqual(assetNameValue.GetAttribute("required"), "true");
            Assert.AreEqual(assetNameValue.GetAttribute("maxlength"), "500");

            var assetDescriptionLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[2]/div/div/div/label"));
            Assert.IsTrue(assetDescriptionLabel.Enabled);

            var assetDescriptionValue = driver.FindElement(By.Id("AssetTypesDesc"));
            var requiredDescriptionLength = "The field AssetNote must be a string with a maximum length of 255.";
            Assert.IsTrue(assetDescriptionValue.Displayed);
            Assert.IsTrue(assetDescriptionValue.Enabled);
            assetDescriptionValue.SendKeys("Test Name");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("data-val-length"), requiredDescriptionLength);
            //Assert.AreEqual(assetDescriptionValue.GetAttribute("required"), "true");
            Assert.AreEqual(assetDescriptionValue.GetAttribute("maxlength"), "255");

            var assetImageLabel = driver.FindElement
               (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[4]/div/div/div/label"));
            Assert.IsTrue(assetImageLabel.Enabled);
            Assert.IsTrue(assetImageLabel.Displayed);
            Assert.AreEqual(assetImageLabel.Text, "Asset Image");

            var assetClassInput = driver.FindElement(By.Id("AssetClassId"));
            var selectedAssetClass = new SelectElement(assetClassInput);
            selectedAssetClass.SelectByIndex(0);
            Assert.IsTrue(assetClassInput.Displayed);
            Assert.IsTrue(assetClassInput.Enabled);
            Assert.AreEqual(assetClassInput.GetAttribute("required"), "true");

            var assetClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[5]/div/div/div/label"));
            Assert.IsTrue(assetClassLabel.Enabled);
            Assert.IsTrue(assetClassLabel.Displayed);
            Assert.AreEqual(assetClassLabel.Text, "Asset Class");

            var assetSubClassInput = driver.FindElement(By.Id("AssetClassId"));
            var selectedAssetSubClass = new SelectElement(assetSubClassInput);
            Assert.IsTrue(assetSubClassInput.Displayed);
            Assert.IsTrue(assetSubClassInput.Enabled);
            Assert.AreEqual(assetSubClassInput.GetAttribute("required"), "true");

            var assetSubClassLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[6]/div/div/div/label"));
            Assert.IsTrue(assetSubClassLabel.Enabled);
            Assert.IsTrue(assetSubClassLabel.Displayed);
            Assert.AreEqual(assetSubClassLabel.Text, "Asset Subclass");

            var assetTypeInput = driver.FindElement(By.Id("AssetClassId"));
            var selectedAssetType = new SelectElement(assetTypeInput);
            Assert.IsTrue(assetTypeInput.Displayed);
            Assert.IsTrue(assetTypeInput.Enabled);
            Assert.AreEqual(assetTypeInput.GetAttribute("required"), "true");

            var commentLabel = driver.FindElement
                (By.XPath("//*[@id=\"AssetCreateModal\"]/form/div[8]/div/div/div/label"));
            Assert.IsTrue(commentLabel.Enabled);
            Assert.IsTrue(commentLabel.Displayed);
            Assert.AreEqual(commentLabel.Text,"Comments");

            var commentInput = driver.FindElement(By.Id("UnapprovedReason"));
            Assert.IsTrue(commentLabel.Enabled);
            Assert.IsTrue(commentLabel.Displayed);
            commentInput.SendKeys("Test Comment");
        }

        [Test]
        public void ReviewEditsPage_CopyIconTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            var copyIcon = driver.FindElement
                (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[8]/td[9]/a[2]"));
            Assert.AreEqual(copyIcon.GetAttribute("title"),"Copy");
            Assert.AreEqual(copyIcon.GetAttribute("onclick"), "copyAsset(15980)");
            Assert.IsTrue(copyIcon.Displayed);
            Assert.IsTrue(copyIcon.Enabled);
            copyIcon.Click();
        }

        [Test]
        public void ReviewEditsPage_CopyAssetTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();
            var copyIcon = driver.FindElement
              (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[8]/td[9]/a[2]"));
            copyIcon.Click();

        }

        [Test]
        public void ReviewEditsPage_DeleteIcomTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            var deleteIcon = driver.FindElement
              (By.XPath("//*[@id=\"AssetsTable\"]/tbody/tr[9]/td[9]/a[3]"));
            Assert.AreEqual(deleteIcon.GetAttribute("title"), "Delete");
            Assert.AreEqual(deleteIcon.GetAttribute("onclick"), "deleteAsset(15981)");
            Assert.IsTrue(deleteIcon.Displayed);
            Assert.IsTrue(deleteIcon.Enabled);
            deleteIcon.Click();
        }

        [Test]
        public void ReviewEditsPage_PaginateTest()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            var previousBtn = driver.FindElement(By.Id("AssetsTable_previous"));
            Assert.AreEqual(previousBtn.Text, "Previous");
            Assert.IsTrue(previousBtn.Enabled);

            var nextBtn = driver.FindElement(By.Id("AssetsTable_next"));
            Assert.AreEqual(nextBtn.Text, "Next");
            Assert.IsTrue(previousBtn.Displayed);
            Assert.IsTrue(previousBtn.Enabled);

            var pages = driver.FindElements(By.Id("AssetsTable_paginate"));
            foreach (var page in pages)
            {
                Assert.IsTrue(page.Displayed);
                Assert.IsTrue(page.Displayed);
                page.Click();
            }
        }

        [Test]
        public void AssetAuditPage_SideLeftMinimizeToggle()
        {
            // to open reviw edits page
            ReviewEditsPage_OpenReviewEditsPage();

            var sideLeft = driver.FindElement(By.Id("m_aside_left_minimize_toggle"));
            Assert.AreEqual(sideLeft.GetAttribute("href"), "javascript:;");
            Assert.IsTrue(sideLeft.Enabled);
            Assert.IsTrue(sideLeft.Displayed);
            sideLeft.Click();
        }
    }
}

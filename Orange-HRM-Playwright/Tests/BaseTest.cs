using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Orange_HRM_Playwright.Pages;

namespace Orange_HRM_Playwright.Tests
{
    public class BaseTest : PageTest
    {
        protected IPage pageTest;
        public LandingPage landing;
        public DashboardPage dashboardPage;
        public AdminPage adminPage;
        public LeavePage leavePage;
        private readonly IBrowserContext context;
        
        
        [OneTimeSetUp]
        public async Task SetUp()
        {
            var playWrightTool = await Microsoft.Playwright.Playwright.CreateAsync();
            var browser = await playWrightTool.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            pageTest = await browser.NewPageAsync();
            await pageTest.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            landing = new LandingPage(pageTest);
            dashboardPage = new DashboardPage(pageTest);
            adminPage = new AdminPage(pageTest);
            leavePage = new LeavePage(pageTest);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Page.CloseAsync();
        }
    }
}
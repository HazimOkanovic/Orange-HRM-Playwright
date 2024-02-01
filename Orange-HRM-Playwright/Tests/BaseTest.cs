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
        public LandingPage landingPage;
        public DashboardPage dashboardPage;
        public AdminPage adminPage;
        public LeavePage leavePage;
        public PIMPage pimPage;
        private readonly IBrowserContext context;
        
        
        [OneTimeSetUp]
        public async Task SetUp()
        {
            var playWrightTool = await Microsoft.Playwright.Playwright.CreateAsync();
            var browser = await playWrightTool.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            pageTest = await browser.NewPageAsync();
            await pageTest.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            landingPage = new LandingPage(pageTest);
            dashboardPage = new DashboardPage(pageTest);
            adminPage = new AdminPage(pageTest);
            leavePage = new LeavePage(pageTest);
            pimPage = new PIMPage(pageTest);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            pageTest.CloseAsync();
        }
    }
}
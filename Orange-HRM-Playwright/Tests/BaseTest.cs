using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Orange_HRM_Playwright.Pages;

namespace Orange_HRM_Playwright.Tests
{
    public class BaseTest : PageTest
    {
        protected LandingPage landing;
        [OneTimeSetUp]
        public async Task SetUp()
        {
            var playWrightTool = await Microsoft.Playwright.Playwright.CreateAsync();
            var browser = await playWrightTool.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            landing = new LandingPage(await browser.NewPageAsync());
            await landing.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Page.CloseAsync();
        }
    }
}
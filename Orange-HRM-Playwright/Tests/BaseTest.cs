using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Orange_HRM_Playwright.Tests
{
    public class BaseTest : PageTest
    {
        [OneTimeSetUp]
        public async Task SetUp()
        {
            var playWrightTool = await Microsoft.Playwright.Playwright.CreateAsync();
            var browser = await playWrightTool.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            //landing = new LandingPage(await browser.NewPageAsync());
            //await landing.GotoAsync("https://klika-uptime-2022.herokuapp.com/");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Page.CloseAsync();
        }
    }
}
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Orange_HRM_Playwright.Pages
{
    public class BasePage
    {
        protected IPage page;

        protected BasePage(IPage page)
        {
            this.page = page;
        }
        
        public async Task GotoAsync(string url)
        {
            await page.GotoAsync(url);
        }

        public async void ClickElement(ILocator locator)
        {
            try
            {
                await locator.ClickAsync();
            }
            catch
            {
                Assert.IsTrue(false, "Element does not exist with xpath: " + locator);
            }
        }
    
        public async void ClearField(ILocator locator)
        {
            try
            {
                await locator.ClearAsync();
            }
            catch
            {
                Assert.IsTrue(false, "Element does not exist with xpath: " + locator);
            }
        }
        
        public async void EnterText(ILocator locator, string text)
        {
            try
            {
                await locator.TypeAsync(text);
            }
            catch
            {
                Assert.IsTrue(false, "Element does not exist with xpath: " + locator);
            }
        }

        public string GetText(ILocator locator)
        {
            return locator.InnerTextAsync().Result;
        }
    }
}
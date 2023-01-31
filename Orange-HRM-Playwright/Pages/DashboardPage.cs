using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class DashboardPage : BasePage
    {
        private readonly ILocator pageTitle;
        
        public DashboardPage(IPage page) : base(page)
        {
            pageTitle = page.Locator("//span//h6");
        }

        public string GetTitle()
        {
            return GetText(pageTitle);
        }
    }
}
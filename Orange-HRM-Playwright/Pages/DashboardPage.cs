using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class DashboardPage : BasePage
    {
        private readonly ILocator pageTitle;
        private readonly ILocator userDropdown;
        private readonly ILocator logOutButton;
        
        public DashboardPage(IPage page) : base(page)
        {
            pageTitle = page.Locator("//span//h6");
            userDropdown = page.Locator("//span//p[@class = 'oxd-userdropdown-name']");
            logOutButton = page.Locator("(//ul//li//a[@role = 'menuitem'])[4]");
        }

        public string GetTitle()
        {
            return GetText(pageTitle);
        }

        public LandingPage LogOut()
        {
            ClickElement(userDropdown);
            ClickElement(logOutButton);
            return new LandingPage(page);
        }
    }
}
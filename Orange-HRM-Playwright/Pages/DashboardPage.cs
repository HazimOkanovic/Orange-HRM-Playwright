using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class DashboardPage
    {
        private readonly IPage page;
        private readonly ILocator pageTitle;
        private readonly ILocator userDropdown;
        private readonly ILocator logOutButton;
        private readonly ILocator adminButton;
        private readonly ILocator pimButton;
        private readonly ILocator leaveButton;
        private readonly ILocator timeButton;
        private readonly ILocator recruitmentButton;
        private readonly ILocator myInfoButton;
        private readonly ILocator performanceButton;
        private readonly ILocator dashboardButton;
        private readonly ILocator directoryButton;
        private readonly ILocator maintenanceButton;
        private readonly ILocator buzzButton;
        
        public DashboardPage(IPage page)
        {
            this.page = page;
            pageTitle = page.Locator("//span//h6");
            userDropdown = page.Locator("//span//p[@class = 'oxd-userdropdown-name']");
            logOutButton = page.Locator("(//ul//li//a[@role = 'menuitem'])[4]");
            adminButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[1]");
            pimButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[2]");
            leaveButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[3]");
            timeButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[4]");
            recruitmentButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[5]");
            myInfoButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[6]");
            performanceButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[7]");
            dashboardButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[8]");
            directoryButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[9]");
            maintenanceButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[10]");
            buzzButton = page.Locator("(//a//span[contains(@class, 'menu-item')])[11]");
        }

        public async Task<string> GetTitle()
        {
            return await pageTitle.InnerTextAsync();
        }

        public async Task ClickAdminButton()
        {
            await adminButton.ClickAsync();
        }

        public async Task ClickBuzzButton()
        {
            await buzzButton.ClickAsync();
        }

        public async Task ClickDirectoryButton()
        {
            await directoryButton.ClickAsync();
        }

        public async Task ClickLeaveButton()
        {
            await leaveButton.ClickAsync();
        }

        public async Task ClickMaintenanceButton()
        {
            await maintenanceButton.ClickAsync();
        }

        public async Task ClickMyInfoButton()
        {
            await myInfoButton.ClickAsync();
        }

        public async Task ClickPerformanceButton()
        {
            await performanceButton.ClickAsync();
        }

        public async Task ClickPimButton()
        {
            await pimButton.ClickAsync();
        }

        public async Task ClickRecruitmentPage()
        {
            await recruitmentButton.ClickAsync();
        }

        public async Task ClickTimeButton()
        {
            await timeButton.ClickAsync();
        }

        public async Task LogOut()
        {
            await userDropdown.ClickAsync();
            await logOutButton.ClickAsync();
        }
    }
}
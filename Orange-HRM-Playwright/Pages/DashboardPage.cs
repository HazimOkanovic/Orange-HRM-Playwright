using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class DashboardPage : BasePage
    {
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
        
        public DashboardPage(IPage page) : base(page)
        {
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

        public string GetTitle()
        {
            return GetText(pageTitle);
        }

        public AdminPage ClickAdminButton()
        {
            ClickElement(adminButton);
            return new AdminPage(page);
        }

        public BuzzPage ClickBuzzButton()
        {
            ClickElement(buzzButton);
            return new BuzzPage(page);
        }

        public DirectoryPage ClickDirectoryButton()
        {
            ClickElement(directoryButton);
            return new DirectoryPage(page);
        }

        public LeavePage ClickLeaveButton()
        {
            ClickElement(leaveButton);
            return new LeavePage(page);
        }

        public MaintenancePage ClickMaintenanceButton()
        {
            ClickElement(maintenanceButton);
            return new MaintenancePage(page);
        }

        public MyInfoPage ClickMyInfoButton()
        {
            ClickElement(myInfoButton);
            return new MyInfoPage(page);
        }

        public PerformancePage ClickPerformanceButton()
        {
            ClickElement(performanceButton);
            return new PerformancePage(page);
        }

        public PIMPage ClickPimButton()
        {
            ClickElement(pimButton);
            return new PIMPage(page);
        }

        public RecruitmentPage ClickRecruitmentPage()
        {
            ClickElement(recruitmentButton);
            return new RecruitmentPage(page);
        }

        public TimePage ClickTimeButton()
        {
            ClickElement(timeButton);
            return new TimePage(page);
        }

        public LandingPage LogOut()
        {
            ClickElement(userDropdown);
            ClickElement(logOutButton);
            return new LandingPage(page);
        }
    }
}
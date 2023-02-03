using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class LeavePage : BasePage
    {
        private readonly ILocator applyButtonTopPage;
        private readonly ILocator pageTitle;
        private readonly ILocator applyLeaveTitle;
        private readonly ILocator leaveType;
        private readonly ILocator partialDays;
        private readonly ILocator durationField;
        private readonly ILocator applyButton;
        private readonly ILocator balanceMessage;
        
        public LeavePage(IPage page) : base(page)
        {
            applyButtonTopPage = page.Locator("//li//a[contains(text(), 'Apply')]");
            pageTitle = page.Locator("(//span//h6)[1]");
            applyLeaveTitle = page.Locator("(//div//h6)[2]");
            leaveType = page.Locator("(//div//div[@class = 'oxd-select-text-input'])[1]");
            partialDays = page.Locator("(//div//div[@class = 'oxd-select-text-input'])[2]");
            durationField = page.Locator("(//div//div[@class = 'oxd-select-text-input'])[3]");
            applyButton = page.Locator("//div//button[@type = 'submit']");
            balanceMessage = page.Locator("(//div//p[contains(@class,  'oxd-text--p')])[1]");
        }
    }
}
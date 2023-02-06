using System.Threading;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class LeavePage : BasePage
    {
        private readonly ILocator applyButtonTopPage;
        private readonly ILocator pageTitle;
        private readonly ILocator assignLeaveButton;
        private readonly ILocator leaveTypeButton;
        private readonly ILocator assignLeaveTitle;
        
        public LeavePage(IPage page) : base(page)
        {
            applyButtonTopPage = page.Locator("//li//a[contains(text(), 'Apply')]");
            pageTitle = page.Locator("(//span//h6)[1]");
            leaveTypeButton = page.Locator("//div//i[contains(@class, 'oxd-select-text--arrow')]");
            assignLeaveButton = page.Locator("//ul//li//a[contains(text(), 'Assign Leave')]");
            assignLeaveTitle = page.Locator("(//div//h6)[2]");
        }
        
        public string GetLeaveTitle()
        {
            return GetText(pageTitle);
        }

        public string GetAssignLeaveTitle()
        {
            return GetText(assignLeaveTitle);
        }

        public LeavePage ClickApplyButton()
        {
            ClickElement(applyButtonTopPage);
            return this;
        }

        public LeavePage ClickAssignLeave()
        {
            ClickElement(assignLeaveButton);
            return this;
        }
        
        public LeavePage EnterEmployeeName(string name)
        {
            page.GetByPlaceholder("Type for hints...").FillAsync(name);
            return this;
        }
        
        public LeavePage ClickOnEmployeeNameSuggestion()
        {
            Thread.Sleep(1000);
            page.Locator("'Fiona Grace'").ClickAsync();
            return this;
        }

        public LeavePage ClickOnLeaveType()
        {
            ClickElement(leaveTypeButton);
            return this;
        }
    }
}
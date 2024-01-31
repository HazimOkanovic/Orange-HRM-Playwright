using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class LeavePage
    {
        private readonly IPage page;
        private readonly ILocator pageTitle;
        private readonly ILocator assignLeaveButton;
        private readonly ILocator leaveTypeButton;
        private readonly ILocator assignLeaveTitle;
        private readonly ILocator fromDateButton;
        private readonly ILocator assignButton;
        private readonly ILocator cardTitle;
        private readonly ILocator okButton;
        private readonly ILocator myLeaveButton;
    
        public LeavePage(IPage page)
        {
            this.page = page;
            pageTitle = page.Locator("(//span//h6)[1]");
            leaveTypeButton = page.Locator("//div//i[contains(@class, 'oxd-select-text--arrow')]");
            assignLeaveButton = page.Locator("//ul//li//a[contains(text(), 'Assign Leave')]");
            assignLeaveTitle = page.Locator("(//div//h6)[2]");
            fromDateButton = page.Locator("(//div//i[contains(@class, 'oxd-date-input')])[1]");
            assignButton = page.Locator("//div//button[@type = 'submit']");
            cardTitle = page.Locator("//div//p[contains(@class, 'text--card-title')]");
            okButton = page.Locator("(//div//button[contains(@class, 'button--secondary')])[2]");
            myLeaveButton = page.Locator("//ul//li//a[contains(text(), 'My Leave')]");
        }
        
        public async Task<string> GetLeaveTitle()
        {
            return await pageTitle.InnerTextAsync();
        }

        public async Task<string> GetAssignLeaveTitle()
        {
            return await assignLeaveTitle.InnerTextAsync();
        }

        public async Task<string> GetCardTitle()
        {
            return await cardTitle.InnerTextAsync();
        }

        public async Task<string> GetCustomError(int fieldNumber)
        {
            string element = "(//div//span[contains(@class, 'oxd-input-group__message')])[{0}]";
            element = String.Format(element, fieldNumber);
            ILocator elementLocation = page.Locator(element);
            return await elementLocation.InnerTextAsync();
        }

        public async Task ClickOkButton()
        {
            await okButton.ClickAsync();
        }

        public async Task ClickMyLeave()
        {
            await myLeaveButton.ClickAsync();
        }

        public async Task ClickAssignLeave()
        {
            await assignLeaveButton.ClickAsync();
        }
        
        public async Task EnterEmployeeName(string name)
        {
            await page.GetByPlaceholder("Type for hints...").FillAsync(name);
        }
        
        public async Task ClickOnEmployeeNameSuggestion()
        {
            await page.Locator("'Fiona Grace'").ClickAsync();
        }

        public async Task ClickOnLeaveType()
        {
            await leaveTypeButton.InnerTextAsync();
        }
        
        public async Task<string> GetUserNameAfterSave(string user)
        {
            string element = "//div//div[contains(text(), '{0}')]";
            element = String.Format(element, user);
            ILocator elementLocation = page.Locator(element);
            return await elementLocation.InnerTextAsync();
        }

        public async Task ClickOnFromDate()
        {
            await fromDateButton.ClickAsync();
        }
        
        public async Task ChooseLeaveType()
        {
            await page.Locator("'Personal'").ClickAsync();
        }
        
        public async Task ChooseFromDate()
        {
            await page.Locator("'22'").ClickAsync();
        }

        public async Task ClickApplyButton()
        {
            await assignButton.ClickAsync();
        }
    }
}
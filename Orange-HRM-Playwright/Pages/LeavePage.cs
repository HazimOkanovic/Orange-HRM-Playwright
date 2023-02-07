using System;
using System.Threading;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class LeavePage : BasePage
    {
        private readonly ILocator pageTitle;
        private readonly ILocator assignLeaveButton;
        private readonly ILocator leaveTypeButton;
        private readonly ILocator assignLeaveTitle;
        private readonly ILocator fromDateButton;
        private readonly ILocator assignButton;
        private readonly ILocator cardTitle;
        private readonly ILocator okButton;
        private readonly ILocator myLeaveButton;
    
        public LeavePage(IPage page) : base(page)
        {
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
        
        public string GetLeaveTitle()
        {
            return GetText(pageTitle);
        }

        public string GetAssignLeaveTitle()
        {
            return GetText(assignLeaveTitle);
        }

        public string GetCardTitle()
        {
            return GetText(cardTitle);
        }

        public string GetCustomError(int fieldNumber)
        {
            string element = "(//div//span[contains(@class, 'oxd-input-group__message')])[{0}]";
            element = String.Format(element, fieldNumber);
            ILocator elementLocation = page.Locator(element);
            return GetText(elementLocation);
        }

        public LeavePage ClickOkButton()
        {
            ClickElement(okButton);
            return this;
        }

        public LeavePage ClickMyLeave()
        {
            ClickElement(myLeaveButton);
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
        
        public string GetUserNameAfterSave(string user)
        {
            string element = "//div//div[contains(text(), '{0}')]";
            element = String.Format(element, user);
            ILocator elementLocation = page.Locator(element);
            return GetText(elementLocation);
        }

        public LeavePage ClickOnFromDate()
        {
            ClickElement(fromDateButton);
            return this;
        }
        
        public LeavePage ChooseLeaveType()
        {
            Thread.Sleep(500);
            page.Locator("'Personal'").ClickAsync();
            return this;
        }
        
        public LeavePage ChooseFromDate()
        {
            Thread.Sleep(500);
            page.Locator("'22'").ClickAsync();
            return this;
        }

        public LeavePage ClickApplyButton()
        {
            ClickElement(assignButton);
            return this;
        }
    }
}
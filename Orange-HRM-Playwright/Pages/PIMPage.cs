using System;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class PIMPage : BasePage
    {
        private readonly ILocator pageTitle;
        private readonly ILocator employeeNameInput;
        private readonly ILocator employeeIdInput;
        private readonly ILocator searchButton;
        private readonly ILocator addButton;
        private readonly ILocator employeeId;
        private readonly ILocator addEmployeeTitle;

        public string NewEmployeeId;
        
        public PIMPage(IPage page) : base(page)
        {
            pageTitle = page.Locator("(//span//h6)[1]");
            employeeNameInput = page.Locator("(//div//input[contains(@placeholder, 'Type')])[1]");
            employeeIdInput = page.Locator("(//div//input[contains(@class, 'oxd-input')])[2]");
            searchButton = page.Locator("//div//button[@type = 'submit']");
            addButton = page.Locator("(//div//button[contains(@class, 'oxd-button')])[3]");
            employeeId = page.Locator("(//div//input[contains(@class, 'oxd-input')])[5]");
            addEmployeeTitle = page.Locator("(//div//h6)[2]");
        }
        
        public string GetAdminTitle()
        {
            return GetText(pageTitle);
        }

        public PIMPage EnterEmployeeName(string employeeName)
        {
            EnterText(employeeNameInput, employeeName);
            return this;
        }

        public PIMPage EnterEmployeeId(string id)
        {
            EnterText(employeeIdInput, id);
            return this;
        }

        public PIMPage ClickSearch()
        {
            ClickElement(searchButton);
            return this;
        }

        public PIMPage ClickAddButton()
        {
            ClickElement(addButton);
            return this;
        }

        public PIMPage EnterFirstName(string firstName)
        {
            page.GetByPlaceholder("First Name").FillAsync(firstName);
            return this;
        }

        public PIMPage EnterMiddleName(string middleName)
        {
            page.GetByPlaceholder("Middle Name").FillAsync(middleName);
            return this;
        }

        public PIMPage EnterLastName(string lastName)
        {
            page.GetByPlaceholder("Last Name").FillAsync(lastName);
            return this;
        }

        public string GetEmployeeId()
        {
            NewEmployeeId = GetText(employeeId);
            return NewEmployeeId;
        }

        public PIMPage ClickSave()
        {
            ClickElement(searchButton);
            return this;
        }

        public string GetEmployeeTitle()
        {
            return GetText(addEmployeeTitle);
        }
        
        public string GetEmployeeName(string user)
        {
            string element = "//div//div[contains(text(), '{0}')]";
            element = String.Format(element, user);
            ILocator elementLocation = page.Locator(element);
            return GetText(elementLocation);
        }
        
        public PIMPage ClickOnEmployeeName(string user)
        {
            string element = "//div//div[contains(text(), '{0}')]";
            element = String.Format(element, user);
            ILocator elementLocation = page.Locator(element);
            ClickElement(elementLocation);
            return this;
        }
    }
}
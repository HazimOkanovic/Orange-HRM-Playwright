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
        private readonly ILocator firstNameInput;
        private readonly ILocator lastNameInput;
        private readonly ILocator middleNameInput;
        private readonly ILocator firstNameError;
        private readonly ILocator personalDetails;
        private readonly ILocator noRecordsLabel;

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
            personalDetails = page.Locator("(//div//h6)[3]");
            firstNameInput = page.Locator("//div//input[@name='firstName']");
            middleNameInput = page.Locator("//div//input[@name='middleName']");
            lastNameInput = page.Locator("//div//input[@name='lastName']");
            noRecordsLabel = page.Locator("(//div//span[@class = 'oxd-text oxd-text--span'])[1]");
        }
        
        public string GetPimTitle()
        {
            return GetText(pageTitle);
        }

        public PIMPage EnterEmployeeName(string employeeName)
        {
            EnterText(employeeNameInput, employeeName);
            return this;
        }

        public PIMPage ClearEmployeeNameField()
        {
            ClearField(employeeNameInput);
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

        public string GetNoRecordsError()
        {
            return GetText(noRecordsLabel);
        }
        public PIMPage ClickAddButton()
        {
            ClickElement(addButton);
            return this;
        }

        public string GetPersonalDetails()
        {
            return GetText(personalDetails);
        }

        public PIMPage EnterFirstName(string firstName)
        {
            EnterText(firstNameInput, firstName);
            return this;
        }

        public PIMPage EnterMiddleName(string middleName)
        {
            EnterText(middleNameInput, middleName);
            return this;
        }

        public PIMPage EnterLastName(string lastName)
        {
            EnterText(lastNameInput, lastName);
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

        public string GetFirstName()
        {
            return GetText(firstNameInput);
        }

        public string GetMiddleName()
        {
            return GetText(middleNameInput);
        }

        public string GetLastName()
        {
            return GetText(lastNameInput);
        }
        
        public string GetEmployeeName(string user)
        {
            string element = "//div//div[contains(text(), '{0}')]";
            element = String.Format(element, user);
            ILocator elementLocation = page.Locator(element);
            return GetText(elementLocation);
        }

        public string GetCustomError(int errorNo)
        {
            string element = "(//div//span[contains(@class, 'input-field-error')])[{0}]";
            element = String.Format(element, errorNo);
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
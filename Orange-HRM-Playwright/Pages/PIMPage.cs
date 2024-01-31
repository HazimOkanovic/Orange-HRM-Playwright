using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class PIMPage
    {
        private readonly IPage page;
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
        
        public PIMPage(IPage page)
        {
            this.page = page;
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
        
        public async Task<string> GetPimTitle()
        {
            return await pageTitle.InnerTextAsync();
        }

        public async Task EnterEmployeeName(string employeeName)
        {
            await employeeNameInput.FillAsync(employeeName);
        }

        public async Task ClearEmployeeNameField()
        {
            await employeeNameInput.ClearAsync();
        }

        public async Task EnterEmployeeId(string id)
        {
            await employeeIdInput.FillAsync(id);
        }

        public async Task ClickSearch()
        {
            await searchButton.ClickAsync();
        }

        public async Task<string> GetNoRecordsError()
        {
            return await noRecordsLabel.InnerTextAsync();
        }
        public async Task ClickAddButton()
        {
            await addButton.ClickAsync();
        }

        public async Task<string> GetPersonalDetails()
        {
            return await personalDetails.InnerTextAsync();
        }

        public async Task EnterFirstName(string firstName)
        {
            await firstNameInput.FillAsync(firstName);
        }

        public async Task EnterMiddleName(string middleName)
        {
            await middleNameInput.FillAsync(middleName);
        }

        public async Task EnterLastName(string lastName)
        {
            await lastNameInput.FillAsync(lastName);
        }

        public async Task<string> GetEmployeeId()
        {
            NewEmployeeId = await employeeId.InnerTextAsync();
            return NewEmployeeId;
        }

        public async Task ClickSave()
        {
            await searchButton.ClickAsync();
        }

        public async Task<string> GetEmployeeTitle()
        {
            return await addEmployeeTitle.InnerTextAsync();
        }

        public async Task<string> GetFirstName()
        {
            return await firstNameInput.InnerTextAsync();
        }

        public async Task<string> GetMiddleName()
        {
            return await middleNameInput.InnerTextAsync();
        }

        public async Task<string> GetLastName()
        {
            return await lastNameInput.InnerTextAsync();
        }
        
        public async Task<string> GetEmployeeName(string user)
        {
            string element = "//div//div[contains(text(), '{0}')]";
            element = String.Format(element, user);
            ILocator elementLocation = page.Locator(element);
            return await elementLocation.InnerTextAsync();
        }

        public async Task<string> GetCustomError(int errorNo)
        {
            string element = "(//div//span[contains(@class, 'input-field-error')])[{0}]";
            element = String.Format(element, errorNo);
            ILocator elementLocation = page.Locator(element);
            return await elementLocation.InnerTextAsync();
        }
        
        public async Task ClickOnEmployeeName(string user)
        {
            string element = "//div//div[contains(text(), '{0}')]";
            element = String.Format(element, user);
            ILocator elementLocation = page.Locator(element);
            await elementLocation.ClickAsync();
        }
    }
}
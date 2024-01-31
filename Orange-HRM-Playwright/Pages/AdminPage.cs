using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class AdminPage : BasePage
    {
        readonly ILocator pageTitle;
        readonly ILocator addButton;
        readonly ILocator addUserTitle;
        readonly ILocator userRoleDropdown;
        readonly ILocator statusDropdown;
        readonly ILocator userNameInput;
        readonly ILocator passwordInput;
        readonly ILocator passwordConfirmInput;
        readonly ILocator userRoleError;
        readonly ILocator employeeNameError;
        readonly ILocator statusError;
        readonly ILocator userNameError;
        readonly ILocator passwordError;
        readonly ILocator confirmPasswordError;
        readonly ILocator saveButton;
        readonly ILocator userNameSearchField;
        readonly ILocator employeeName;
        readonly ILocator employeeNameSuggestion;
        readonly ILocator employeeNameInputField;
        readonly ILocator employeeNameForClear;
        
        public AdminPage(IPage page) : base(page)
        {
            pageTitle = page.Locator("(//span//h6)[1]");
            addButton = page.Locator("(//div//button[contains(@class, 'oxd-button--secondary')])[2]");
            addUserTitle = page.Locator("(//div//h6)[2]");
            userRoleDropdown = page.Locator("(//div//div[@class = 'oxd-select-text-input'])[1]");
            statusDropdown = page.Locator("(//div//div[@class = 'oxd-select-text-input'])[2]");
            userNameInput = page.Locator("(//div//input[contains(@class, 'oxd-input')])[2]");
            passwordInput = page.Locator("(//div//input[contains(@class, 'oxd-input')])[3]");
            passwordConfirmInput = page.Locator("(//div//input[contains(@class, 'oxd-input')])[4]");
            userRoleError = page.Locator("(//div//span[contains(@class, 'input-field-error')])[1]");
            employeeNameError = page.Locator("(//div//span[contains(@class, 'input-field-error')])[2]");
            statusError = page.Locator("(//div//span[contains(@class, 'input-field-error')])[3]");
            userNameError = page.Locator("(//div//span[contains(@class, 'input-field-error')])[4]");
            passwordError = page.Locator("(//div//span[contains(@class, 'input-field-error')])[5]");
            confirmPasswordError = page.Locator("(//div//span[contains(@class, 'input-field-error')])[6]");
            saveButton = page.Locator("//div//button[@type = 'submit']");
            userNameSearchField = page.Locator("(//div//input[@class = 'oxd-input oxd-input--active'])[2]");
            employeeName = page.Locator("'Employee Name'");
            employeeNameSuggestion = page.Locator("'Fiona Grace'");
            employeeNameInputField = page.GetByPlaceholder("Type for hints...");
            employeeNameForClear = page.GetByPlaceholder("Type fod hints...");
        }
        
        public async Task<string> GetAdminTitle()
        {
            return await pageTitle.InnerTextAsync();
        }
        
        public async Task<string> GetAddUserTitle()
        {
            return await addUserTitle.InnerTextAsync();
        }
        
        public async Task ClickAddUser()
        {
            await addButton.ClickAsync();
        }

        public async Task  SelectUserRole()
        {
            await userRoleDropdown.SelectOptionAsync("'ESS'");
        }

        public async Task SelectUserStatus()
        {
            await statusDropdown.SelectOptionAsync("'Enabled'");
        }

        public async Task ClickOnEmployeeName()
        {
            await employeeName.ClickAsync();
        }
        
        public async Task ClickOnEmployeeNameSuggestion()
        {
            await employeeNameSuggestion.ClickAsync();
        }

        public async Task EnterEmployeeName(string name)
        {
            await employeeNameInputField.FillAsync(name);
        }

        public async Task ClearEmployeeName()
        {
            await employeeNameForClear.ClearAsync();
        }

        public async Task ClearPasswordField()
        {
            await passwordInput.ClearAsync();
        }

        public async Task ClearUserNameField()
        {
            await userNameInput.ClearAsync();
        }

        public async Task ClearPasswordConfirm()
        {
            await passwordConfirmInput.ClearAsync();
        }

        public async Task EnterUserName(string username)
        {
            await userNameInput.FillAsync(username);
        }

        public async Task EnterPassword(string password)
        {
            await passwordInput.FillAsync(password);
        }

        public async Task EnterConfirmPassword(string confirmPassword)
        {
            await passwordConfirmInput.FillAsync(confirmPassword);
        }
        
        public async Task<string> GetUserRoleError()
        {
            return await userRoleError.InnerTextAsync();
        }

        public async Task<string> GetEmployeeNameError()
        {
            return await employeeNameError.InnerTextAsync();
        }

        public async Task<string> GetStatusError()
        {
            return await statusError.InnerTextAsync();
        }

        public async Task<string> GetUserNameError()
        {
            return await userNameError.InnerTextAsync();
        }

        public async Task<string> GetPasswordError()
        {
            return await passwordError.InnerTextAsync();
        }

        public async Task<string> GetConfirmPasswordError()
        {
            return await confirmPasswordError.InnerTextAsync();
        }
        
        public string GetCustomError(int fieldNumber)
        {
            string element = "(//div//span[contains(@class, 'input-field-error')])[{0}]";
            element = String.Format(element, fieldNumber);
            ILocator elementLocation = page.Locator(element);
            return GetText(elementLocation);
        }

        public async Task ClickSave()
        {
            await this.saveButton.ClickAsync();
        }

        public string GetUserNameAfterSave(string user)
        {
            string element = "//div//div[contains(text(), '{0}')]";
            element = String.Format(element, user);
            ILocator elementLocation = page.Locator(element);
            return GetText(elementLocation);
        }

        public async Task EnterUsernameForSearch(string username)
        {
            await userNameSearchField.FillAsync(username);
        }
    }
}
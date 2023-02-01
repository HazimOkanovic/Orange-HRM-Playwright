using System;
using System.Threading;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class AdminPage : BasePage
    {
        private readonly ILocator pageTitle;
        private readonly ILocator addButton;
        private readonly ILocator addUserTitle;
        private readonly ILocator userRoleDropdown;
        private readonly ILocator statusDropdown;
        private readonly ILocator userNameInput;
        private readonly ILocator passwordInput;
        private readonly ILocator passwordConfirmInput;
        private readonly ILocator userRoleError;
        private readonly ILocator employeeNameError;
        private readonly ILocator statusError;
        private readonly ILocator userNameError;
        private readonly ILocator passwordError;
        private readonly ILocator confirmPasswordError;
        private readonly ILocator saveButton;
        private readonly ILocator userNameSearchField;
        
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
        }

        public string GetAdminTitle()
        {
            return GetText(pageTitle);
        }

        public string GetAddUserTitle()
        {
            return GetText(addUserTitle);
        }

        public AdminPage ClickAddUser()
        {
            ClickElement(addButton);
            return this;
        }

        public AdminPage SelectUserRole()
        {
            ClickElement(userRoleDropdown);
            Thread.Sleep(300);
            page.Locator("'ESS'").ClickAsync();
            return this;
        }

        public AdminPage SelectUserStatus()
        {
            ClickElement(statusDropdown);
            Thread.Sleep(300);
            page.Locator("'Enabled'").ClickAsync();
            return this;
        }

        public AdminPage ClickOnEmployeeName()
        {
            page.Locator("'Employee Name'").ClickAsync();
            return this;
        }
        
        public AdminPage ClickOnEmployeeNameSuggestion()
        {
            Thread.Sleep(500);
            page.Locator("'Odis  Adalwin'").ClickAsync();
            return this;
        }

        public AdminPage EnterEmployeeName(string name)
        {
            page.GetByPlaceholder("Type for hints...").FillAsync(name);
            return this;
        }

        public AdminPage ClearEmployeeName()
        {
            page.GetByPlaceholder("Type fod hints...").ClearAsync();
            return this;
        }

        public AdminPage ClearPasswordField()
        {
            ClearField(passwordInput);
            return this;
        }

        public AdminPage ClearUserNameField()
        {
            ClearField(userNameInput);
            return this;
        }

        public AdminPage ClearPasswordConfirm()
        {
            ClearField(passwordConfirmInput);
            return this;
        }

        public AdminPage EnterUserName(string username)
        {
            EnterText(userNameInput, username);
            return this;
        }

        public AdminPage EnterPassword(string password)
        {
            EnterText(passwordInput, password);
            return this;
        }

        public AdminPage EnterConfirmPassword(string confirmPassword)
        {
            EnterText(passwordConfirmInput, confirmPassword);
            return this;
        }

        public string GetUserRoleError()
        {
            return GetText(userRoleError);
        }

        public string GetEmployeeNameError()
        {
            return GetText(employeeNameError);
        }

        public string GetStatusError()
        {
            return GetText(statusError);
        }

        public string GetUserNameError()
        {
            return GetText(userNameError);
        }

        public string GetPasswordError()
        {
            return GetText(passwordError);
        }

        public string GetConfirmPasswordError()
        {
            return GetText(confirmPasswordError);
        }

        public string GetCustomError(int fieldNumber)
        {
            string element = "(//div//span[contains(@class, 'input-field-error')])[{0}]";
            element = String.Format(element, fieldNumber);
            ILocator elementLocation = page.Locator(element);
            return GetText(elementLocation);
        }

        public AdminPage ClickSave()
        {
            ClickElement(saveButton);
            return this;
        }

        public string GetUserNameAfterSave(string user)
        {
            string element = "//div//div[contains(text(), '{0}')]";
            element = String.Format(element, user);
            ILocator elementLocation = page.Locator(element);
            return GetText(elementLocation);
        }

        public AdminPage EnterUsernameForSearch(string username)
        {
            EnterText(userNameSearchField, username);
            return this;
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class LandingPage
    {
        private readonly IPage page;
        private readonly ILocator userNameInput;
        private readonly ILocator passwordInput;
        private readonly ILocator loginButton;
        private readonly ILocator usernameError;
        private readonly ILocator credentialsError;
        private readonly ILocator pageTitle;
            
        public LandingPage(IPage page)
        {
            this.page = page;
            userNameInput = page.Locator("//div//input[@name = 'username']");
            passwordInput = page.Locator("//div//input[@name = 'password']");
            loginButton = page.Locator("//div//button[@type= 'submit']");
            usernameError = page.Locator("(//div//span)[1]");
            credentialsError = page.Locator("//div//p[contains(@class, 'oxd-alert')]");
            pageTitle = page.Locator("//div//h5[contains(@class, login-title)]");
        }

        public async Task EnterUserName(string userName)
        {
            await page.GetByPlaceholder("Username").FillAsync(userName);
        }

        public async Task EnterPassword(string password)
        {
            await page.GetByPlaceholder("password").FillAsync(password);
        }

        public async Task ClearUsernameField()
        {
            await userNameInput.ClearAsync();
        }

        public async Task ClearPasswordField()
        {
            await passwordInput.ClearAsync();
        }

        public async Task<string> GetUserNameError()
        {
            return await usernameError.InnerTextAsync();
        }

        public async Task<string> GetPasswordError(int locatorPlace)
        {
            string element = "(//div//span)[{0}]";
            element = String.Format(element, locatorPlace);
            ILocator elementLocation = page.Locator(element);
            return await elementLocation.InnerTextAsync();
        }

        public async Task<string> GetTitle()
        {
            return await pageTitle.InnerTextAsync();
        }

        public async Task<string> GetCredentialsError()
        {
            return await credentialsError.InnerTextAsync();
        }
        public async Task ClickLoginButton()
        {
            await loginButton.ClickAsync();
        }
    }
}
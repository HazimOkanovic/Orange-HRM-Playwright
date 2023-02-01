using System;
using System.Threading;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class LandingPage : BasePage
    {
        private readonly ILocator userNameInput;
        private readonly ILocator passwordInput;
        private readonly ILocator loginButton;
        private readonly ILocator usernameError;
        private readonly ILocator credentialsError;
        private readonly ILocator pageTitle;
            
            public LandingPage(IPage page) : base(page)
        {
            userNameInput = page.Locator("//div//input[@name = 'username']");
            passwordInput = page.Locator("//div//input[@name = 'password']");
            loginButton = page.Locator("//div//button[@type= 'submit']");
            usernameError = page.Locator("(//div//span)[1]");
            credentialsError = page.Locator("//div//p[contains(@class, 'oxd-alert')]");
            pageTitle = page.Locator("//div//h5[contains(@class, login-title)]");
        }

        public LandingPage EnterUserName(string userName)
        {
            page.GetByPlaceholder("Username").FillAsync(userName);
            Thread.Sleep(1000);
            return this;
        }

        public LandingPage EnterPassword(string password)
        {
            page.GetByPlaceholder("password").FillAsync(password);
            return this;
        }

        public LandingPage ClearUsernameField()
        {
            ClearField(userNameInput);
            return this;
        }

        public LandingPage ClearPasswordField()
        {
            ClearField(passwordInput);
            return this;
        }

        public string GetUserNameError()
        {
            return GetText(usernameError);
        }

        public string GetPasswordError(int locatorPlace)
        {
            string element = "(//div//span)[{0}]";
            element = String.Format(element, locatorPlace);
            ILocator elementLocation = page.Locator(element);
            return GetText(elementLocation);
        }

        public string GetTitle()
        {
            return GetText(pageTitle);
        }

        public string GetCredentialsError()
        {
            return GetText(credentialsError);
        }
        public DashboardPage ClickLoginButton()
        {
            ClickElement(loginButton);
            return new DashboardPage(page);
        }
    }
}
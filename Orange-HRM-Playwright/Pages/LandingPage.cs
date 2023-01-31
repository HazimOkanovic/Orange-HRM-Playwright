using System.Threading;
using Microsoft.Playwright;

namespace Orange_HRM_Playwright.Pages
{
    public class LandingPage : BasePage
    {
        private readonly ILocator userName;
        private readonly ILocator password;
        private readonly ILocator loginButton;
        
        public LandingPage(IPage page) : base(page)
        {
            userName = page.Locator("//div//input[@name = 'username']");
            password = page.Locator("//div//input[@name = 'password']");
            loginButton = page.Locator("//div//button[@type= 'submit']");
        }

        public LandingPage EnterUserName(string userName)
        {
            EnterText(this.userName, userName);
            Thread.Sleep(500);
            return this;
        }

        public LandingPage EnterPassword(string password)
        {
            EnterText(this.password, password);
            return this;
        }

        public DashboardPage ClickLoginButton()
        {
            ClickElement(loginButton);
            return new DashboardPage(page);
        }
    }
}
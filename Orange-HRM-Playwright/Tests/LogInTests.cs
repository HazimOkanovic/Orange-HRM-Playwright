using System.Threading.Tasks;
using NUnit.Framework;

namespace Orange_HRM_Playwright.Tests
{
    
    public class LogInTests : BaseTest
    {
        [Test, Order(1)]
        public async Task LogInWithoutCredentialsTest()
        {
            await landingPage.ClickLoginButton();
            
            Assert.That(await landingPage.GetUserNameError(), Is.EqualTo(Constants.Required));
            Assert.That(await landingPage.GetPasswordError(2), Is.EqualTo(Constants.Required));
        }

        [Test, Order(2)]
        public async Task LogInWithoutUsernameTest()
        {
            await landingPage.EnterPassword(Constants.ValidPassword);
            await landingPage.ClickLoginButton();
            
            Assert.That(await landingPage.GetUserNameError(), Is.EqualTo(Constants.Required));
        }

        [Test, Order(3)]
        public async Task LogInWithoutPasswordTest()
        {
            await landingPage.ClearPasswordField();
            await landingPage.EnterUserName(Constants.ValidUsername);
            await landingPage.ClickLoginButton();
            
            Assert.That(await landingPage.GetPasswordError(1), Is.EqualTo(Constants.Required));
        }

        [Test, Order(4)]
        public async Task IncorrectUsernameTest()
        {
            await landingPage.ClearUsernameField();
            await landingPage.EnterUserName(Constants.IncorrectUsername);
            await landingPage.EnterPassword(Constants.ValidPassword);
            await landingPage.ClickLoginButton();
            
            Assert.That(await landingPage.GetCredentialsError(), Is.EqualTo(Constants.CredentialsError));
        }

        [Test, Order(5)]
        public async Task IncorrectPasswordTest()
        {
            await landingPage.ClearUsernameField();
            await landingPage.ClearPasswordField();
            await landingPage.EnterUserName(Constants.ValidUsername);
            await landingPage.EnterPassword(Constants.IncorrectPassword);
            await landingPage.ClickLoginButton();
            
            Assert.That(await landingPage.GetCredentialsError(), Is.EqualTo(Constants.CredentialsError));
        }

        [Test, Order(6)]
        public async Task IncorrectUsernameAndPasswordTest()
        {
            await landingPage.ClearUsernameField();
            await landingPage.ClearPasswordField();
            await landingPage.EnterUserName(Constants.IncorrectUsername);
            await landingPage.EnterPassword(Constants.IncorrectPassword);
            await landingPage.ClickLoginButton();
            
            Assert.That(await landingPage.GetCredentialsError(), Is.EqualTo(Constants.CredentialsError));
        }
        
        [Test, Order(7)]
        public async Task SuccessfulLogInTest()
        {
            await landingPage.ClearUsernameField();
            await landingPage.ClearPasswordField();
            await landingPage.EnterUserName(Constants.ValidUsername);
            await landingPage.EnterPassword(Constants.ValidPassword);
            
            Assert.That(await dashboardPage.GetTitle(), Is.EqualTo(Constants.DashboardTitle));
        }

        [Test, Order(8)]
        public async Task SuccessfulLogOutTest()
        {
            await dashboardPage.LogOut();
            
            Assert.That(await landingPage.GetTitle(), Is.EqualTo(Constants.LoginTitle));
        }
    }
}

using System.Threading.Tasks;
using NUnit.Framework;

namespace Orange_HRM_Playwright.Tests
{
    
    public class LogInTests : BaseTest
    {
        [Test, Order(1)]
        public async Task LogInWithoutCredentialsTest()
        {
            await landing.ClickLoginButton();
            
            Assert.That(await landing.GetUserNameError(), Is.EqualTo(Constants.Required));
            Assert.That(await landing.GetPasswordError(2), Is.EqualTo(Constants.Required));
        }

        [Test, Order(2)]
        public async Task LogInWithoutUsernameTest()
        {
            await landing.EnterPassword(Constants.ValidPassword);
            await landing.ClickLoginButton();
            
            Assert.That(await landing.GetUserNameError(), Is.EqualTo(Constants.Required));
        }

        [Test, Order(3)]
        public async Task LogInWithoutPasswordTest()
        {
            await landing.ClearPasswordField();
            await landing.EnterUserName(Constants.ValidUsername);
            await landing.ClickLoginButton();
            
            Assert.That(await landing.GetPasswordError(1), Is.EqualTo(Constants.Required));
        }

        [Test, Order(4)]
        public async Task IncorrectUsernameTest()
        {
            await landing.ClearUsernameField();
            await landing.EnterUserName(Constants.IncorrectUsername);
            await landing.EnterPassword(Constants.ValidPassword);
            await landing.ClickLoginButton();
            
            Assert.That(await landing.GetCredentialsError(), Is.EqualTo(Constants.CredentialsError));
        }

        [Test, Order(5)]
        public async Task IncorrectPasswordTest()
        {
            await landing.ClearUsernameField();
            await landing.ClearPasswordField();
            await landing.EnterUserName(Constants.ValidUsername);
            await landing.EnterPassword(Constants.IncorrectPassword);
            await landing.ClickLoginButton();
            
            Assert.That(await landing.GetCredentialsError(), Is.EqualTo(Constants.CredentialsError));
        }

        [Test, Order(6)]
        public async Task IncorrectUsernameAndPasswordTest()
        {
            await landing.ClearUsernameField();
            await landing.ClearPasswordField();
            await landing.EnterUserName(Constants.IncorrectUsername);
            await landing.EnterPassword(Constants.IncorrectPassword);
            await landing.ClickLoginButton();
            
            Assert.That(await landing.GetCredentialsError(), Is.EqualTo(Constants.CredentialsError));
        }
        
        [Test, Order(7)]
        public async Task SuccessfulLogInTest()
        {
            await landing.ClearUsernameField();
            await landing.ClearPasswordField();
            await landing.EnterUserName(Constants.ValidUsername);
            await landing.EnterPassword(Constants.ValidPassword);
            
            Assert.That(await dashboardPage.GetTitle(), Is.EqualTo(Constants.DashboardTitle));
        }

        [Test, Order(8)]
        public async Task SuccessfulLogOutTest()
        {
            await dashboardPage.LogOut();
            
            Assert.That(await landing.GetTitle(), Is.EqualTo(Constants.LoginTitle));
        }
    }
}

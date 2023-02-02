using NUnit.Framework;
using Orange_HRM_Playwright.Pages;

namespace Orange_HRM_Playwright.Tests
{
    public class LogInTests : BaseTest
    {
        private DashboardPage dashboardPage;

        [Test, Order(1)]
        public void LogInWithoutCredentialsTest()
        {
            landing
                .ClickLoginButton();
            
            Assert.That(landing.GetUserNameError(), Is.EqualTo(Constants.Required));
            Assert.That(landing.GetPasswordError(2), Is.EqualTo(Constants.Required));
        }

        [Test, Order(2)]
        public void LogInWithoutUsernameTest()
        {
            landing
                .EnterPassword(Constants.ValidPassword)
                .ClickLoginButton();
            
            Assert.That(landing.GetUserNameError(), Is.EqualTo(Constants.Required));
        }

        [Test, Order(3)]
        public void LogInWithoutPasswordTest()
        {
            landing
                .ClearPasswordField()
                .EnterUserName(Constants.ValidUsername)
                .ClickLoginButton();
            
            Assert.That(landing.GetPasswordError(1), Is.EqualTo(Constants.Required));
        }

        [Test, Order(4)]
        public void IncorrectUsernameTest()
        {
            landing
                .ClearUsernameField()
                .EnterUserName(Constants.IncorrectUsername)
                .EnterPassword(Constants.ValidPassword)
                .ClickLoginButton();
            
            Assert.That(landing.GetCredentialsError(), Is.EqualTo(Constants.CredentialsError));
        }

        [Test, Order(5)]
        public void IncorrectPasswordTest()
        {
            landing
                .ClearUsernameField()
                .ClearPasswordField()
                .EnterUserName(Constants.ValidUsername)
                .EnterPassword(Constants.IncorrectPassword)
                .ClickLoginButton();
            
            Assert.That(landing.GetCredentialsError(), Is.EqualTo(Constants.CredentialsError));
        }

        [Test, Order(6)]
        public void IncorrectUsernameAndPasswordTest()
        {
            landing
                .ClearUsernameField()
                .ClearPasswordField()
                .EnterUserName(Constants.IncorrectUsername)
                .EnterPassword(Constants.IncorrectPassword)
                .ClickLoginButton();
            
            Assert.That(landing.GetCredentialsError(), Is.EqualTo(Constants.CredentialsError));
        }
        
        [Test, Order(7)]
        public void SuccessfulLogInTest()
        {
            landing
                .ClearUsernameField()
                .ClearPasswordField()
                .EnterUserName(Constants.ValidUsername)
                .EnterPassword(Constants.ValidPassword);
                
            dashboardPage = landing.ClickLoginButton();
            
            Assert.That(dashboardPage.GetTitle(), Is.EqualTo(Constants.DashboardTitle));
        }

        [Test, Order(8)]
        public void SuccessfulLogOutTest()
        {
            dashboardPage
                .LogOut();
            
            Assert.That(landing.GetTitle(), Is.EqualTo(Constants.LoginTitle));
        }
    }
}
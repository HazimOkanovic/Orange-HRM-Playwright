using System.Threading;
using Microsoft.Playwright;
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
            
            Assert.That(landing.GetUserNameError(), Is.EqualTo("Required"));
            Assert.That(landing.GetPasswordError(2), Is.EqualTo("Required"));
        }

        [Test, Order(2)]
        public void LogInWithoutUsernameTest()
        {
            landing
                .EnterPassword("admin123")
                .ClickLoginButton();
            
            Assert.That(landing.GetUserNameError(), Is.EqualTo("Required"));
        }

        [Test, Order(3)]
        public void LogInWithoutPasswordTest()
        {
            landing
                .ClearPasswordField()
                .EnterUserName("Admin")
                .ClickLoginButton();
            
            Assert.That(landing.GetPasswordError(1), Is.EqualTo("Required"));
        }

        [Test, Order(4)]
        public void IncorrectUsernameTest()
        {
            landing
                .ClearUsernameField()
                .EnterUserName("Hazim")
                .EnterPassword("admin123")
                .ClickLoginButton();
            
            Assert.That(landing.GetCredentialsError(), Is.EqualTo("Invalid credentials"));
        }

        [Test, Order(5)]
        public void IncorrectPasswordTest()
        {
            landing
                .ClearUsernameField()
                .ClearPasswordField()
                .EnterUserName("Admin")
                .EnterPassword("adminadmin")
                .ClickLoginButton();
            
            Assert.That(landing.GetCredentialsError(), Is.EqualTo("Invalid credentials"));
        }

        [Test, Order(6)]
        public void IncorrectUsernameAndPasswordTest()
        {
            landing
                .ClearUsernameField()
                .ClearPasswordField()
                .EnterUserName("Hazim")
                .EnterPassword("adminadmin")
                .ClickLoginButton();
            
            Assert.That(landing.GetCredentialsError(), Is.EqualTo("Invalid credentials"));
        }
        
        [Test, Order(7)]
        public void SuccessfulLogInTest()
        {
            landing
                .ClearUsernameField()
                .ClearPasswordField()
                .EnterUserName("Admin")
                .EnterPassword("admin123");
                
            dashboardPage = landing.ClickLoginButton();
            
            Assert.That(dashboardPage.GetTitle(), Is.EqualTo("Dashboard"));
        }

        [Test, Order(8)]
        public void SuccessfulLogOutTest()
        {
            dashboardPage
                .LogOut();
            
            Assert.That(landing.GetTitle(), Is.EqualTo("Login"));
        }
    }
}
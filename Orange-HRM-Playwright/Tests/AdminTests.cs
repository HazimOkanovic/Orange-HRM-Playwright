using System.Threading;
using NUnit.Framework;
using Orange_HRM_Playwright.Pages;

namespace Orange_HRM_Playwright.Tests
{
    public class AdminTests : BaseTest
    {
        private DashboardPage dashboardPage;
        private AdminPage adminPage;

        [Test, Order(1)]
        public void LogInTest()
        {
            landing
                .ClearUsernameField()
                .ClearPasswordField()
                .EnterUserName(Constants.ValidUsername)
                .EnterPassword(Constants.ValidPassword);
                
            dashboardPage = landing.ClickLoginButton();
            
            Assert.That(dashboardPage.GetTitle(), Is.EqualTo(Constants.DashboardTitle));
        }

        [Test, Order(2)]
        public void GoToAdminPageTest()
        {
            adminPage = dashboardPage.ClickAdminButton();
            Thread.Sleep(1500);
            Assert.That(adminPage.GetAdminTitle(), Is.EqualTo("Admin"));
        }

        [Test, Order(3)]
        public void ClickAddUser()
        {
            adminPage
                .ClickAddUser();
            Thread.Sleep(1500);
            Assert.That(adminPage.GetAddUserTitle(), Is.EqualTo("Add User"));
        }

        [Test, Order(4)]
        public void AddUserTest()
        {
            adminPage
                .SelectUserRole();
            
            Thread.Sleep(15000);
        }
    }
}
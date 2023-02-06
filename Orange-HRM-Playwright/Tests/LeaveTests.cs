using System.Threading;
using NUnit.Framework;
using Orange_HRM_Playwright.Pages;

namespace Orange_HRM_Playwright.Tests
{
    public class LeaveTests : BaseTest
    {
        private DashboardPage dashboardPage;
        private AdminPage adminPage;
        private LeavePage leavePage;
        
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
            
            Assert.That(adminPage.GetAdminTitle(), Is.EqualTo(Constants.AdminPageTitle));
        }

        [Test, Order(3)]
        public void ClickAddUser()
        {
            adminPage
                .ClickAddUser();
            
            Thread.Sleep(1500);
            
            Assert.That(adminPage.GetAddUserTitle(), Is.EqualTo(Constants.NewUserTitle));
        }

        [Test, Order(4)]
        public void CreateNewUserTest()
        {
            adminPage
                .SelectUserRole();
                Thread.Sleep(500);
                adminPage.EnterEmployeeName(Constants.ValidEmployeeName);
                    Thread.Sleep(500);
                adminPage.ClickOnEmployeeNameSuggestion()
                .SelectUserStatus()
                .EnterUserName(Constants.NewUserName);
                Thread.Sleep(750);
                adminPage.EnterPassword(Constants.NewRecordValidPassword);
                    Thread.Sleep(1000);
                    adminPage.EnterConfirmPassword(Constants.NewRecordValidPassword);
                    Thread.Sleep(500);
                adminPage.ClickSave();
            
            Assert.That(adminPage.GetUserNameAfterSave(Constants.NewUserName), Is.EqualTo(Constants.NewUserName));
        }

        [Test, Order(5)]
        public void GoToLeavePage()
        {
            leavePage = dashboardPage
                .ClickLeaveButton();
            Thread.Sleep(1000);
            Assert.That(leavePage.GetLeaveTitle(), Is.EqualTo("Leave"));
        }

        [Test, Order(6)]
        public void ClickAssignLeaveButton()
        {
            leavePage
                .ClickAssignLeave();
            
            Thread.Sleep(1500);
            
            Assert.That(leavePage.GetAssignLeaveTitle(), Is.EqualTo("Assign Leave"));
        }
    }
}
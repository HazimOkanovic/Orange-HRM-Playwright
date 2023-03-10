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
        public void AddUserAllFieldsEmptyTest()
        {
            adminPage
                .ClickSave();
            
            Assert.That(adminPage.GetUserRoleError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetEmployeeNameError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetStatusError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetUserNameError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetPasswordError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetConfirmPasswordError(), Is.EqualTo(Constants.Required));
        }

        [Test, Order(5)]
        public void AddUserOneFieldPopulated()
        {
            adminPage
                .SelectUserRole();
            
            Thread.Sleep(1000);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(4), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(5), Is.EqualTo(Constants.Required));
        }

        [Test, Order(6)]
        public void AddUserInvalidEmployeeName()
        {
            adminPage
                .EnterEmployeeName(Constants.InvalidEmployeeName)
                .ClickOnEmployeeName();
            
            Thread.Sleep(1000);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Invalid));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(4), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(5), Is.EqualTo(Constants.Required)); 
        }

        [Test, Order(7)]
        public void AddUserTwoFieldsPopulated()
        {
            adminPage
                .ClearEmployeeName()
                .EnterEmployeeName(Constants.ValidEmployeeName)
                .ClickOnEmployeeNameSuggestion();
            
            Thread.Sleep(1000);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(4), Is.EqualTo(Constants.Required)); 
        }

        [Test, Order(8)]
        public void AddUserThreeFieldsPopulated()
        {
            adminPage
                .SelectUserStatus();
            
            Thread.Sleep(1000);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
        }

        [Test, Order(9)]
        public void AddUserInvalidUserNameTest()
        {
            adminPage
                .EnterUserName(Constants.ShortUsername)
                .ClickSave();

            Thread.Sleep(1000);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.ShortUserNameError));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
        }

        [Test, Order(10)]
        public void AddUserFourFieldsPopulatedTest()
        {
            adminPage
                .ClearUserNameField();
            
            Thread.Sleep(1000);
                
            adminPage
                .EnterUserName(Constants.NewUserName);
            
            Thread.Sleep(1000);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
        }
     
        [Test, Order(11)]
        public void AddUserInvalidPassword()
        {
            adminPage
                .EnterPassword(Constants.NewRecordInvalidPassword);
            
            Thread.Sleep(1000);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.PasswordError));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
        }

        [Test, Order(12)]
        public void PasswordsDoNotMatchTest()
        {
            adminPage
                .ClearPasswordField();
            
            Thread.Sleep(1000);
            
            adminPage
                .EnterPassword(Constants.NewRecordValidPassword);
            
            Thread.Sleep(500);
            
            adminPage
                .EnterConfirmPassword(Constants.NewRecordInvalidPassword);
            
            Thread.Sleep(1000);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.PasswordsDontMatchError));
        }

        [Test, Order(13)]
        public void CheckForCreatedRecord()
        {
            adminPage
                .ClearPasswordConfirm();
            Thread.Sleep(400);
            adminPage
                .EnterConfirmPassword(Constants.NewRecordValidPassword)
                .ClickSave();
            
            Assert.That(adminPage.GetUserNameAfterSave(Constants.NewUserName), Is.EqualTo(Constants.NewUserName));
        }

        [Test, Order(14)]
        public void CheckForCreatedRecordWithSearch()
        {
            adminPage
                .EnterUsernameForSearch(Constants.NewUserName);
            Thread.Sleep(500);
            adminPage
                .ClickSave();
            
            Assert.That(adminPage.GetUserNameAfterSave(Constants.NewUserName), Is.EqualTo(Constants.NewUserName));
        }
    }
}
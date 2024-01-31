using System.Threading.Tasks;
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
        public async Task GoToAdminPageTest()
        {
            await dashboardPage.ClickAdminButton();
            
            Assert.That(adminPage.GetAdminTitle(), Is.EqualTo(Constants.AdminPageTitle));
        }

        [Test, Order(3)]
        public async Task ClickAddUser()
        {
            await adminPage.ClickAddUser();
            
            Assert.That(adminPage.GetAddUserTitle(), Is.EqualTo(Constants.NewUserTitle));
        }

        [Test, Order(4)]
        public async Task AddUserAllFieldsEmptyTest()
        {
            await adminPage.ClickSave();
            
            Assert.That(adminPage.GetUserRoleError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetEmployeeNameError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetStatusError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetUserNameError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetPasswordError(), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetConfirmPasswordError(), Is.EqualTo(Constants.Required));
        }

        [Test, Order(5)]
        public async Task AddUserOneFieldPopulated()
        {
            await adminPage.SelectUserRole();
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(4), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(5), Is.EqualTo(Constants.Required));
        }

        [Test, Order(6)]
        public async Task AddUserInvalidEmployeeName()
        {
            await adminPage.EnterEmployeeName(Constants.InvalidEmployeeName);
            await adminPage.ClickOnEmployeeName();
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Invalid));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(4), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(5), Is.EqualTo(Constants.Required)); 
        }

        [Test, Order(7)]
        public async Task AddUserTwoFieldsPopulated()
        {
            await adminPage.ClearEmployeeName();
            await adminPage.EnterEmployeeName(Constants.ValidEmployeeName);
            await adminPage.ClickOnEmployeeNameSuggestion();
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(4), Is.EqualTo(Constants.Required)); 
        }

        [Test, Order(8)]
        public async Task AddUserThreeFieldsPopulated()
        {
            await adminPage.SelectUserStatus();
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
        }

        [Test, Order(9)]
        public async Task AddUserInvalidUserNameTest()
        {
            await adminPage.EnterUserName(Constants.ShortUsername);
            await adminPage.ClickSave();
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.ShortUserNameError));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
        }

        [Test, Order(10)]
        public async Task AddUserFourFieldsPopulatedTest()
        {
            await adminPage.ClearUserNameField();
            await adminPage.EnterUserName(Constants.NewUserName);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
        }
     
        [Test, Order(11)]
        public async Task AddUserInvalidPassword()
        {
            await adminPage.EnterPassword(Constants.NewRecordInvalidPassword);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.PasswordError));
            Assert.That(adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
        }

        [Test, Order(12)]
        public async Task PasswordsDoNotMatchTest()
        {
            await adminPage.ClearPasswordField();
            await adminPage.EnterPassword(Constants.NewRecordValidPassword);
            await adminPage.EnterConfirmPassword(Constants.NewRecordInvalidPassword);
            
            Assert.That(adminPage.GetCustomError(1), Is.EqualTo(Constants.PasswordsDontMatchError));
        }

        [Test, Order(13)]
        public async Task CheckForCreatedRecord()
        {
            await adminPage.ClearPasswordConfirm();
            await adminPage.EnterConfirmPassword(Constants.NewRecordValidPassword);
            await adminPage.ClickSave();
            
            Assert.That(adminPage.GetUserNameAfterSave(Constants.NewUserName), Is.EqualTo(Constants.NewUserName));
        }

        [Test, Order(14)]
        public async Task CheckForCreatedRecordWithSearch()
        {
            await adminPage.EnterUsernameForSearch(Constants.NewUserName);
            await adminPage.ClickSave();
            
            Assert.That(adminPage.GetUserNameAfterSave(Constants.NewUserName), Is.EqualTo(Constants.NewUserName));
        }
    }
}
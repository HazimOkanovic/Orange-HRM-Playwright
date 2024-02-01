using System.Threading.Tasks;
using NUnit.Framework;
namespace Orange_HRM_Playwright.Tests
{
    public class AdminTests : BaseTest
    {
        [Test, Order(1)]
        public async Task LogInTest()
        {
            await landingPage.EnterUserName(Constants.ValidUsername);
            await landingPage.EnterPassword(Constants.ValidPassword);
            await landingPage.ClickLoginButton();
            
            Assert.That(await dashboardPage.GetTitle(), Is.EqualTo(Constants.DashboardTitle));
        }

        [Test, Order(2)]
        public async Task GoToAdminPageTest()
        {
            await dashboardPage.ClickAdminButton();
            
            Assert.That(await adminPage.GetAdminTitle(), Is.EqualTo(Constants.AdminPageTitle));
        }

        [Test, Order(3)]
        public async Task ClickAddUser()
        {
            await adminPage.ClickAddUser();
            
            Assert.That(await adminPage.GetAddUserTitle(), Is.EqualTo(Constants.NewUserTitle));
        }

        [Test, Order(4)]
        public async Task AddUserAllFieldsEmptyTest()
        {
            await adminPage.ClickSave();
            
            Assert.That(await adminPage.GetUserRoleError(), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetEmployeeNameError(), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetStatusError(), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetUserNameError(), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetPasswordError(), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetConfirmPasswordError(), Is.EqualTo(Constants.Required));
        }

        [Test, Order(5)]
        public async Task AddUserOneFieldPopulated()
        {
            await adminPage.SelectUserRole();
            
            Assert.That(await adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(4), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(5), Is.EqualTo(Constants.Required));
        }

        [Test, Order(6)]
        public async Task AddUserInvalidEmployeeName()
        {
            await adminPage.EnterEmployeeName(Constants.InvalidEmployeeName);
            await adminPage.ClickOnEmployeeName();
            
            Assert.That(await adminPage.GetCustomError(1), Is.EqualTo(Constants.Invalid));
            Assert.That(await adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(4), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(5), Is.EqualTo(Constants.Required)); 
        }

        [Test, Order(7)]
        public async Task AddUserTwoFieldsPopulated()
        {
            await adminPage.ClearEmployeeName();
            await adminPage.EnterEmployeeName(Constants.ValidEmployeeName);
            await adminPage.ClickOnEmployeeNameSuggestion();
            
            Assert.That(await adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(4), Is.EqualTo(Constants.Required)); 
        }

        [Test, Order(8)]
        public async Task AddUserThreeFieldsPopulated()
        {
            await adminPage.SelectUserStatus();
            
            Assert.That(await adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
        }

        [Test, Order(9)]
        public async Task AddUserInvalidUserNameTest()
        {
            await adminPage.EnterUserName(Constants.ShortUsername);
            await adminPage.ClickSave();
            
            Assert.That(await adminPage.GetCustomError(1), Is.EqualTo(Constants.ShortUserNameError));
            Assert.That(await adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(3), Is.EqualTo(Constants.Required));
        }

        [Test, Order(10)]
        public async Task AddUserFourFieldsPopulatedTest()
        {
            await adminPage.ClearUserNameField();
            await adminPage.EnterUserName(Constants.NewUserName);
            
            Assert.That(await adminPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(await adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
        }
     
        [Test, Order(11)]
        public async Task AddUserInvalidPassword()
        {
            await adminPage.EnterPassword(Constants.NewRecordInvalidPassword);
            
            Assert.That(await adminPage.GetCustomError(1), Is.EqualTo(Constants.PasswordError));
            Assert.That(await adminPage.GetCustomError(2), Is.EqualTo(Constants.Required));
        }

        [Test, Order(12)]
        public async Task PasswordsDoNotMatchTest()
        {
            await adminPage.ClearPasswordField();
            await adminPage.EnterPassword(Constants.NewRecordValidPassword);
            await adminPage.EnterConfirmPassword(Constants.NewRecordInvalidPassword);
            
            Assert.That(await adminPage.GetCustomError(1), Is.EqualTo(Constants.PasswordsDontMatchError));
        }

        [Test, Order(13)]
        public async Task CheckForCreatedRecord()
        {
            await adminPage.ClearPasswordConfirm();
            await adminPage.EnterConfirmPassword(Constants.NewRecordValidPassword);
            await adminPage.ClickSave();
            
            Assert.That(await adminPage.GetUserNameAfterSave(Constants.NewUserName), Is.EqualTo(Constants.NewUserName));
        }

        [Test, Order(14)]
        public async Task CheckForCreatedRecordWithSearch()
        {
            await adminPage.EnterUsernameForSearch(Constants.NewUserName);
            await adminPage.ClickSave();
            
            Assert.That(await adminPage.GetUserNameAfterSave(Constants.NewUserName), Is.EqualTo(Constants.NewUserName));
        }
    }
}
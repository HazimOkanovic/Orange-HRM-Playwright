using System.Threading.Tasks;
using NUnit.Framework;

namespace Orange_HRM_Playwright.Tests
{
    public class LeaveTests : BaseTest
    {
        [Test, Order(1)]
        public async Task LogInTest()
        {
            await landingPage.ClearUsernameField();
            await landingPage.ClearPasswordField();
            await landingPage.EnterUserName(Constants.ValidUsername);
            await landingPage.EnterPassword(Constants.ValidPassword);
            
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
        public async Task CreateNewUserTest()
        {
            await adminPage.SelectUserRole();
            await adminPage.EnterEmployeeName(Constants.ValidEmployeeName);
            await adminPage.ClickOnEmployeeNameSuggestion();
            await adminPage.SelectUserStatus();
            await adminPage.EnterUserName(Constants.NewUserName);
            await adminPage.EnterPassword(Constants.NewRecordValidPassword);
            await adminPage.EnterConfirmPassword(Constants.NewRecordValidPassword);
            await adminPage.ClickSave();
            
            Assert.That(await adminPage.GetUserNameAfterSave(Constants.NewUserName), Is.EqualTo(Constants.NewUserName));
        }

        [Test, Order(5)]
        public async Task GoToLeavePage()
        {
            await dashboardPage.ClickLeaveButton();
            
            Assert.That(await leavePage.GetLeaveTitle(), Is.EqualTo(Constants.LeavePageTitle));
        }

        [Test, Order(6)]
        public async Task ClickAssignLeaveButton()
        {
            await leavePage.ClickAssignLeave();
            
            Assert.That(await leavePage.GetAssignLeaveTitle(), Is.EqualTo(Constants.AssignLeaveTitle));
        }

        [Test, Order(7)]
        public async Task AllFieldsEmptyTest()
        {
            await leavePage.ClickApplyButton();
            
            Assert.That(await leavePage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(await leavePage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(await leavePage.GetCustomError(3), Is.EqualTo(Constants.Required));
            Assert.That(await leavePage.GetCustomError(4), Is.EqualTo(Constants.Required));
        }

        [Test, Order(8)]
        public async Task EnterOneFieldTest()
        {
            await leavePage.EnterEmployeeName(Constants.ValidEmployeeName);
            await leavePage.ClickOnEmployeeNameSuggestion();
            
            Assert.That(await leavePage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(await leavePage.GetCustomError(2), Is.EqualTo(Constants.Required));
            Assert.That(await leavePage.GetCustomError(3), Is.EqualTo(Constants.Required));
        }

        [Test, Order(9)]
        public async Task PopulateTwoFieldsTest()
        {
            await leavePage.ClickOnLeaveType();
            await leavePage.ChooseLeaveType();
            
            Assert.That(await leavePage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(await leavePage.GetCustomError(2), Is.EqualTo(Constants.Required));
        }

        [Test, Order(10)]
        public async Task SuccessfulAssignLeaveTest()
        {
            await leavePage.ClickOnFromDate();
            await leavePage.ChooseFromDate();
            await leavePage.ClickAssignLeave();
            
            Assert.That(await leavePage.GetCardTitle(), Is.EqualTo(Constants.ConfirmLeave));
        }

        [Test, Order(11)]
        public async Task GoToMyLeaveAndCheckIfRecordSavedTest()
        {
            await leavePage.ClickOkButton();
            await leavePage.ClickMyLeave();
            
            Assert.That(await leavePage.GetAssignLeaveTitle(), Is.EqualTo(Constants.LeaveList));
            Assert.That(await leavePage.GetUserNameAfterSave(Constants.ValidEmployeeName), Is.EqualTo(Constants.ValidEmployeeName));
        }
    }
}
using System.Threading.Tasks;
using NUnit.Framework;
using Orange_HRM_Playwright.Pages;

namespace Orange_HRM_Playwright.Tests
{
    public class PimTests : BaseTest
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
        public async Task GoToPimPageTest()
        {
            await dashboardPage.ClickPimButton();
            
            Assert.That(await pimPage.GetPimTitle(), Is.EqualTo(Constants.PimPageTitle));
        }

        [Test, Order(3)]
        public async Task ClickAddNewEmployeeTest()
        {
            await pimPage.ClickAddButton();
            
            Assert.That(await pimPage.GetEmployeeTitle(), Is.EqualTo(Constants.AddEmployeeTitle));
        }

        [Test, Order(4)]
        public async Task ClickSaveWithoutPopulatingFields()
        {
            await pimPage.ClickSave();
            
            Assert.That(await pimPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(await pimPage.GetCustomError(2), Is.EqualTo(Constants.Required));
        }

        [Test, Order(5)]
        public async Task ClickSaveOneFieldPopulated()
        {
            await pimPage.EnterFirstName(Constants.NewUserName);
            await pimPage.ClickSave();

            Assert.That(await pimPage.GetCustomError(1), Is.EqualTo(Constants.Required));
        }

        [Test, Order(6)]
        public async Task AddNewEmployeeTest()
        {
            await pimPage.EnterMiddleName(Constants.IncorrectUsername);
            await pimPage.EnterLastName(Constants.LastName);
            await pimPage.ClickSave();
            await pimPage.GetEmployeeId();
            
            Assert.That(await pimPage.GetPersonalDetails(), Is.EqualTo(Constants.PersonalDetails));
        }

        [Test, Order(7)]
        public async Task EmptySearchTest()
        {
            await dashboardPage.ClickPimButton();
            await pimPage.EnterEmployeeName(Constants.FakeEmployeeName);
            await pimPage.ClickSearch();
            
            Assert.That(await pimPage.GetNoRecordsError(), Is.EqualTo(Constants.NoRecords));
        }
        [Test, Order(8)]
        public async Task SearchWithEmployeeName()
        {
            await pimPage.ClearEmployeeNameField();
            await pimPage.EnterEmployeeName(Constants.NewUserName);
            await pimPage.ClickSearch();
            
            Assert.That(await pimPage.GetEmployeeName(Constants.NewUserName), Is.EqualTo(Constants.NewUserName + " " + Constants.IncorrectUsername));
        } 
        
        [Test, Order(9)]
        public async Task GoToEmployeeDetails()
        {
            await pimPage.ClickOnEmployeeName(Constants.NewUserName);
            
            Assert.That(await pimPage.GetPersonalDetails(), Is.EqualTo(Constants.PersonalDetails));
        }
    }
}

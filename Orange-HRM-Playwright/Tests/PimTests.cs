
using System.Threading;
using NUnit.Framework;
using Orange_HRM_Playwright.Pages;

namespace Orange_HRM_Playwright.Tests
{
    public class PimTests : BaseTest
    {
        private DashboardPage dashboardPage;
        private PIMPage pimPage;

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
        public void GoToPimPageTest()
        {
            pimPage = dashboardPage.ClickPimButton();
            
            Thread.Sleep(1500);
            
            Assert.That(pimPage.GetAdminTitle(), Is.EqualTo(Constants.PimPageTitle));
        }

        [Test, Order(3)]
        public void ClickAddNewEmployeeTest()
        {
            pimPage
                .ClickAddButton();
            
            Assert.That(pimPage.GetEmployeeTitle(), Is.EqualTo(Constants.AddEmployeeTitle));
        }

        [Test, Order(4)]
        public void ClickSaveWithoutPopulatingFields()
        {
            pimPage
                .ClickSave();
            
            Assert.That(pimPage.GetCustomError(1), Is.EqualTo(Constants.Required));
            Assert.That(pimPage.GetCustomError(2), Is.EqualTo(Constants.Required));
        }

        [Test, Order(5)]
        public void ClickSaveOneFieldPopulated()
        {
            pimPage
                .EnterFirstName(Constants.NewUserName)
                .ClickSave();

            Assert.That(pimPage.GetCustomError(1), Is.EqualTo(Constants.Required));
        }

        [Test, Order(6)]
        public void AddNewEmployeeTest()
        {
            pimPage
                .EnterMiddleName(Constants.IncorrectUsername);
                Thread.Sleep(500);
                pimPage.EnterLastName(Constants.LastName);
                pimPage
                .ClickSave();
            Thread.Sleep(4000);
            pimPage.GetEmployeeId();
            
            Assert.That(pimPage.GetPersonalDetails(), Is.EqualTo(Constants.PersonalDetails));
        }

        [Test, Order(7)]
        public void EmptySearchTest()
        {
            dashboardPage
                .ClickPimButton()
                .EnterEmployeeName(Constants.FakeEmployeeName);
                Thread.Sleep(1000);
                pimPage.ClickSearch();
            Thread.Sleep(3000);
            Assert.That(pimPage.GetNoRecordsError(), Is.EqualTo(Constants.NoRecords));
        }
        [Test, Order(8)]
        public void SearchWithEmployeeName()
        {
            pimPage
                .ClearEmployeeNameField()
                .EnterEmployeeName(Constants.NewUserName)
                .ClickSearch();
            
            Assert.That(pimPage.GetEmployeeName(Constants.NewUserName), Is.EqualTo(Constants.NewUserName + " " + Constants.IncorrectUsername));
        } 
        
        [Test, Order(9)]
        public void GoToEmployeeDetails()
        {
            pimPage
                .ClickOnEmployeeName(Constants.NewUserName);
            
            Assert.That(pimPage.GetPersonalDetails(), Is.EqualTo(Constants.PersonalDetails));
        }
    }
}
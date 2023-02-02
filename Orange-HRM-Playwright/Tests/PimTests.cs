
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
            
            Assert.That(pimPage.GetAdminTitle(), Is.EqualTo("PIM"));
        }

        [Test, Order(3)]
        public void ClickAddNewEmployeeTest()
        {
            pimPage
                .ClickAddButton();
            
            Assert.That(pimPage.GetEmployeeTitle(), Is.EqualTo("Add Employee"));
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
                .EnterMiddleName("Hazim");
                Thread.Sleep(500);
                pimPage.EnterLastName("Okanovic")
                .GetEmployeeId();
            pimPage
                .ClickSave();
            Thread.Sleep(4000);
            
            Assert.That(pimPage.GetPersonalDetails(), Is.EqualTo("Personal Details"));
        }
    }
}
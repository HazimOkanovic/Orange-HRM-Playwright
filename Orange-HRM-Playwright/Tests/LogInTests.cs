using System.Threading;
using NUnit.Framework;
using Orange_HRM_Playwright.Pages;

namespace Orange_HRM_Playwright.Tests
{
    public class LogInTests : BaseTest
    {
        private DashboardPage dashboardPage;

        [Test]
        public void LogIn()
        {
            landing
                
                .EnterUserName("Admin")
                .EnterPassword("admin123");
                
            dashboardPage = landing.ClickLoginButton();
            
            Assert.That(dashboardPage.GetTitle(), Is.EqualTo("Dashboard"));
        }
    }
}
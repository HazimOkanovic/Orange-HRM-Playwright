using System;
using System.Linq;

namespace Orange_HRM_Playwright
{
    public class Constants
    {
        public const string Required = "Required";
        public const string ValidPassword = "admin123";
        public const string ValidUsername = "Admin";
        public const string IncorrectUsername = "Hazim";
        public const string IncorrectPassword = "adminadmin";
        public const string CredentialsError = "Invalid credentials";
        public const string DashboardTitle = "Dashboard";
        public const string LoginTitle = "Login";
        private static Random Random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static string GenerateUsername()
        {
            return "Hazim" + RandomString(5);
        }

        public static readonly string NewUserName = GenerateUsername();
    }
}
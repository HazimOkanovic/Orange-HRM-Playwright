using System;
using System.Globalization;
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
        public const string AdminPageTitle = "Admin";
        public const string NewUserTitle = "Add User";
        public const string InvalidEmployeeName = "Hazim Okanovic";
        public const string Invalid = "Invalid";
        public const string ValidEmployeeName = "Fiona";
        public const string ShortUsername = "Haz";
        public const string ShortUserNameError = "Should be at least 5 characters";
        public const string NewRecordInvalidPassword = "SomePassword";

        public const string PasswordError =
            "Your password must contain a lower-case letter, an upper-case letter, a digit and a special character. Try a different password";

        public const string NewRecordValidPassword = "SomePassword.92";
        public const string PasswordsDontMatchError = "Passwords do not match";
        public const string PimPageTitle = "PIM";
        public const string AddEmployeeTitle = "Add Employee";
        public const string LastName = "Okanovic";
        public const string PersonalDetails = "Personal Details";
        public const string FakeEmployeeName = "Dacesin";
        public const string NoRecords = "No Records Found";
        public const string LeavePageTitle = "Leave";
        public const string AssignLeaveTitle = "Assign Leave";
        public const string ConfirmLeave = "Confirm Leave Assignment";
        public const string LeaveList = "My Leave List";
    }
}
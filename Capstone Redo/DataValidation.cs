using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Capstone_Redo
{
    internal static class DataValidation
    {
        public static bool IsValidFirstName(string name) =>
            !string.IsNullOrWhiteSpace(name) &&
            name.Length >= 2 && name.Length <= 30 &&
            Regex.IsMatch(name, @"^[A-Za-z]+$");

        public static bool IsValidLastName(string name) =>
            !string.IsNullOrWhiteSpace(name) &&
            name.Length >= 2 && name.Length <= 30 &&
            Regex.IsMatch(name, @"^[A-Za-z]+$");

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            string digitsOnly = phone.Replace(" ", "");
            return digitsOnly.Length == 11 && digitsOnly.All(char.IsDigit);
        }

        public static bool IsValidAge(int age) =>
            age >= 0 && age <= 120;

        public static bool IsValidGroupSize(int size) =>
            size > 0 && size <= 5;

        public static bool IsValidConcessionName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) &&
                   Regex.IsMatch(name, @"^[A-Za-z0-9 ]+$");
        }
        public static bool IsValidConcessionPrice(decimal price)
        {
        return price > 0 && price == Math.Round(price, 2);
        }

            public static bool IsAgeAllowed(int customerAge, int requiredAge)
        {
            return customerAge >= requiredAge;
        }

        internal static bool IsAgeAllowed(int customerAge, object requiredAge)
        {
            throw new NotImplementedException();
        }

        public static bool IsGoldMembershipExpired(DateTime expiryDate)
        {
            return DateTime.Now.Date > expiryDate.Date;
        }

        public static bool IsValidConcessionID(string id)
        {
            return !string.IsNullOrWhiteSpace(id) &&
                   id.StartsWith("C") &&
                   id.Length >= 2 &&
                   id.Skip(1).All(char.IsDigit);
        }

        public static bool IsValidMovieID(string id)
        {
            return !string.IsNullOrWhiteSpace(id) &&
                   id.StartsWith("M") &&
                   id.Length >= 2 &&
                   id.Skip(1).All(char.IsDigit);
        }

        public static string CapitalizeFirstLetters(string Input)
        {
            if (string.IsNullOrWhiteSpace(Input))
                return Input;

            Input = Input.Trim();

            if (Input.Length == 1)
                return char.ToUpper(Input[0]).ToString();

            return char.ToUpper(Input[0]) + Input.Substring(1).ToLower();
        }


    }
}

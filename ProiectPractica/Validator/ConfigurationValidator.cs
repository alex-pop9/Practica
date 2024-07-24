using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica.Validator
{
    public static class ConfigurationValidator
    {
        /// <summary>
        /// Validates a string so that it can be parsed into an integer.
        /// Returns true if the string can be parsed as an integer,
        /// and returns false otherwise.
        /// </summary>
        /// <param name="textToBeValidated"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool ValidateInt(string textToBeValidated, out string errorMessage)
        {
            if (textToBeValidated.Length == 0)
            {
                errorMessage = "Field should not be empty!";
                return false;
            }
            if (int.TryParse(textToBeValidated, out int integer))
            {
                if (integer < 0)
                {
                    errorMessage = "The number should be positive!";
                    return false;
                }
                errorMessage = "";
                return true;
            }
            else if ((!textToBeValidated.Substring(1).All(char.IsDigit) && textToBeValidated[0] != '-') || !textToBeValidated.All(char.IsDigit))
            {
                errorMessage = "This should be an integer!";
                return false;
            }
            else if (textToBeValidated.Substring(1).All(char.IsDigit) && textToBeValidated[0] == '-' && textToBeValidated.Length > 1)
            {
                errorMessage = "The number should be positive!";
                return false;
            }
            errorMessage = "The number is too big!";
            return false;
        }

        /// <summary>
        /// Validates a string so that it can be parsed into a float.
        /// Returns true if the string can be parsed as a float,
        /// and it returns false otherwise.
        /// </summary>
        /// <param name="textToBeValidated"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool ValidateFloat(string textToBeValidated, out string errorMessage)
        {
            if (textToBeValidated.Length == 0)
            {
                errorMessage = "Field should not be empty!";
                return false;
            }
            if(!float.TryParse(textToBeValidated, CultureInfo.CreateSpecificCulture("de-DE"), out float number))
            {
                errorMessage = "The number is not in correct format!";
                return false;
            }
            if (number < 0)
            {
                errorMessage = "The number should be positive!";
                return false;
            }
            if (textToBeValidated.Contains('.'))
            {
                errorMessage = "The number is not in correct format!";
                return false;
            }
            if (number > float.MaxValue)
            {
                errorMessage = "The number is too big";
                return false;
            }
            // after 7 decimals it will approximate the number, whitch can impact the configuration saved in the file
            if (textToBeValidated.Contains(',') && textToBeValidated.Substring(textToBeValidated.IndexOf(',')).Length > 7)
            {
                errorMessage = "Too many decimals!";
                return false;
            }
            errorMessage = "";
            return true;

        }

        /// <summary>
        /// Validates a string so that it can be parsed into an integer that represents an hour.
        /// Returns true if the string can be parsed as an hour,
        /// and it returns false otherwise.
        /// It also checks if the end hour is greater than start hour
        /// </summary>
        /// <param name="textToBeValidated"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool ValidateHour(string textToBeValidated, out string errorMessage)
        {
            if (textToBeValidated.Length == 0)
            {
                errorMessage = "Field should not be empty!";
                return false;
            }
            if (int.TryParse(textToBeValidated, out int hour))
            {
                // -0 passed the validation, so this: textToBeValidated[0] == '-', assures that -0 will not pass the validation
                if (hour < 0 || hour > 23 || textToBeValidated[0] == '-')
                {
                    errorMessage = "Invalid hour!";
                    return false;
                }
                errorMessage = "";
                return true;
            }
            else if ((!textToBeValidated.Substring(1).All(char.IsDigit) && textToBeValidated[0] != '-') || !textToBeValidated.All(char.IsDigit))
            {
                errorMessage = "This should be an integer!";
                return false;
            }
            errorMessage = "Invalid hour!";
            return false;
        }
    }
}

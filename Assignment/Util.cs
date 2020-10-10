

namespace Assignment
{
    /// <summary>
    /// This class is responsible of providing utility methods that can be useful on other classes.
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Splits the user input into substrings and determines the first as the command.
        /// </summary>
        /// <param name="userInput">Expected to be provided by user, but can be read from a file as well.</param>
        /// <returns>The substring from the user input that represents the command.</returns>
        public string GetCommandFromUserInput(string userInput)
        {
            return userInput.Split(' ')[0];
        }
        /// <summary>
        /// Splits the user into substrings and creates an array that contains parameters to be used.
        /// </summary>
        /// <param name="userInput">Expected to be provided by user, but can be read from a file as well.</param>
        /// <returns>An array with the ordered parameters.</returns>
        public string[] GetParametersFromUserInput(string userInput)
        {
            // Handle "help" command that has no following parameter strings.
            if (userInput.Split(' ').Length == 1)
            {
                return null;
            }
            else
            {
                // The following slice feature (like on Python) is apparently added on C# 8.
                // See https://devblogs.microsoft.com/dotnet/building-c-8-0/ for more info.
                return userInput.Split(' ')[1..^0];
            }
            
        }
    }
}
using System.Text.RegularExpressions;

namespace ZsGUtils.Validators
{
    public static class TextValidator
    {
        private const string onlyNums = "[0-9]";

        /// <summary>
        /// Checks whether the passed text composes only of numbers
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNumsOnly(string text)
        {
            return Regex.IsMatch(text, onlyNums);
        }
    }
}

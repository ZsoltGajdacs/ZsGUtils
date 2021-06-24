using System;
using System.Collections.Generic;
using System.Linq;

namespace ZsGUtils.EnumUtils
{
    public static class EnumUtil
    {
        /// <summary>
        /// Gives back the given Enum's values as an Enum list
        /// </summary>
        /// <typeparam name="T">The enum whose values are to be listed</typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Gives back the given Enum's values as a String list
        /// </summary>
        /// <typeparam name="T">The enum whose values are to be listed</typeparam>
        /// <param name="textForEmptyChoice">A string that becomes the first element in the returned list</param>
        /// <returns></returns>
        public static IEnumerable<string> GetStringValues<T>(string textForEmptyChoice = null) where T : Enum
        {
            List<string> elements = new List<string>();

            if (textForEmptyChoice != null)
            {
                elements.Add(textForEmptyChoice);
            }

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                string name;
                if (!string.IsNullOrWhiteSpace(item.GetDisplayName()))
                {
                    name = item.GetDisplayName();
                }
                else if (!string.IsNullOrWhiteSpace(item.GetDescription()))
                {
                    name = item.GetDescription();
                }
                else
                {
                    name = item.ToString();
                }

                elements.Add(name);
            }

            return elements;
        }

        /// <summary>
        /// Given the name, description or enum value it finds the enum of the given type
        /// </summary>
        /// <typeparam name="T">The found enum</typeparam>
        /// <param name="enumDisplayNameOrDescription">A string matching the name, description or as a last resort, the enum itself</param>
        /// <returns></returns>
        public static EnumMatchResult<T> GetEnumForString<T>(string enumDisplayNameOrDescription) where T : Enum
        {
            if (enumDisplayNameOrDescription == null || enumDisplayNameOrDescription == string.Empty)
            {
                return null;
            }

            IEnumerable<T> enumElements = GetValues<T>();

            EnumMatchResult<T> result = null;
            foreach (T enumElem in enumElements)
            {
                if (enumElem.GetDisplayName() == enumDisplayNameOrDescription ||
                    enumElem.GetDescription() == enumDisplayNameOrDescription ||
                    enumElem.ToString() == enumDisplayNameOrDescription)
                {
                    result = new EnumMatchResult<T>(enumElem);
                }
            }

            return result;
        }
    }

    public class EnumMatchResult<T> where T : Enum
    {
        public T FoundEnum { get; private set; }

        public EnumMatchResult(T foundEnum)
        {
            FoundEnum = foundEnum;
        }
    }
}

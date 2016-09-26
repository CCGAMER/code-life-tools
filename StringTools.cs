using System.Collections.Generic;
using System.Linq;

namespace code_life_tools
{
    /// <summary>
    /// A Set of tools to use with strings in order to give users a better user experience.
    /// </summary>
    public static class StringTools
    {
        #region Enumerations
        /// <summary>
        /// Comma Modifier enumeration to use in ModifyingCommas
        /// </summary>
        public enum CommaModifier
        {
            /// <summary>
            /// Without a comma, such as "Hello World Computer"
            /// </summary>
            WithoutComma,
            /// <summary>
            /// With commas, such as "Hello, World, and Computer"
            /// </summary>
            CommaWithAnd
        }


        /// <summary>
        /// The method that StringTools use to seperate digits. Like 3 by 3 and 2 by 3 according to the country.
        /// </summary>
        public enum DigitSeperationType
        {
            /// <summary>
            /// 10,000,000
            /// </summary>
            European,
            /// <summary>
            /// 10,10,000
            /// </summary>
            Indian
        }
        #endregion

        #region Methods

        /// <summary>
        /// Parses Integers in to currency as strings.
        /// </summary>
        /// <param name="currency">Amount of money</param>
        /// <param name="seperationType">Type of seperation in commas</param>
        /// <returns></returns>
        public static string ParseIntToCurrency(int currency, DigitSeperationType seperationType)
        {
            string return_value = "";

            string currency_string = currency.ToString();

            switch (seperationType)
            {
                case DigitSeperationType.European:
                    int digitcounter = 0;
                    for (int i = 0; i < currency_string.Length; i++)
                    {
                        digitcounter++;
                        if (digitcounter != 3)
                        {
                            return_value = currency_string[currency_string.Length - (i + 1)] + return_value;
                        }
                        else
                        {
                            if (i == currency_string.Length - 1)
                            {
                                return_value = currency_string[currency_string.Length - (i + 1)] + return_value;
                                digitcounter = 0;
                            }
                            else
                            {
                                return_value = "," + currency_string[currency_string.Length - (i + 1)] + return_value;
                                digitcounter = 0;
                            }
                        }
                    }
                    break;
                case DigitSeperationType.Indian:
                    int digitcounter2 = 3;
                    for (int i = 0; i < currency_string.Length; i++)
                    {
                        digitcounter2--;
                        if (digitcounter2 != 0)
                        {
                            return_value = currency_string[currency_string.Length - (i + 1)] + return_value;
                        }
                        else
                        {
                            if (i == currency_string.Length - 1)
                            {
                                return_value = currency_string[currency_string.Length - (i + 1)] + return_value;
                                digitcounter2 = 2;
                            }
                            else
                            {
                                return_value = "," + currency_string[currency_string.Length - (i + 1)] + return_value;
                                digitcounter2 = 2;
                            }
                        }
                    }
                    break;
            }

            return return_value;
        }
        
        /// <summary>
        /// Modified string that forms a string array into comma and 'and' based string.
        /// </summary>
        /// <param name="list_contents">The list of content as a string array</param>
        /// <param name="modifier">The comma modification of the content listing</param>
        /// <returns>Returns a formatted string as comma based string</returns>
        public static string ModifyComma(string[] list_contents, CommaModifier modifier)
        {
            string return_value = "";

            for (int i = 0; i < list_contents.Length; i++)
            {
                if (i == list_contents.Length - 1)
                {
                    //final element
                    switch (modifier)
                    {
                        case CommaModifier.WithoutComma:
                            return_value += " " + list_contents[i].ToString();
                            break;
                        case CommaModifier.CommaWithAnd:
                            return_value += "and " + list_contents[i].ToString();
                            break;
                    }
                }
                else
                {
                    //not the final element
                    switch (modifier)
                    {
                        case CommaModifier.WithoutComma:
                            return_value += list_contents[i].ToString() + " ";
                            break;
                        case CommaModifier.CommaWithAnd:
                            return_value += list_contents[i].ToString() + ", ";
                            break;
                    }
                    
                }
            }

            return return_value;
        }
        /// <summary>
        /// Check whether two strings are anagrams are not.
        /// </summary>
        /// <param name="StringA"></param>
        /// <param name="StringB"></param>
        /// <returns>Whether the two strings are anagrams or not as a bool</returns>
        public static bool? IsAnagram(string StringA, string StringB)
        {
            bool? return_value = null;
            if (StringA.Length == StringB.Length)
            {
                bool anagram = false;

                //used for loop instead of foreach because it's fast, obviously :)
                for (int i = 0; i < StringA.Length; i++)
                {
                    bool current_match = false;

                    for (int i2 = 0; i < StringB.Length; i2++)
                    {
                        if  (StringA[i].ToString().ToLower() == StringB[i2].ToString().ToLower())
                        {
                            current_match = true;
                            break;
                        }
                    }

                    if (current_match == false)
                    {
                        anagram = false;
                    }
                    else
                    {
                        anagram = true;
                    }
                }

                return_value = anagram;
            }

            return return_value;
        }

        /// <summary>
        /// Get the number of vowels in the input string_content using Loops instead of LINQ. (FASTER!!)
        /// </summary>
        /// <param name="string_content">The string that you want see the number of vowels of.</param>
        /// <returns>Returns an int containing the number of vowels in the specific string</returns>
        public static int numberOfVowelsUsingLoops(string string_content)
        {
            int return_value = 0;

            //Used the for loop instead of foreach loop, because it's faster :)
            for (int i = 0; i < string_content.Length; i++)
                if (string_content[i] == 'a' || string_content[i] == 'e' || string_content[i] == 'i' || string_content[i] == 'o' || string_content[i] == 'u')
                    return_value++;

            return return_value;
        }

        /// <summary>
        /// Returns the number of vowels in the input string_content using LINQ instead of loops. (SLOWER, can see in different scenarios)
        /// </summary>
        /// <param name="string_content">Input string that you want to see the number of vowels of.</param>
        /// <returns>Returns an int containing the number of vowels in the specific string.</returns>
        public static int numberOfVowelsUsingLINQ(string string_content)
        {
            char[] chararray = string_content.ToCharArray();
            IEnumerable<char> filteredCharacters = chararray.Where(n => n.ToString().Contains("a") | n.ToString().Contains("e") | n.ToString().Contains("i") | n.ToString().Contains("o") | n.ToString().Contains("u"));
            return filteredCharacters.Count();
        }

        /// <summary>
        /// Reverses the string that is entered.
        /// </summary>
        /// <param name="string_content">The string that you want to reverse</param>
        /// <returns>A reversed string of the entered string</returns>
        public static string ReverseString(string string_content)
        {
            string return_string = "";

            for (int i = 0; i < string_content.Length; i++)
            {
                return_string = return_string + string_content[string_content.Length - (i + 1)];
            }

            return return_string;
        }
        #endregion
    }
}
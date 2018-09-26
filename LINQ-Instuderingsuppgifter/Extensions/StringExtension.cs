using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Instuderingsuppgifter.Extensions
{
    public static class StringExtension
    {
        public static bool IsNumeric (this string text)
        {
            int result;
            return int.TryParse(text, out result);
        }

        public static string UppercaseWordFirstLetter(this string text)
        {

            string[] words = text.Split(' ');
            text = "";
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].First().ToString().ToUpper() + words[i].Substring(1, words[i].Length - 1) + " ";
                text = string.Concat(text, words[i]);
            }
            
            return text;
        }
        public static DateTime GetLastDateOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
        public static string ListToString(this List<string> strings)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string s in strings)
            {
                if (!(s == strings.First()))
                    builder.Append(", ");
                builder.Append(s);
            }
            return builder.ToString();
        }
        public static List<int> Add(this List<int> list, params int[] i)
        {
            list.AddRange(i);
            return list;
        }
    }
}

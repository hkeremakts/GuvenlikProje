using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceWord(this string str, string word, string replaceWord)
        {
            var pattern = $"\\b{word}\\b";
            return Regex.Replace(str, pattern, replaceWord, RegexOptions.IgnoreCase);
        }
    }
}

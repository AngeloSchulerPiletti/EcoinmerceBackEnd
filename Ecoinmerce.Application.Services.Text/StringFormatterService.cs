using Ecoinmerce.Application.Services.Text.Interfaces;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Ecoinmerce.Application.Services.Text
{
    public class StringFormatterService : IStringFormatterService
    {
        public string FormatLowerNeutralString(string str)
        {
            string initialHandle = str.ToLower()
                                        .Replace(" ", "-")
                                        .Replace(":", "-")
                                        .Replace("/", "-")
                                        .Replace("\\", "-")
                                        .Replace("|", "-");

            string accentRemoved = RemoveAccent(initialHandle);

            string specialSimbolsRemoved = Regex.Replace(accentRemoved, @"[^a-zA-Z0-9\-]", "");

            return specialSimbolsRemoved;
        }

        public string RemoveAccent(string str)
        {
            var normalizedString = str.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}

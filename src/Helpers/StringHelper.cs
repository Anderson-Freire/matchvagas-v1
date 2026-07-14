using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace src.Helpers
{
    public static class StringHelper
    {
        private static readonly Regex _normalizeRegex = new(@"[^a-z0-9-]", RegexOptions.Compiled);
        private static readonly Regex _spaceRegex = new(@"\s", RegexOptions.Compiled);

        public static string NormalizeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            var normalized = name.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();
            foreach (var c in normalized)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            var withHyphens = _spaceRegex.Replace(builder.ToString().ToLower().Trim(), "-");
            return _normalizeRegex.Replace(withHyphens, "");
        }
    }
}
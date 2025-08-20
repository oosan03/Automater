using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace local.Models.Utilities
{
    public class ShrinkLogMessage
    {
        public static string ShortenPathSegments(string path, int keepSegments = 3)
        {
            if (string.IsNullOrWhiteSpace(path)) return path;
            var parts = path.Split(new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length <= keepSegments) return path.TrimEnd('\\', '/');
            return string.Join("\\", parts.Skip(parts.Length - keepSegments));
        }

        // Replace every absolute Windows path in a message with its last N segments
        public static string ShortenAnyPaths(string message, int keepSegments = 3)
        {
            if (string.IsNullOrEmpty(message)) return message;

            // Matches "C:\something\..." or UNC "\\server\share\..."
            const string pattern = @"(?:(?:[A-Za-z]:\\)|(?:\\\\))[^:*?""<>|\r\n]+";

            return Regex.Replace(message, pattern, m =>
            {
                var p = m.Value.TrimEnd('\\', '/');
                return ShortenPathSegments(p, keepSegments);
            });
        }


    }
}

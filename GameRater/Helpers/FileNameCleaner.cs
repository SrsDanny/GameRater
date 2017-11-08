using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GameRater.Helpers
{
    public static class FileNameCleaner
    {
        public static string CleanFileName(string fileName)
        {
            var invalidChars = Regex.Escape(Path.GetInvalidFileNameChars().ToString());
            var invalidCharactersRegex = new Regex($"[{invalidChars}]");
            return invalidCharactersRegex.Replace(fileName, "");
        }

        public static string GameNameToFileName(string title)
        {
            var imageName = title.ToLower().Replace(' ', '-');
            return CleanFileName(imageName);
        }
    }
}
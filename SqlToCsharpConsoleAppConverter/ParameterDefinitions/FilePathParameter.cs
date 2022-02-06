using ConsoleAppParametersHandler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SqlToCsharpConsoleAppConverter.ParameterDefinitions
{
    internal sealed class FilePathParameter : RegexValidatedParameter
    {
        protected override Regex RegexPattern { get; } = new Regex(@"^(\.|[A-Za-z]:)(\\\w+)+(\.\w+)?$");

        public FilePathParameter(char code, string description, bool required = false, params string[] extensions) 
            : base(code, description, required)
        {
            if (extensions?.Count() > 0)
            {
                string pattern = @$"^(\.|[A-Za-z]:)(\\\w+)+{MergeExtensionPatterns(extensions)}$";
                RegexPattern = new Regex(pattern);
            }
        }

        private string MergeExtensionPatterns(ICollection<string> extensions)
        {
            var extensionPatterns = extensions.Select(s => ExtensionToPattern(s));
            return $"\\.({string.Join("|", extensionPatterns)})";
        }

        private string ExtensionToPattern(string extension)
        {
            var charPatterns = extension.Select(c => $"[{char.ToUpper(c)}{char.ToLower(c)}]");
            return string.Join(string.Empty, charPatterns);
        }
    }
}

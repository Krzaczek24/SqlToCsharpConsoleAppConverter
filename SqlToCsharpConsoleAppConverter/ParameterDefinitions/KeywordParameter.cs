using ConsoleAppParametersHandler;
using System.Text.RegularExpressions;

namespace SqlToCsharpConsoleAppConverter.ParameterDefinitions
{
    internal sealed class KeywordParameter : RegexValidatedParameter
    {
        protected override Regex RegexPattern { get; } = new Regex(@"^[a-z]{2,}$");

        public KeywordParameter(char code, string description, bool required = false) : base(code, description, required) { }
    }
}

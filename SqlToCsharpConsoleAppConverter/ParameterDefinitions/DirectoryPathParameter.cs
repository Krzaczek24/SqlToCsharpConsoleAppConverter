using ConsoleAppParametersHandler;
using System.Text.RegularExpressions;

namespace SqlToCsharpConsoleAppConverter.ParameterDefinitions
{
    internal sealed class DirectoryPathParameter : RegexValidatedParameter
    {
        protected override Regex RegexPattern { get; } = new Regex(@"^((\.|[A-Za-z]:)[\\\/])?($|[\w\-\.]+([\\\/][\w\-\.]+)*[\\\/]?$)");

        public DirectoryPathParameter(char code, string description, bool required = false) : base(code, description, required) { }

        protected override string ModifyValue(string value)
        {
            value = value.Replace('/', '\\');
            return value.EndsWith('\\') ? value : value + '\\';
        }
    }
}

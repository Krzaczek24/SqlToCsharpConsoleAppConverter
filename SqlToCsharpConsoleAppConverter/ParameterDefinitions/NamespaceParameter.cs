using ConsoleAppParametersHandler;
using System.Text.RegularExpressions;

namespace SqlToCsharpConsoleAppConverter.ParameterDefinitions
{
    internal sealed class NamespaceParameter : RegexValidatedParameter
    {
        protected override Regex RegexPattern { get; } = new Regex(@"^[A-Z]\w*(\.[A-Z]\w*)*$");

        public NamespaceParameter(char code, string description, bool required = false) : base(code, description, required) { }
    }
}

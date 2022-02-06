using ConsoleAppParametersHandler;
using System.Text.RegularExpressions;

namespace SqlToCsharpConsoleAppConverter.ParameterDefinitions
{
    internal sealed class StemmingParameter : RegexValidatedParameter
    {
        protected override Regex RegexPattern { get; } = new Regex(@"^([A-Z]\w*)+$");

        public StemmingParameter(char code, string description, bool required = false) : base(code, description, required) { }
    }
}

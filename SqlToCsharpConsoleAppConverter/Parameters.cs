using ConsoleAppParametersHandler;
using SqlToCsharpConsoleAppConverter.ParameterDefinitions;
using System.Collections.Generic;

namespace SqlToCsharpConsoleAppConverter
{
    internal static class Parameters
    {
        private class CustomParametersHelper : ParametersHelper
        {
            public CustomParametersHelper(ICollection<ParameterDefinition> parametersDefinition) : base(parametersDefinition) { }
        }

        private static CustomParametersHelper ph = new CustomParametersHelper(new ParameterDefinition[] {
            new FilePathParameter('i', "Input sql script file path (e.g. 'C:\\directory\\script.sql')", true, "sql"),
            new DirectoryPathParameter('o', "Output class files path (e.g. 'C:\\directory\\output\\')\n\toutput files will be placed in input directory if parameter will not be passed"),
            new NamespaceParameter('n', "Output classes namespace (e.g. 'Database.Models')"),
            new StemmingParameter('p', "Output classes prefix (e.g. 'Db' => 'Db<TableName>.cs')"),
            new StemmingParameter('s', "Output classes suffix (e.g. 'Model' => '<TableName>Model.cs')"),
            new StemmingParameter('b', "Base class name for model with common fields (e.g. 'DbCommonModel' => 'DbCommonModel.cs')\n\tthere will be no common class if parameter will not be passed"),
            new NamespaceParameter('a', "Base class namespace (e.g. 'Database.Models.Base')\n\trequired if base class is set", conditionalRequirement: () => BaseClassIsSet),
            new ParameterDefinition('c', "Print to console result summary.")
        });

        public static bool ShowResultSummary => ph.Get('c').Found;
        public static string InputPath { get => ph.Get('i').Value; set => ph.Get('i').Value = value; }
        public static string OutputPath { get => ph.Get('o').Value; set => ph.Get('o').Value = value; }
        public static string Namespace { get => ph.Get('n').Value; set => ph.Get('n').Value = value; }
        public static string ClassPrefix { get => ph.Get('p').Value; set => ph.Get('p').Value = value; }
        public static string ClassSuffix { get => ph.Get('s').Value; set => ph.Get('s').Value = value; }
        public static string BaseClassName { get => ph.Get('b').Value; set => ph.Get('b').Value = value; }
        public static string BaseClassNamespace { get => ph.Get('a').Value; set => ph.Get('a').Value = value; }
        private static bool BaseClassIsSet => ph?.Get('b').Found ?? false;

        public static void Init(IEnumerable<string> inputArgs)
        {
            ph.Init(inputArgs);
        }
    }
}

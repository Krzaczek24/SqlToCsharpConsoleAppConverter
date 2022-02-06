using NLog;
using SqlToCsharpConsoleAppConverter.Extensions;
using SqlToCsharpConsoleAppConverter.Helpers;
using SqlToCsharpTranscriptor;
using System;
using System.IO;

namespace SqlToCsharpConsoleAppConverter
{
    public class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private static readonly Type[] IncidentExceptions = new[] { 
            typeof(ArgumentException), 
            typeof(IOException)
        };

        public static void Main(string[] args)
        {
            try
            {
                Run(args);
            }
            catch (Exception ex) when (ex.Is(IncidentExceptions))
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occured! Check logs for more details.");
                Logger.Fatal(ex, "Unexpected error occured:");
            }
        }

        public static void Run(string[] args)
        {
            Parameters.Init(args);

            FilesHelper.TryReadInputFile();
            FilesHelper.SetOutputPathIfNone();
            FilesHelper.TryCreateOutputFile();

            Converter
                .LoadSqlScriptData(Parameters.InputPath)
                .ConvertToCsharpClassesUsingParams()
                .SaveClassesToFiles(Parameters.OutputPath);

            if (Parameters.ShowResultSummary)
                Console.WriteLine(FilesHelper.GetDirectorySummary());
        }
    }
}
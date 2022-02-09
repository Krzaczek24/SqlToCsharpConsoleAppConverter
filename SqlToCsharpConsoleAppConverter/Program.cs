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
        private static readonly Type[] ExpectedExceptions = new[] { 
            typeof(ArgumentException), 
            typeof(IOException)
        };

        public static void Main(string[] args)
        {
#if DEBUG
            args = new[] { "-i", "DFMS_create.sql", "-n", "DFMS.Database", "-p", "Db", "-b", "DbTableCommonModel", "-a", "DFMS.Database.Base" };
#endif

            try
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
            catch (Exception ex) when (ex.IsIn(ExpectedExceptions))
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occured! Check logs for more details.");
                Logger.Fatal(ex, "Unexpected error occured:");
            }
        }
    }
}
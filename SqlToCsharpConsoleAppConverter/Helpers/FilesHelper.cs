using System;
using System.IO;
using System.Linq;

namespace SqlToCsharpConsoleAppConverter.Helpers
{
    internal static class FilesHelper
    {
        internal static void TryReadInputFile()
        {
            try
            {
                var input = File.OpenRead(Parameters.InputPath);
                bool canRead = input.CanRead;
                input.Close();
                if (!canRead)
                    throw new IOException($"Cannot read input file [{Parameters.InputPath}].");
            }
            catch (Exception ex)
            {
                throw new IOException($"Error occured while trying to open input file [{Parameters.InputPath}].\nError message: " + ex.Message);
            }
        }

        internal static void TryCreateOutputFile()
        {
            string outputFilePath = Parameters.OutputPath + "TestClass.cs";

            try
            {
                Directory.CreateDirectory(Parameters.OutputPath);
                var output = File.Create(outputFilePath);
                bool canWrite = output.CanWrite;
                output.Close();
                File.Delete(outputFilePath);
                if (!canWrite)
                    throw new IOException($"Cannot write output file [{outputFilePath}].");
            }
            catch (Exception ex)
            {
                throw new IOException($"Error occured while trying to create output file [{outputFilePath}].\nError message: " + ex.Message);
            }
        }

        internal static void SetOutputPathIfNone()
        {
            if (string.IsNullOrWhiteSpace(Parameters.OutputPath))
            {
                var pathElems = Parameters.InputPath.Split('\\', StringSplitOptions.RemoveEmptyEntries).SkipLast(1);
                Parameters.OutputPath = string.Join('\\', pathElems) + "\\output\\";
                return;
            }
        }
    }
}

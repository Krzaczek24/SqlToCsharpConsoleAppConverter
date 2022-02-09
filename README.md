# SqlToCsharpConverter

## This is application allows to convert SQL script to C# database models.

In this application the only thing I do is defining custom list of parameters using `ConsoleAppParametersHandler` and passing those parameters to converter from `SqlToCsharpTranscriptor`

So core of this app looks like this:
```
Parameters.Init(args);

FilesHelper.TryReadInputFile();    // using static Parameters
FilesHelper.SetOutputPathIfNone(); // using static Parameters
FilesHelper.TryCreateOutputFile(); // using static Parameters

Converter
  .LoadSqlScriptData(Parameters.InputPath)
  .ConvertToCsharpClassesUsingParams()
  .SaveClassesToFiles(Parameters.OutputPath);

if (Parameters.ShowResultSummary)
  Console.WriteLine(FilesHelper.GetDirectorySummary());
```

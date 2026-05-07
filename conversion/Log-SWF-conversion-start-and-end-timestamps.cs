using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        var inputFiles = new string[] { "sample1.pptx", "sample2.pptx" };

        foreach (var inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                continue;
            }

            try
            {
                var startTime = DateTime.Now;
                Console.WriteLine($"Starting SWF conversion for '{inputPath}' at {startTime}");

                var presentation = new Aspose.Slides.Presentation(inputPath);
                var swfOptions = new Aspose.Slides.Export.SwfOptions();

                var outputPath = Path.ChangeExtension(inputPath, ".swf");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                presentation.Dispose();

                var endTime = DateTime.Now;
                Console.WriteLine($"Finished SWF conversion for '{inputPath}' at {endTime} (Duration: {(endTime - startTime).TotalSeconds} seconds)");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine($"Format not supported for file: {inputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file '{inputPath}': {ex.Message}");
            }
        }
    }
}
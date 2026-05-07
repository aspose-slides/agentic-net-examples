using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "sample.pptx";
        }

        // Log file for conversion failures
        string logPath = "conversion.log";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            File.WriteAllText(logPath, $"Input file not found: {inputPath}");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Define output path (PDF)
            string outputPath = Path.ChangeExtension(inputPath, ".pdf");

            // Save the presentation as PDF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

            // Dispose the presentation before exiting
            presentation.Dispose();
        }
        catch (NotSupportedException notSupportedEx)
        {
            // Handle unsupported format exception
            File.AppendAllText(logPath, $"Conversion failed (format not supported): {notSupportedEx.Message}");
        }
        catch (Exception ex)
        {
            // Log any other conversion failures
            File.AppendAllText(logPath, $"Conversion failed: {ex.Message}");
        }
    }
}
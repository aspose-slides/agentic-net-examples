using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path (from arguments or default)
        string inputPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "input.pptx"; // default input file
        }

        // Define output file path (convert to PDF as an example)
        string outputPath = Path.ChangeExtension(inputPath, ".pdf");

        // Log file to record conversion failures
        string logPath = "conversion.log";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            File.WriteAllText(logPath, $"Input file not found: {inputPath}{Environment.NewLine}");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation in the desired format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

            // Release resources
            presentation.Dispose();
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Log unsupported format exception
            File.AppendAllText(logPath, $"Unsupported format (PPT): {ex.Message}{Environment.NewLine}");
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Log unsupported format exception for PPTX
            File.AppendAllText(logPath, $"Unsupported format (PPTX): {ex.Message}{Environment.NewLine}");
        }
        catch (Exception ex)
        {
            // Log any other conversion failures
            File.AppendAllText(logPath, $"Conversion failed: {ex.Message}{Environment.NewLine}");
        }
    }
}
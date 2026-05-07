using System;
using System.IO;
using System.Text;
using Aspose.Slides;
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
            inputPath = "input.pptx"; // default placeholder
        }

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Prepare intermediate and output file paths
        string intermediatePptx = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, "intermediate.pptx");
        string outputFodp = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, "output.fodp");
        string reportPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, "diagnostic_report.txt");

        // StringBuilder for diagnostic report
        StringBuilder reportBuilder = new StringBuilder();

        try
        {
            // Load the original presentation
            Presentation pres1 = new Presentation(inputPath);
            // Save as intermediate PPTX (fodp-format-convertion rule)
            pres1.Save(intermediatePptx, Aspose.Slides.Export.SaveFormat.Pptx);
            pres1.Dispose();

            // Load the intermediate PPTX
            Presentation pres2 = new Presentation(intermediatePptx);
            // Save as final FODP (fodp-format-convertion rule)
            pres2.Save(outputFodp, Aspose.Slides.Export.SaveFormat.Fodp);
            pres2.Dispose();

            reportBuilder.AppendLine("Conversion succeeded.");
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Handle unsupported PPTX format
            reportBuilder.AppendLine("Warning: PPTX format unsupported. " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Handle unsupported PPT format
            reportBuilder.AppendLine("Warning: PPT format unsupported. " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            reportBuilder.AppendLine("Error: " + ex.Message);
        }

        // Write the diagnostic report to a file
        try
        {
            File.WriteAllText(reportPath, reportBuilder.ToString());
            Console.WriteLine("Diagnostic report written to " + reportPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to write diagnostic report: " + ex.Message);
        }
    }
}
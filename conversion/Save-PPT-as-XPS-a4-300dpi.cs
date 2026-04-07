using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.xps";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Set slide size to A4 paper with maximize scaling (custom page size)
            presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);

            // Note: DPI setting is not applicable for XPS format; default resolution will be used.

            // Save the presentation as XPS
            presentation.Save(outputPath, SaveFormat.Xps);

            // Dispose the presentation before exiting
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
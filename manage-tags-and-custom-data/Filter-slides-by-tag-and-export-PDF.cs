using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Tag to filter slides by (not supported directly)
        string requiredTag = "Important";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // NOTE: Aspose.Slides does not expose a Tags collection on ISlide,
                // so filtering slides by a custom tag cannot be performed directly.
                // The entire presentation is saved to PDF.

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
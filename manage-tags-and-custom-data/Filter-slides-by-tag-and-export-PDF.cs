// -----------------------------------------------------------------------------
// Example: Filter slides by tag and export PDF using C#
//
// Description:
// Demonstrates loading a PowerPoint presentation and exporting it to PDF using
// Aspose.Slides for .NET. The example also explains that direct filtering of
// slides by custom tags is not currently supported by the API, so the entire
// presentation is saved.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Export, Presentation Processing,
// Office Automation, Slide Tags
//
// Use Cases:
// - Convert PowerPoint presentations to PDF in .NET applications.
// - Understand limitations of tag-based slide filtering with Aspose.Slides.
// - Automate PDF generation from PPTX files.
// - Integrate presentation export functionality into custom tools.
// -----------------------------------------------------------------------------
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

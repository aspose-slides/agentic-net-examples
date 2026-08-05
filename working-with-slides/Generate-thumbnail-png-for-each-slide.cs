// -----------------------------------------------------------------------------
// Example: Generate thumbnail png for each slide using C#
//
// Description:
// Demonstrates how to generate thumbnail PNG images for each slide in a PowerPoint
// presentation using Aspose.Slides for .NET. The example loads a PPTX file,
// creates PNG thumbnails of a specified size for each slide, saves them to a
// designated directory, and optionally saves the presentation after processing.
// Developers can use this pattern to automate PPTX workflows, extract visual
// previews, or integrate slide thumbnail generation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Generate, Thumbnail, Each,
// Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of PNG thumbnails for each slide in a presentation.
// - Build C# tools for PowerPoint presentation preview extraction.
// - Integrate slide thumbnail creation into .NET applications or CI pipelines.
// - Validate and visualize presentation content before publishing or further processing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        var inputPath = "input.pptx";
        var outputDir = "thumbnails";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            var presentation = new Presentation(inputPath);

            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                var slide = presentation.Slides[i];
                using (var image = slide.GetImage(new Size(200, 150)))
                {
                    var outputPath = Path.Combine(outputDir, $"slide_{i + 1}.png");
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save the presentation (required by the task)
            var savedPresentationPath = "output.pptx";
            presentation.Save(savedPresentationPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or web services)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

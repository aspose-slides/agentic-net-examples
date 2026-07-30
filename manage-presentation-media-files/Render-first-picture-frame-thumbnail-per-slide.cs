// -----------------------------------------------------------------------------
// Example: Render first picture frame thumbnail per slide using C#
//
// Description:
// Demonstrates how to render first picture frame thumbnail per slide using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Render, First, Picture, Frame, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate render first picture frame thumbnail per slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        var inputPath = "input.pptx";
        // Output directory for thumbnails
        var outputDir = "Thumbnails";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        try
        {
            // Load presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                var slide = presentation.Slides[i];
                Aspose.Slides.IPictureFrame pictureFrame = null;

                // Find the first picture frame on the slide
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.IPictureFrame)
                    {
                        pictureFrame = (Aspose.Slides.IPictureFrame)shape;
                        break;
                    }
                }

                // If a picture frame is found, render its thumbnail
                if (pictureFrame != null)
                {
                    using (var image = pictureFrame.GetImage())
                    {
                        var thumbnailPath = Path.Combine(outputDir, $"slide_{slide.SlideNumber}_thumb.png");
                        image.Save(thumbnailPath, Aspose.Slides.ImageFormat.Png);
                    }
                }
            }

            // Save presentation before exit
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

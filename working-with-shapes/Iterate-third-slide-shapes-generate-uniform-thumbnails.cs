// -----------------------------------------------------------------------------
// Example: Iterate third slide shapes generate uniform thumbnails using C#
//
// Description:
// Demonstrates how to iterate third slide shapes generate uniform thumbnails 
// using C# and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Iterate, Third, Slide, Shapes, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate iterate third slide shapes generate uniform thumbnails.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for thumbnails
            string outputDirectory = "thumbnails";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Verify the presentation has at least three slides
                if (pres.Slides.Count < 3)
                {
                    Console.WriteLine("The presentation does not contain a third slide.");
                    pres.Dispose();
                    return;
                }

                // Access the third slide (index 2)
                Aspose.Slides.ISlide slide = pres.Slides[2];

                // Iterate over all shapes on the third slide
                int shapeIndex = 0;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Generate a thumbnail for the shape with uniform scaling (1.0f, 1.0f)
                    Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1.0f, 1.0f);

                    // Save the thumbnail as PNG
                    string outputPng = Path.Combine(outputDirectory, $"shape_{shapeIndex}.png");
                    shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

                    shapeIndex++;
                }

                // Save the presentation before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

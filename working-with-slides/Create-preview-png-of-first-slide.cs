// -----------------------------------------------------------------------------
// Example: Create preview png of first slide using C#
//
// Description:
// Demonstrates how to create preview png of first slide using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Preview, First, Slide, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate create preview png of first slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PreviewGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output PNG preview path
            string previewPath = "slide1.png";
            // Output presentation path (saved before exit)
            string outputPresPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                // Input file not found; exit the program
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide firstSlide = pres.Slides[0];

                    // Generate a thumbnail image of the first slide
                    using (IImage thumbnail = firstSlide.GetImage())
                    {
                        // Save the thumbnail as PNG
                        thumbnail.Save(previewPath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation before exiting
                    pres.Save(outputPresPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // The file format is not supported
                Console.WriteLine("The presentation format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Resize Slides and Export to PDF using C#
// 
// Description:
// Demonstrates how to resize all slides in a PowerPoint presentation to a custom
// size and export the result to a PDF file using Aspose.Slides for .NET. The program
// creates a sample PPTX if none exists, applies a new slide dimension while ensuring
// existing content scales to fit, and saves the transformed presentation as PDF.
// 
// Keywords:
// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Resize Slides, Export
// 
// Use Cases:
// - Automate slide size standardization before publishing.
// - Convert resized PowerPoint decks to PDF for distribution.
// - Integrate slide resizing and PDF export into CI/CD pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

namespace SlideResizeAndExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Ensure input file exists; create a simple presentation if missing
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide firstSlide = samplePresentation.Slides[0];
                    Aspose.Slides.IAutoShape rectangle = firstSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                    rectangle.AddTextFrame("Sample slide");
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.EnsureFit);
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
                presentation.Dispose();
                Console.WriteLine("Presentation resized and exported to PDF successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}

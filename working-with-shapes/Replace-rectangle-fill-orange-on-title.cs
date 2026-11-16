// -----------------------------------------------------------------------------
// Example: Replace rectangle fill with orange on title slide using C#
// 
// Description:
// Demonstrates how to load a PowerPoint PPTX, create a sample file if missing,
// iterate over rectangle AutoShapes on the first slide, change their fill to solid
// orange while keeping borders, and save the modified presentation. Useful for
// automating color adjustments in .NET applications.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, rectangle fill, orange color, automation
// 
// Use Cases:
// - Ensure branding colors on title slides across multiple presentations.
// - Build a command‑line tool to batch‑process PPTX files for color compliance.
// - Generate sample presentations programmatically for testing or demos.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace ReplaceRectangleFill
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Create a sample presentation if the input file does not exist
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide firstSlide = samplePres.Slides[0];
                    // Add a rectangle AutoShape
                    Aspose.Slides.IShape rectShape = firstSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
                    // Set an initial fill (e.g., light gray) to demonstrate change
                    Aspose.Slides.IAutoShape autoRect = rectShape as Aspose.Slides.IAutoShape;
                    if (autoRect != null)
                    {
                        autoRect.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        autoRect.FillFormat.SolidFillColor.Color = Color.LightGray;
                    }
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    return 1;
                }
            }

            // Verify that the input file now exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return 1;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide titleSlide = presentation.Slides[0];

                foreach (Aspose.Slides.IShape shape in titleSlide.Shapes)
                {
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                    {
                        autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        autoShape.FillFormat.SolidFillColor.Color = Color.Orange;
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The presentation format is not supported for this operation.");
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 1;
            }

            Console.WriteLine("Presentation processed successfully. Output saved to: " + outputPath);
            return 0;
        }
    }
}

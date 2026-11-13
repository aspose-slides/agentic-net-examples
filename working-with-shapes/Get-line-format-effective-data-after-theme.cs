// -----------------------------------------------------------------------------
// Example: Get line format effective data after theme using C#
// 
// Description:
// Demonstrates how to retrieve the effective line format of a shape after
// applying a theme in a PowerPoint presentation using Aspose.Slides for .NET.
// The program creates a sample PPTX if none exists, extracts effective line
// properties, outputs them, and saves the presentation.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line Format, Effective Data, Theme
// 
// Use Cases:
// - Automate extraction of line formatting details after theme application.
// - Validate visual consistency of shapes in generated presentations.
// - Integrate line format analysis into .NET PowerPoint processing tools.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "example.pptx";
            string outputPath = "output.pptx";

            // Create sample presentation if it does not exist
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide slide = samplePres.Slides[0];
                    Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
                    autoShape.LineFormat.Width = 3;
                    autoShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    autoShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample presentation: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // Verify that the input file now exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                Environment.Exit(1);
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    if (presentation.Slides.Count == 0)
                    {
                        Console.WriteLine("Presentation contains no slides.");
                        Environment.Exit(1);
                    }

                    Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
                    if (firstSlide.Shapes.Count == 0)
                    {
                        Console.WriteLine("First slide contains no shapes.");
                        Environment.Exit(1);
                    }

                    Aspose.Slides.IShape shape = firstSlide.Shapes[0];
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape == null)
                    {
                        Console.WriteLine("First shape is not an AutoShape with line formatting.");
                        Environment.Exit(1);
                    }

                    Aspose.Slides.ILineFormatEffectiveData effectiveLine = autoShape.LineFormat.GetEffective();

                    Console.WriteLine("Effective Line Style: " + effectiveLine.Style);
                    Console.WriteLine("Effective Line Width: " + effectiveLine.Width);
                    Console.WriteLine("Effective Line Fill Type: " + effectiveLine.FillFormat.FillType);

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPTX).");
                Environment.Exit(1);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPT).");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}

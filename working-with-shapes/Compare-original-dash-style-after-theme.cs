// -----------------------------------------------------------------------------
// Example: Compare original dash style after theme inheritance using C#
// 
// Description:
// Demonstrates how to retrieve the original dash style set on a shape's line format
// and compare it with the effective dash style after theme inheritance using
// Aspose.Slides for .NET. The program creates a sample PPTX if none exists,
// prints both dash styles, and saves the presentation.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Dash Style, Line Format, Theme
// 
// Use Cases:
// - Verify how line dash styles are affected by theme changes.
// - Build validation tools for PowerPoint formatting.
// - Automate reporting of shape visual properties.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace CompareDashStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Create a sample presentation if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                    Aspose.Slides.IShape sampleShape = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
                    sampleShape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Ensure there is at least one shape
                if (slide.Shapes.Count == 0)
                {
                    Console.WriteLine("No shapes found on the first slide.");
                    pres.Dispose();
                    Environment.Exit(1);
                }

                // Get the first shape
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Ensure the shape has a line format
                if (shape.LineFormat == null)
                {
                    Console.WriteLine("The first shape does not have a line format.");
                    pres.Dispose();
                    Environment.Exit(1);
                }

                // Original dash style set on the shape
                Aspose.Slides.ILineFormat lineFormat = shape.LineFormat;
                Aspose.Slides.LineDashStyle originalDash = lineFormat.DashStyle;

                // Effective dash style after theme inheritance
                Aspose.Slides.ILineFormatEffectiveData effectiveLine = lineFormat.GetEffective();
                Aspose.Slides.LineDashStyle effectiveDash = effectiveLine.DashStyle;

                // Output the dash styles
                Console.WriteLine("Original Dash Style: " + originalDash);
                Console.WriteLine("Effective Dash Style after Theme: " + effectiveDash);

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The provided file format is not supported.");
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

// -----------------------------------------------------------------------------
// Example: Replace rectangle fill orange on title using C#
//
// Description:
// Demonstrates how to replace the fill color of rectangle AutoShapes on the
// title slide with orange using C# and Aspose.Slides for .NET. The example
// loads a presentation, iterates over shapes on the first slide, changes the
// fill of rectangle shapes to solid orange while preserving borders, and
// saves the result. This pattern can be used to automate PPTX color adjustments
// in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Rectangle, Fill,
// Orange, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate changing rectangle fill colors on title slides.
// - Build C# tools for PowerPoint presentation styling.
// - Generate or transform PPTX files in .NET applications.
// - Apply consistent branding colors across presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceRectangleColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Assume the title slide is the first slide (index 0)
                Aspose.Slides.ISlide titleSlide = presentation.Slides[0];

                // Iterate through all shapes on the title slide
                foreach (Aspose.Slides.IShape shape in titleSlide.Shapes)
                {
                    // Process only AutoShape rectangles
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                    {
                        // Set solid orange fill while preserving existing borders
                        autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        autoShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Orange;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

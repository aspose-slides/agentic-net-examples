// -----------------------------------------------------------------------------
// Example: Replace ellipse fills with red to PPTX using C#
//
// Description:
// Demonstrates how to replace the fill color of all ellipse shapes with red
// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The
// example loads an existing PPTX file, iterates through its slides and shapes,
// modifies ellipse fills, and saves the result as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Ellipse, Fill, Red,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate changing ellipse fill colors to red in PPTX files.
// - Build C# utilities for batch processing of PowerPoint presentations.
// - Integrate shape formatting logic into .NET applications.
// - Prepare presentations with consistent styling before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceEllipseFills
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Cast to AutoShape to access ShapeType property
                        AutoShape autoShape = shape as AutoShape;
                        if (autoShape != null && autoShape.ShapeType == ShapeType.Ellipse)
                        {
                            // Change fill to solid red
                            autoShape.FillFormat.FillType = FillType.Solid;
                            autoShape.FillFormat.SolidFillColor.Color = Color.Red;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}

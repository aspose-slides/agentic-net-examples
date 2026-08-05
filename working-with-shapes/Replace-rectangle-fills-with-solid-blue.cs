// -----------------------------------------------------------------------------
// Example: Replace rectangle fills with solid blue using C#
//
// Description:
// Demonstrates how to replace the fill color of rectangle AutoShape objects
// with a solid blue color using C# and Aspose.Slides for .NET. The example
// loads an existing PPTX file, iterates through all slides and shapes, updates
// each rectangle's FillFormat to a solid blue fill, and saves the modified
// presentation. This pattern can be used to automate color adjustments in
// PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Rectangle, Fill, Solid,
// Blue, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate changing rectangle fills to a specific color in bulk.
// - Build C# utilities for PowerPoint presentation styling.
// - Integrate color transformation steps into .NET workflows.
// - Ensure visual consistency across generated PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceRectangleFills
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Process only AutoShape objects (they have ShapeType property)
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != != null && autoShape.ShapeType == ShapeType.Rectangle)
                            {
                                // Set fill to solid blue
                                autoShape.FillFormat.FillType = FillType.Solid;
                                autoShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the format is not supported, comment accordingly
                // Format not supported.
            }
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Replace rectangle with rounded on even slides using C#
//
// Description:
// Demonstrates how to replace rectangle with rounded on even slides using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Rectangle, Rounded, 
// Even, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replace rectangle with rounded on even slides.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceRectangleWithRounded
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through slides (0‑based index)
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        // Process only even‑numbered slides (1‑based numbering)
                        if ((slideIndex + 1) % 2 == 0)
                        {
                            ISlide slide = presentation.Slides[slideIndex];
                            // Iterate through all shapes on the slide
                            foreach (IShape shape in slide.Shapes)
                            {
                                // Cast to IAutoShape to access ShapeType property
                                IAutoShape autoShape = shape as IAutoShape;
                                if (autoShape != null && autoShape.ShapeType == ShapeType.Rectangle)
                                {
                                    // Change rectangle to rounded rectangle while preserving fill
                                    autoShape.ShapeType = ShapeType.RoundCornerRectangle;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Replace rectangle fills with gray gradient using C#
//
// Description:
// Demonstrates how to replace rectangle fills with a gray gradient using C# and
// Aspose.Slides for .NET. The example loads a PowerPoint presentation, iterates
// through all slides and shapes, identifies rectangle auto-shapes, applies a
// linear gradient fill from light gray to dark gray, and saves the modified
// presentation. This pattern can be used to automate PPTX workflows, validate
// visual changes, or integrate presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Rectangle, Fills,
// Gray, Gradient, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of rectangle fills with a gray gradient.
// - Build C# utilities for PowerPoint presentation styling.
// - Generate or transform PPTX files programmatically in .NET.
// - Validate presentation visual consistency before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ReplaceRectangleFillsWithGrayGradient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Cast to IAutoShape to access ShapeType
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.ShapeType == ShapeType.Rectangle)
                        {
                            // Apply gradient fill (light gray to dark gray)
                            autoShape.FillFormat.FillType = FillType.Gradient;
                            autoShape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
                            autoShape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
                            autoShape.FillFormat.GradientFormat.GradientStops.Add(0, Color.LightGray);
                            autoShape.FillFormat.GradientFormat.GradientStops.Add(100, Color.DarkGray);
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., loading errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Set ellipse line width to 2pt using C#
//
// Description:
// Demonstrates how to set the line width of ellipse shapes to 2 points using
// C# and Aspose.Slides for .NET. The example loads an existing PPTX file,
// iterates through all slides and shapes, updates the line width of each
// ellipse, and saves the modified presentation. This pattern can be used to
// automate PowerPoint shape formatting tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Line, Width,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting ellipse line width to 2pt across a presentation.
// - Build C# tools for bulk shape formatting in PowerPoint files.
// - Generate or transform PPTX files with specific shape styling in .NET.
// - Validate and enforce presentation design standards before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetEllipseLineWidth
{
    class Program
    {
        static void Main()
        {
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate over all slides
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Iterate over all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Cast to IAutoShape to access ShapeType
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == ShapeType.Ellipse)
                            {
                                // Ensure the shape has a line format and set its width to 2 points
                                if (autoShape.LineFormat != null)
                                {
                                    autoShape.LineFormat.Width = 2f;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

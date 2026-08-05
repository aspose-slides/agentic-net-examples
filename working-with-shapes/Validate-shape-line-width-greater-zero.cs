// -----------------------------------------------------------------------------
// Example: Validate shape line width greater zero using C#
//
// Description:
// Demonstrates how to validate that each shape's line width is greater than zero
// using C# and Aspose.Slides for .NET. The example loads a presentation, checks
// all shapes on all slides, and sets a minimal positive line width where needed.
// It then saves the modified presentation. This pattern can be used to ensure
// visual consistency and compliance with design guidelines in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Shape, Line, Width,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure all shape outlines have a visible line width.
// - Automate validation of presentation design standards.
// - Prepare PPTX files for publishing where zero-width lines are not allowed.
// - Integrate shape validation into .NET PowerPoint processing tools.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output files
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and shapes to ensure line width > 0
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    if (shape.LineFormat != null)
                    {
                        if (shape.LineFormat.Width <= 0)
                        {
                            // Set a minimal positive line width
                            shape.LineFormat.Width = 0.5f;
                        }
                    }
                }
            }

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

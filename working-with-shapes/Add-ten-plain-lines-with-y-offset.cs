// -----------------------------------------------------------------------------
// Example: Add ten plain lines with y offset using C#
//
// Description:
// Demonstrates how to add ten plain lines with incremental Y offset to each
// slide in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads an existing presentation (or creates a new one), adds
// ten horizontal line shapes per slide with a vertical offset, and saves the
// result. This pattern can be used to automate drawing guides, separators, or
// custom layouts in PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Plain Lines, Y Offset,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Add multiple horizontal guide lines to slides programmatically.
// - Build C# tools for automated slide layout adjustments.
// - Generate or modify PPTX files with custom line graphics in .NET.
// - Automate visual formatting tasks before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Presentation pres = null;
        try
        {
            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Add ten plain line shapes to each slide with incremental Y offset
        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
        {
            ISlide slide = pres.Slides[slideIndex];
            for (int i = 0; i < 10; i++)
            {
                float yOffset = 50 + i * 20; // Incremental Y coordinate
                // Add a plain line shape
                IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, yOffset, 300, 0);
                // Set line width (optional)
                line.LineFormat.Width = 2;
            }
        }

        try
        {
            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors (e.g., unsupported format)
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            // Dispose the presentation
            pres.Dispose();
        }
    }
}

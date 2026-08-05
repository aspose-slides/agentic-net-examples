// -----------------------------------------------------------------------------
// Example: Detect inherited shape line color replace palette using C#
//
// Description:
// Demonstrates how to detect inherited line formatting of shapes on a slide,
// and replace the line color with a specific palette entry (Accent2) using
// Aspose.Slides for .NET. The example loads a PPTX file, processes the first
// slide, updates line colors where a visible line exists, and saves the
// result. This pattern can be used to standardize line colors across
// presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Inherited, Shape, Line,
// Palette, Presentation Processing, Office Automation
//
// Use Cases:
// - Detect and replace inherited shape line colors with a chosen palette entry.
// - Automate line style standardization in PowerPoint files.
// - Build .NET tools for batch processing of PPTX presentations.
// - Ensure visual consistency before publishing or integrating presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation with exception handling for unsupported formats
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through shapes on the first slide
        foreach (Aspose.Slides.IShape shape in presentation.Slides[0].Shapes)
        {
            // Get effective line formatting (includes inherited values)
            Aspose.Slides.ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

            // If the shape has a visible line (width > 0), replace its line color
            if (effectiveLine.Width > 0)
            {
                // Set line fill to solid and apply a custom palette entry (Accent2)
                shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent2;
            }
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}

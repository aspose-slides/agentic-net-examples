// -----------------------------------------------------------------------------
// Example: Get effective line color after custom scheme using C#
//
// Description:
// Demonstrates how to get the effective line color of a shape after applying a
// custom color scheme to the presentation using Aspose.Slides for .NET. The
// example loads a PPTX file, modifies the master theme line style, retrieves the
// effective line formatting of the first shape, outputs the resulting color, and
// saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Effective Line Color, Custom Scheme,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Retrieve effective line color after a custom theme is applied.
// - Build C# utilities for analyzing shape formatting in PowerPoint files.
// - Automate validation of line colors in presentation workflows.
// - Integrate line‑format extraction into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Apply a custom color scheme by changing the first line style to red
                try
                {
                    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
                }
                catch (Exception ex)
                {
                    // Handle cases where the format does not support this operation
                    Console.WriteLine("Failed to apply custom color scheme: " + ex.Message);
                }

                // Retrieve the first shape on the first slide
                IShape shape = pres.Slides[0].Shapes[0];

                // Get effective line formatting data
                ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

                // Extract the effective line color (solid fill)
                Color effectiveColor = Color.Empty;
                if (effectiveLine.FillFormat != null && effectiveLine.FillFormat.SolidFillColor != null)
                {
                    effectiveColor = effectiveLine.FillFormat.SolidFillColor;
                }

                Console.WriteLine("Effective line color: " + effectiveColor.ToString());

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Set default text direction left to right using C#
//
// Description:
// Demonstrates how to set the default text direction to left‑to‑right in a new
// presentation using C# and Aspose.Slides for .NET. The example creates a
// presentation, configures the default text language (which influences text
// direction), adds a slide with a rectangle containing left‑to‑right text, and
// saves the result as a PPTX file. This pattern can be used to automate
// presentation creation where text direction must be enforced.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Default Text Direction, Left to Right, Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure newly created presentations default to left‑to‑right text flow.
// - Build C# utilities for generating PowerPoint files with specific text direction.
// - Integrate text direction settings into automated PPTX generation pipelines.
// - Validate and enforce text direction consistency across presentation assets.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultTextLanguage = "en-US";

            using (var presentation = new Aspose.Slides.Presentation(loadOptions))
            {
                // Add a new slide based on the first slide's layout
                var layoutSlide = presentation.Slides[0].LayoutSlide;
                var newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

                // Add a rectangle shape with a text frame to demonstrate left‑to‑right direction
                var shape = newSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                shape.AddTextFrame("Sample left‑to‑right text");

                // Save the presentation
                presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
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

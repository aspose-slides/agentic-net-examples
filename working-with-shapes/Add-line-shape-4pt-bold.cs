// -----------------------------------------------------------------------------
// Example: Add line shape 4pt bold using C#
//
// Description:
// Demonstrates how to add a 4‑point bold line shape to a slide using C# and
// Aspose.Slides for .NET. The example creates a new presentation, inserts a line
// shape, sets its line width to 4 points and applies a thick‑thin style to make
// it appear bold, then saves the result as a PPTX file. This pattern can be used
// for automating line‑drawing tasks in PowerPoint files.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, line shape, 4pt, bold, line width,
// line style, presentation automation, .NET
//
// Use Cases:
// - Programmatically add bold lines to slides.
// - Build utilities that generate or modify PPTX files with specific line
//   formatting.
// - Integrate line‑drawing logic into larger .NET applications.
// - Validate line‑style settings in automated PowerPoint workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Set line weight to 4 points and make it appear bold
        lineShape.LineFormat.Width = 4;
        lineShape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;

        // Define output file path
        string outputPath = "LineBold.pptx";

        try
        {
            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}

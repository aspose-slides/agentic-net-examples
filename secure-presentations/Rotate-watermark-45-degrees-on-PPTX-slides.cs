// -----------------------------------------------------------------------------
// Example: Rotate watermark 45 degrees on PPTX slides using C#
//
// Description:
// Demonstrates how to rotate a text watermark 45 degrees on each slide of a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a presentation, iterates through its slides, adds a rectangular
// shape containing the word "CONFIDENTIAL", makes the shape transparent, rotates
// it 45 degrees, and sets the text color to gray. The resulting presentation
// is saved as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rotate, Watermark, Degrees,
// Pptx, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a 45‑degree rotated watermark to PPTX slides.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
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
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Iterate through all slides and add a rotated watermark
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];

            // Add a rectangular shape that will serve as the watermark
            Aspose.Slides.IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);
            watermarkShape.AddTextFrame("CONFIDENTIAL");

            // Make the shape transparent (no fill, no line)
            watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
            watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Rotate the shape 45 degrees for diagonal placement
            watermarkShape.Rotation = 45f;

            // Set the watermark text color
            watermarkShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            watermarkShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
        }

        // Save the presentation
        string outputPath = "WatermarkRotated.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}

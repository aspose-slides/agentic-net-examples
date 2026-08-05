// -----------------------------------------------------------------------------
// Example: Add line shape transparent color verify using C#
//
// Description:
// Demonstrates how to add a line shape with a fully transparent color using
// C# and Aspose.Slides for .NET. The example creates a new presentation,
// inserts a line shape, configures its line format to be solid with a
// transparent fill (resulting in an invisible border), and saves the file.
// This pattern can be used to automate PPTX workflows where invisible or
// placeholder lines are required.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Transparent,
// Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with transparent borders.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 400, 0);

        // Optional: set line style and width
        line.LineFormat.Style = Aspose.Slides.LineStyle.Single;
        line.LineFormat.Width = 2;

        // Set line fill to solid transparent color (no visible border)
        line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Transparent;

        // Save the presentation
        string outputPath = "TransparentLine.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}

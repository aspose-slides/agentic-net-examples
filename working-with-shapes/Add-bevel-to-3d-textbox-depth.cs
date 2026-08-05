// -----------------------------------------------------------------------------
// Example: Add bevel to 3D textbox depth using C#
//
// Description:
// Demonstrates how to add a bevel effect and set depth on a 3‑D text box shape 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// inserts an ellipse shape, formats its fill and line, adds text, applies a 
// bevel preset with specific height and width, adjusts the 3‑D depth, and saves 
// the result as a PPTX file. This pattern can be used to enhance visual 
// appearance of shapes in automated PowerPoint generation scenarios.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bevel, 3D, Textbox, Depth, 
// Shape Formatting, Presentation Automation
//
// Use Cases:
// - Add bevel effects to 3‑D text boxes in generated presentations.
// - Programmatically control 3‑D depth and bevel properties of shapes.
// - Build .NET tools that create or modify PPTX files with enhanced visual styles.
// - Automate styling of shapes for consistent branding across slides.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add an ellipse shape to act as a 3‑D text box
        var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 400, 200);

        // Set fill and line formatting
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
        shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        shape.LineFormat.Width = 2.0;

        // Add text to the shape
        shape.AddTextFrame("3D Bevel Text");
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 48;

        // Apply bevel effect and adjust depth for realism
        shape.ThreeDFormat.Depth = 30;
        shape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
        shape.ThreeDFormat.BevelTop.Height = 5;
        shape.ThreeDFormat.BevelTop.Width = 5;

        // Save the presentation
        presentation.Save("Bevel3DTextBox.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}

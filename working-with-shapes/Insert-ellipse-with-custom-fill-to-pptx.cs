// -----------------------------------------------------------------------------
// Example: Insert ellipse with custom fill to pptx using C#
//
// Description:
// Demonstrates how to insert an ellipse shape with a custom solid fill color
// and a solid outline into a PowerPoint presentation using C# and Aspose.Slides
// for .NET. The example creates a new presentation, adds an ellipse with a
// chocolate fill and black border, and saves the result as a PPTX file.
// This pattern can be used to automate shape creation and styling in PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Ellipse, Custom Fill,
// Solid Fill, Shape Styling, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of ellipses with custom fill and outline into PPTX files.
// - Build .NET tools for generating styled shapes in PowerPoint presentations.
// - Create templates or batch-process slides with specific shape formatting.
// - Validate shape rendering and styling in automated PPTX workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "EllipsePresentation.pptx";
            try
            {
                Presentation presentation = new Presentation();
                ISlide slide = presentation.Slides[0];
                IShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.Chocolate;
                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                shape.LineFormat.Width = 2.0;
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions
            }
        }
    }
}

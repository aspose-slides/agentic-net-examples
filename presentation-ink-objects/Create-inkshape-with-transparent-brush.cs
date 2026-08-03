// -----------------------------------------------------------------------------
// Example: Create inkshape with transparent brush using C#
//
// Description:
// Demonstrates how to create a line shape that simulates an ink stroke with a
// transparent brush using C# and Aspose.Slides for .NET. The example shows the
// required presentation-processing steps for PowerPoint files, applying a
// scribble sketch effect and setting the line color to transparent to mimic an
// erasing effect. The resulting presentation is saved as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Inkshape, Transparent Brush,
// Line Shape, Sketch Effect, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of ink-like shapes with transparent styling.
// - Build C# tools for PowerPoint presentation processing that require
//   simulated erasing effects.
// - Generate or transform PPTX files in .NET applications with custom ink
//   visuals.
// - Validate presentation workflows involving transparent drawing elements.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line shape to simulate an ink stroke
                Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

                // Apply a scribble sketch effect to make it look like freehand ink
                lineShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

                // Set the line color to transparent to simulate erasing
                lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Transparent;

                // Optionally set the line width
                lineShape.LineFormat.Width = 5;

                // Save the presentation
                presentation.Save("InkEraseSimulation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

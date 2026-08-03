// -----------------------------------------------------------------------------
// Example: Generate diagonal ink trace with incremental offsets using C#
//
// Description:
// Demonstrates how to generate a series of diagonal points with incremental 
// offsets and how to prepare an Ink shape for such a trace using Aspose.Slides 
// for .NET. The example loads or creates a presentation, configures a line 
// shape to use a scribble sketch style, iterates to calculate diagonal points, 
// and saves the resulting presentation. Developers can extend this pattern to 
// create actual InkTrace objects for ink annotations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, Diagonal, Ink, 
// Trace, Incremental, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of diagonal ink traces with incremental offsets.
// - Build C# tools for PowerPoint presentation processing and ink annotation.
// - Generate or transform PPTX files with custom ink shapes in .NET applications.
// - Validate presentation workflows involving ink objects before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        Presentation presentation;

        // Load existing presentation if it exists, otherwise create a new one
        if (File.Exists(inputPath))
        {
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }
        }
        else
        {
            presentation = new Presentation();
        }

        ISlide slide = presentation.Slides[0];

        // Add a line shape and configure it to look like ink (scribble)
        IShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50, 0, 0);
        lineShape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Example of handling an Ink shape (if present)
        if (lineShape is Ink inkShape)
        {
            IInk ink = inkShape as IInk;
            IInkTrace[] traces = ink.Traces;
            // Traces are read‑only; this block demonstrates access only
        }

        // Generate diagonal points with incremental offsets (illustrative)
        int pointCount = 10;
        float startX = 50f;
        float startY = 50f;
        float offset = 10f;

        for (int i = 0; i < pointCount; i++)
        {
            float x = startX + i * offset;
            float y = startY + i * offset;
            Console.WriteLine($"Point {i}: ({x}, {y})");
            // In a full implementation, these points would be added to an InkTrace
        }

        // Save the presentation before exiting
        try
        {
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}

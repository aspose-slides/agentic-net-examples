// -----------------------------------------------------------------------------
// Example: Add inkshape trace to collection using C#
//
// Description:
// Demonstrates how to add an ink shape trace to a collection using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation‑processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ink shape, Trace, Collection, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding ink shape traces to a slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add an Ink shape to the slide
                IInkShape inkShape = slide.Shapes.AddInkShape(50f, 150f, 300f, 200f);

                // Create points for a new trace
                PointF[] newPoints = new PointF[]
                {
                    new PointF(0f, 0f),
                    new PointF(100f, 100f),
                    new PointF(200f, 50f)
                };

                // Create a brush for the trace (black color, 2 pt width)
                IInkBrush brush = new InkBrush(Color.Black, 2f);

                // Create a new ink trace using the points and brush
                IInkTrace newTrace = new InkTrace(newPoints, brush);

                // Add the trace to the Ink shape's trace collection
                inkShape.Traces.Add(newTrace);

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web service errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

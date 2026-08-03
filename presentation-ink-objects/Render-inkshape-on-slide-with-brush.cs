// -----------------------------------------------------------------------------
// Example: Render inkshape on slide with brush using C#
//
// Description:
// Demonstrates how to access an Ink shape on a slide, modify its brush
// properties (size and color), and save the updated presentation using
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// customize ink annotations, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Inkshape, Brush, Presentation Processing, Office Automation
//
// Use Cases:
// - Modify brush attributes of ink shapes in existing presentations.
// - Build C# tools for customizing ink annotations in PowerPoint files.
// - Generate or transform PPTX files with specific ink styling in .NET applications.
// - Validate and automate presentation workflows involving ink objects.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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
                // Assume the first shape is an Ink shape
                Aspose.Slides.Ink.Ink inkShape = pres.Slides[0].Shapes[0] as Aspose.Slides.Ink.Ink;
                if (inkShape != null && inkShape.Traces.Length > 0)
                {
                    Aspose.Slides.Ink.IInkBrush brush = inkShape.Traces[0].Brush;
                    // Configure brush size and color
                    brush.Size = new SizeF(5f, 10f);
                    brush.Color = Color.Red;
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URL errors)
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Rotate inkshape trace by ninety degrees using C#
//
// Description:
// Demonstrates how to rotate an InkShape's trace by ninety degrees clockwise 
// using C# and Aspose.Slides for .NET. The example loads a PPTX file, accesses 
// the first ink shape on the first slide, rotates each point in its ink traces, 
// and saves the modified presentation. This pattern can be used to automate 
// PowerPoint ink manipulation tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rotate, Inkshape, Trace, 
// Ninety, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate rotation of inkshape traces by ninety degrees.
// - Build C# tools for processing InkShape objects in PowerPoint files.
// - Generate or transform PPTX files with custom ink modifications.
// - Validate and test ink-related presentation workflows before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
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
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Ensure there is at least one slide and one shape
                if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
                {
                    IShape shape = presentation.Slides[0].Shapes[0];
                    IInk ink = shape as IInk;

                    if (ink != null)
                    {
                        // Iterate through each trace in the ink object
                        IInkTrace[] traces = ink.Traces;
                        foreach (IInkTrace trace in traces)
                        {
                            // Cast to concrete InkTrace to access mutable Points array
                            InkTrace inkTrace = trace as InkTrace;
                            if (inkTrace != null)
                            {
                                PointF[] points = inkTrace.Points;
                                for (int i = 0; i < points.Length; i++)
                                {
                                    float x = points[i].X;
                                    float y = points[i].Y;

                                    // Rotate 90 degrees clockwise: (x', y') = (y, -x)
                                    points[i] = new PointF(y, -x);
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

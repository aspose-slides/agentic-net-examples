// -----------------------------------------------------------------------------
// Example: Read and display Ink trace points using C#
//
// Description:
// Demonstrates how to read Ink traces from a shape in a PowerPoint presentation
// using Aspose.Slides for .NET, enumerate the sequential X and Y points of each
// trace, and output them to the console. The example shows the required
// presentation-processing steps for PowerPoint files and saves the presentation
// unchanged.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ink, InkTrace, Trace Points,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Extract and analyze Ink trace data from PPTX files.
// - Build C# tools for inspecting Ink annotations in presentations.
// - Automate validation of Ink content in PowerPoint slides.
// - Integrate Ink trace processing into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;
using System.Drawing;

namespace InkTraceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Get first slide
                ISlide slide = presentation.Slides[0];

                // Assume the first shape is an Ink shape
                IShape shape = slide.Shapes[0];
                IInk ink = shape as IInk;

                if (ink != null)
                {
                    // Get all traces
                    IInkTrace[] traces = ink.Traces;

                    // Display each trace's points (example: (0,0), (10,10), (20,20), ...)
                    for (int t = 0; t < traces.Length; t++)
                    {
                        PointF[] points = traces[t].Points;
                        Console.WriteLine($"Trace {t} has {points.Length} points:");
                        for (int i = 0; i < points.Length; i++)
                        {
                            Console.WriteLine($"Point {i}: X={points[i].X}, Y={points[i].Y}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The first shape is not an Ink shape.");
                }

                // Save presentation before exit
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"Error: {ex.Message}");
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}

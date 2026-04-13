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

                    // Populate each trace with sequential points (example: (0,0), (10,10), (20,20), ...)
                    for (int t = 0; t < traces.Length; t++)
                    {
                        // Since Points property is read‑only, we cannot modify existing points.
                        // In a real scenario, you would create new InkTrace objects with desired points.
                        // Here we just display existing points.
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
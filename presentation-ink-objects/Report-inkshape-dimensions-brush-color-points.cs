using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace InkReportApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load presentation. " + ex.Message);
                return;
            }

            try
            {
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];
                    Console.WriteLine($"Slide {slideIndex + 1}:");

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];
                        if (shape is Ink inkShape)
                        {
                            Console.WriteLine($"  Ink Shape {shapeIndex + 1}:");
                            Console.WriteLine($"    Position: X={inkShape.X}, Y={inkShape.Y}");
                            Console.WriteLine($"    Size: Width={inkShape.Width}, Height={inkShape.Height}");

                            IInkTrace[] traces = inkShape.Traces;
                            Console.WriteLine($"    Traces Count: {traces.Length}");

                            for (int traceIndex = 0; traceIndex < traces.Length; traceIndex++)
                            {
                                IInkTrace trace = traces[traceIndex];
                                IInkBrush brush = trace.Brush;
                                Color brushColor = brush.Color;
                                int pointCount = trace.Points.Length;

                                Console.WriteLine($"      Trace {traceIndex + 1}:");
                                Console.WriteLine($"        Brush Color: {brushColor}");
                                Console.WriteLine($"        Points Count: {pointCount}");
                            }
                        }
                    }
                }

                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing the presentation. " + ex.Message);
            }
            finally
            {
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}
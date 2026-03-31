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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    IBaseSlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Cast shape to Ink if possible
                        Ink inkShape = shape as Ink;
                        if (inkShape != null)
                        {
                            IInkTrace[] traces = inkShape.Traces;

                            // Iterate through each trace
                            for (int traceIdx = 0; traceIdx < traces.Length; traceIdx++)
                            {
                                IInkTrace trace = traces[traceIdx];
                                PointF[] points = trace.Points;

                                // Detect duplicate points within the trace
                                for (int i = 0; i < points.Length; i++)
                                {
                                    for (int j = i + 1; j < points.Length; j++)
                                    {
                                        if (points[i].Equals(points[j]))
                                        {
                                            Console.WriteLine($"Duplicate point found in slide {slideIndex}, shape {shapeIndex} (Ink), trace {traceIdx}: ({points[i].X}, {points[i].Y})");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the (potentially unchanged) presentation before exit
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine($"Error processing presentation: {ex.Message}");
        }
    }
}
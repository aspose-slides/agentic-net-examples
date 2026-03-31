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
        string csvPath = "ink_traces.csv";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                using (StreamWriter writer = new StreamWriter(csvPath))
                {
                    // CSV header
                    writer.WriteLine("SlideIndex,ShapeIndex,TraceIndex,PointIndex,X,Y");

                    for (int slideIdx = 0; slideIdx < pres.Slides.Count; slideIdx++)
                    {
                        ISlide slide = pres.Slides[slideIdx];
                        for (int shapeIdx = 0; shapeIdx < slide.Shapes.Count; shapeIdx++)
                        {
                            IShape shape = slide.Shapes[shapeIdx];
                            // Cast to Ink shape
                            Ink inkShape = shape as Ink;
                            if (inkShape != null)
                            {
                                IInkTrace[] traces = inkShape.Traces;
                                for (int traceIdx = 0; traceIdx < traces.Length; traceIdx++)
                                {
                                    IInkTrace trace = traces[traceIdx];
                                    System.Drawing.PointF[] points = trace.Points;
                                    for (int pointIdx = 0; pointIdx < points.Length; pointIdx++)
                                    {
                                        System.Drawing.PointF pt = points[pointIdx];
                                        writer.WriteLine($"{slideIdx},{shapeIdx},{traceIdx},{pointIdx},{pt.X},{pt.Y}");
                                    }
                                }
                            }
                        }
                    }
                }

                // Save presentation before exit (no modifications made)
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (PptUnsupportedFormatException)
        {
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
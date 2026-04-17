using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputCsvPath = "ink_traces.csv";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Find the first Ink shape in the presentation
            Aspose.Slides.Ink.Ink inkShape = null;
            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    inkShape = shape as Aspose.Slides.Ink.Ink;
                    if (inkShape != null)
                    {
                        break;
                    }
                }
                if (inkShape != null)
                {
                    break;
                }
            }

            if (inkShape == null)
            {
                Console.WriteLine("No Ink shape found in the presentation.");
                // Save the presentation before exiting as required
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
                return;
            }

            // Retrieve all traces from the Ink shape
            IInkTrace[] traces = inkShape.Traces;

            // Write trace data to CSV
            using (StreamWriter writer = new StreamWriter(outputCsvPath))
            {
                // CSV header
                writer.WriteLine("TraceIndex,PointIndex,X,Y");

                for (int traceIndex = 0; traceIndex < traces.Length; traceIndex++)
                {
                    PointF[] points = traces[traceIndex].Points;
                    for (int pointIndex = 0; pointIndex < points.Length; pointIndex++)
                    {
                        PointF pt = points[pointIndex];
                        writer.WriteLine($"{traceIndex},{pointIndex},{pt.X},{pt.Y}");
                    }
                }
            }

            Console.WriteLine("Ink trace data exported to CSV: " + outputCsvPath);

            // Save the presentation before exit
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
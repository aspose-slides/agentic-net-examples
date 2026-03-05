using System;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Attempt to cast the first shape on the first slide to an Ink shape
            Aspose.Slides.Ink.Ink inkShape = pres.Slides[0].Shapes[0] as Aspose.Slides.Ink.Ink;
            if (inkShape != null)
            {
                // Retrieve all ink traces
                Aspose.Slides.Ink.IInkTrace[] traces = inkShape.Traces;

                // Iterate through each trace and output the number of points it contains
                for (int i = 0; i < traces.Length; i++)
                {
                    Aspose.Slides.Ink.IInkTrace trace = traces[i];
                    PointF[] points = trace.Points;
                    Console.WriteLine($"Trace {i} contains {points.Length} points.");
                }
            }

            // Save the presentation in PPTX format
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}
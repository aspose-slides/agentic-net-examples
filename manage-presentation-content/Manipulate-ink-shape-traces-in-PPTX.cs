using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first shape on the first slide
                Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];
                Aspose.Slides.Ink.IInk ink = shape as Aspose.Slides.Ink.IInk;

                if (ink != null)
                {
                    // Retrieve all ink traces
                    Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;
                    Console.WriteLine("Number of ink traces: " + traces.Length);

                    for (int i = 0; i < traces.Length; i++)
                    {
                        Aspose.Slides.Ink.IInkTrace trace = traces[i];
                        System.Drawing.PointF[] points = trace.Points;
                        Console.WriteLine("Trace " + i + " points count: " + points.Length);
                    }
                }
                else
                {
                    Console.WriteLine("No ink shape found on the first slide.");
                }

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
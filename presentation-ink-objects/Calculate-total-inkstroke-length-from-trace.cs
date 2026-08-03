// -----------------------------------------------------------------------------
// Example: Calculate total inkstroke length from trace using C#
//
// Description:
// Demonstrates how to calculate the total length of ink strokes from ink
// traces in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, iterates through all ink shapes, sums the
// distances between consecutive points in each trace, outputs the total
// length, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ink, Inkstroke, Length,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate calculation of total inkstroke length from ink traces.
// - Build C# tools for analyzing handwritten annotations in PPTX files.
// - Generate reports on ink usage within presentations.
// - Validate ink content before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                double totalLength = 0.0;

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Cast shape to Ink type
                        Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;
                        if (inkShape != null)
                        {
                            // Get all traces of the ink shape
                            Aspose.Slides.Ink.IInkTrace[] traces = inkShape.Traces;
                            if (traces != null)
                            {
                                // Process each trace
                                foreach (Aspose.Slides.Ink.IInkTrace trace in traces)
                                {
                                    System.Drawing.PointF[] points = trace.Points;
                                    if (points != null && points.Length > 1)
                                    {
                                        // Sum distances between consecutive points
                                        for (int p = 1; p < points.Length; p++)
                                        {
                                            float dx = points[p].X - points[p - 1].X;
                                            float dy = points[p].Y - points[p - 1].Y;
                                            totalLength += Math.Sqrt(dx * dx + dy * dy);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Total ink stroke length: " + totalLength);

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("File format not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

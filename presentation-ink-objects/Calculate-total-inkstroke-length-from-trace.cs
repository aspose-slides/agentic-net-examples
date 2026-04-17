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
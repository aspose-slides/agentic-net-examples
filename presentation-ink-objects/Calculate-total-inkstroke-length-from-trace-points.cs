using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace InkLengthCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            double totalLength = 0.0;

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape is an Ink object
                    Aspose.Slides.Ink.Ink ink = shape as Aspose.Slides.Ink.Ink;
                    if (ink != null)
                    {
                        Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;

                        // Process each trace
                        for (int traceIndex = 0; traceIndex < traces.Length; traceIndex++)
                        {
                            Aspose.Slides.Ink.IInkTrace trace = traces[traceIndex];
                            PointF[] points = trace.Points;

                            // Sum distances between consecutive points
                            for (int i = 1; i < points.Length; i++)
                            {
                                float dx = points[i].X - points[i - 1].X;
                                float dy = points[i].Y - points[i - 1].Y;
                                double segmentLength = Math.Sqrt(dx * dx + dy * dy);
                                totalLength += segmentLength;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Total ink length: " + totalLength);

            // Save the presentation before exiting
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}
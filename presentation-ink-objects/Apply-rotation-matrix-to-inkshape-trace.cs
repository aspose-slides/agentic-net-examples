using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;
using System.Drawing;

namespace ApplyInkRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Assume the first shape on the first slide is an Ink shape
                    if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
                    {
                        // Cast the shape to Ink
                        Ink inkShape = presentation.Slides[0].Shapes[0] as Ink;
                        if (inkShape != null)
                        {
                            // Access the IInk interface
                            IInk ink = inkShape as IInk;
                            if (ink != null)
                            {
                                // Iterate through each trace
                                IInkTrace[] traces = ink.Traces;
                                foreach (IInkTrace trace in traces)
                                {
                                    // Get mutable array of points
                                    PointF[] points = trace.Points;
                                    for (int i = 0; i < points.Length; i++)
                                    {
                                        float originalX = points[i].X;
                                        float originalY = points[i].Y;

                                        // Rotate 90 degrees clockwise: (x, y) -> (y, -x)
                                        float rotatedX = originalY;
                                        float rotatedY = -originalX;

                                        points[i].X = rotatedX;
                                        points[i].Y = rotatedY;
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
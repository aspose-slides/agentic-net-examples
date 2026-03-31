using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace PresentationInkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Attempt to get the first shape as an Ink object
                    Ink inkShape = pres.Slides[0].Shapes[0] as Ink;
                    if (inkShape == null)
                    {
                        Console.WriteLine("The first shape is not an Ink object.");
                        return;
                    }

                    // Get the existing traces
                    IInkTrace[] traces = inkShape.Traces;
                    if (traces.Length == 0)
                    {
                        Console.WriteLine("No ink traces found.");
                        return;
                    }

                    // Retrieve points from the first trace
                    System.Drawing.PointF[] existingPoints = traces[0].Points;

                    // Create a new array with additional points
                    System.Drawing.PointF[] extendedPoints = new System.Drawing.PointF[existingPoints.Length + 1];
                    Array.Copy(existingPoints, extendedPoints, existingPoints.Length);
                    extendedPoints[existingPoints.Length] = new System.Drawing.PointF(200f, 200f); // new point to append

                    // NOTE: The Points property is read‑only; to truly extend the stroke you would need to create a new InkTrace
                    // with the combined points and replace the existing trace. This example demonstrates how to prepare the data.

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // TODO: handle unsupported format
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network errors if a URL was used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
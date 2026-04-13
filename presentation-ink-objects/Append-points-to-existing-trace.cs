using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace AppendInkPoints
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Assume the first shape on the first slide is an Ink object
                    IInk inkShape = presentation.Slides[0].Shapes[0] as IInk;
                    if (inkShape == null)
                    {
                        Console.WriteLine("The first shape is not an Ink object.");
                        return;
                    }

                    // Get the first trace
                    IInkTrace[] traces = inkShape.Traces;
                    if (traces == null || traces.Length == 0)
                    {
                        Console.WriteLine("No ink traces found.");
                        return;
                    }

                    IInkTrace firstTrace = traces[0];

                    // Retrieve existing points
                    System.Drawing.PointF[] existingPoints = firstTrace.Points;

                    // Create new points to append
                    System.Drawing.PointF[] newPoints = new System.Drawing.PointF[]
                    {
                        new System.Drawing.PointF(100f, 100f),
                        new System.Drawing.PointF(150f, 150f)
                    };

                    // Combine existing points with new points (cannot modify read‑only property directly)
                    System.Drawing.PointF[] combinedPoints = new System.Drawing.PointF[existingPoints.Length + newPoints.Length];
                    Array.Copy(existingPoints, combinedPoints, existingPoints.Length);
                    Array.Copy(newPoints, 0, combinedPoints, existingPoints.Length, newPoints.Length);

                    // Note: The Points property is read‑only; to persist changes you would need to recreate the trace.
                    // This example demonstrates how to prepare the combined points array.

                    // Save the presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
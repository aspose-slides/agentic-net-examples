using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace PresentationInkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "CircularInk.pptx";

            // Ensure the output file does not already exist
            if (File.Exists(outputPath))
            {
                try
                {
                    File.Delete(outputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to delete existing file: " + ex.Message);
                    return;
                }
            }

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a placeholder line shape (Ink cannot be added directly via ShapeType)
                    IShape placeholderShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 0, 0);

                    // Cast the placeholder to an Ink object
                    Ink inkShape = placeholderShape as Ink;

                    if (inkShape != null)
                    {
                        // Parameters for the circular ink pattern
                        int pointCount = 120;
                        float radius = 80f;
                        float centerX = 300f;
                        float centerY = 300f;

                        // Create an array to hold the points of the circle
                        PointF[] circlePoints = new PointF[pointCount];

                        for (int i = 0; i < pointCount; i++)
                        {
                            double angle = 2 * Math.PI * i / pointCount;
                            float x = centerX + radius * (float)Math.Cos(angle);
                            float y = centerY + radius * (float)Math.Sin(angle);
                            circlePoints[i] = new PointF(x, y);
                        }

                        // NOTE: The Traces collection is read‑only. In a full implementation,
                        // you would create a new InkTrace with the calculated points and
                        // add it to the Ink object via the appropriate API (if available).
                        // Here we simply demonstrate the point calculation.
                    }

                    // Save the presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., unsupported format, I/O issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
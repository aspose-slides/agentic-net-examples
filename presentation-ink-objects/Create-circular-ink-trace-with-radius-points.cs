using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InkPatternExample
{
    class Program
    {
        static void Main()
        {
            // Define output directory and file
            string outputDir = "Output";
            string outputFile = Path.Combine(outputDir, "CircularInkPattern.pptx");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Add a rectangle shape as a placeholder (optional)
                ISlide slide = pres.Slides[0];
                IAutoShape rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 200);

                // Calculate points on a circle
                var centerX = 200f;
                var centerY = 200f;
                var radius = 100f;
                var points = new List<PointF>();
                for (int angle = 0; angle < 360; angle += 30)
                {
                    var rad = (float)(angle * Math.PI / 180);
                    var x = centerX + radius * (float)Math.Cos(rad);
                    var y = centerY + radius * (float)Math.Sin(rad);
                    points.Add(new PointF(x, y));
                }

                // The points array can be used to create an InkTrace.
                // Example (conceptual):
                // InkTrace trace = new InkTrace();
                // trace.Points = points.ToArray(); // Not directly settable; this is illustrative.

                // Save the presentation
                pres.Save(outputFile, SaveFormat.Pptx);
            }
            catch (Exception ex) when (ex is NotSupportedException)
            {
                // Format not supported
                // Handle accordingly
            }
        }
    }
}
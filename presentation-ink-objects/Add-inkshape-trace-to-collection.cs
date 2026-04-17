using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a line shape to act as an ink placeholder (direct Ink addition is not supported)
                IAutoShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 150f, 300f, 0f);
                lineShape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

                // Attempt to cast the shape to Ink (will be null for a Line shape)
                Ink inkShape = lineShape as Ink;
                if (inkShape != null)
                {
                    // Retrieve existing traces (read‑only)
                    IInkTrace[] existingTraces = inkShape.Traces;

                    // Create points for a new trace
                    PointF[] newPoints = new PointF[]
                    {
                        new PointF(0f, 0f),
                        new PointF(100f, 100f)
                    };

                    // Create a new brush using an existing trace's brush (InkBrush has no public constructor)
                    IInkBrush existingBrush = existingTraces.Length > 0 ? existingTraces[0].Brush : null;
                    if (existingBrush != null)
                    {
                        // NOTE: The Ink API does not provide a method to add a new trace directly.
                        // The Traces collection is read‑only, so adding a trace is not possible via public API.
                        // This placeholder demonstrates how one would obtain the necessary objects if such a method existed.
                        // Example (hypothetical):
                        // InkTrace newTrace = new InkTrace(newPoints, existingBrush);
                        // inkShape.AddTrace(newTrace);
                    }
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web service errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
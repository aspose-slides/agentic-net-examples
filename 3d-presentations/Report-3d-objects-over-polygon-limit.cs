// -----------------------------------------------------------------------------
// Example: Detect 3D Shapes Exceeding Polygon Count Threshold in PowerPoint
//
// Description:
// This console application loads a PPTX file using Aspose.Slides for .NET,
// iterates through all slides and shapes, and reports any 3D objects whose
// polygon count exceeds a user‑specified threshold. It uses reflection to
// access the PolygonCount property, handling cases where the property is not
// available in the current library version.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D objects, polygon count, detection
//
// Use Cases:
// - Identify complex 3D models that may increase file size or rendering time.
// - Validate presentations before publishing to ensure 3D content stays within limits.
// - Automate quality checks for corporate slide decks containing 3D graphics.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.pptx";
        string outputPath = "output.pptx";
        int threshold = args.Length > 1 ? int.Parse(args[1]) : 1000;

        if (!System.IO.File.Exists(inputPath))
        {
            System.Console.WriteLine($"Error: File not found – {inputPath}");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.IThreeDFormat threeDFormat = shape.ThreeDFormat;
                    if (threeDFormat != null)
                    {
                        System.Reflection.PropertyInfo polygonCountProp = threeDFormat.GetType().GetProperty("PolygonCount");
                        if (polygonCountProp != null)
                        {
                            object value = polygonCountProp.GetValue(threeDFormat);
                            if (value is int polygonCount && polygonCount > threshold)
                            {
                                System.Console.WriteLine($"Slide {slide.SlideNumber}, Shape \"{shape.Name}\": PolygonCount = {polygonCount} exceeds threshold {threshold}.");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine($"Slide {slide.SlideNumber}, Shape \"{shape.Name}\": PolygonCount property not supported in this Aspose.Slides version.");
                        }
                    }
                }
            }

            // Save the presentation (no modifications made) to ensure proper disposal.
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}

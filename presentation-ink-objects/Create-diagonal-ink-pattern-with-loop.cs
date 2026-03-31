using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define starting point and offset
        float startX = 50f;
        float startY = 50f;
        float endX = 300f;
        float endY = 300f;
        float offset = 10f;

        // Add multiple line shapes with incremental offsets to create diagonal pattern
        for (int i = 0; i < 10; i++)
        {
            // Add a line shape
            Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Line,
                startX + i * offset,
                startY + i * offset,
                endX + i * offset,
                endY + i * offset);

            // Apply scribble sketch effect
            lineShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;
        }

        // Define output file path
        string outPath = "DiagonalInkPattern_out.pptx";

        try
        {
            // Save the presentation
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., I/O errors)
        }
        finally
        {
            // Dispose presentation
            pres.Dispose();
        }
    }
}
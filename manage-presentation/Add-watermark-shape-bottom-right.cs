using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            // Create a new presentation if the input file does not exist
            using (var pres = new Presentation())
            {
                AddWatermarkToAllSlides(pres);
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            return;
        }

        try
        {
            using (var pres = new Presentation(inputPath))
            {
                AddWatermarkToAllSlides(pres);
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format exception
            // Format not supported: ex.Message
        }
    }

    static void AddWatermarkToAllSlides(Presentation pres)
    {
        foreach (var slide in pres.Slides)
        {
            // Determine bottom‑right position with a small margin
            var slideSize = pres.SlideSize.Size;
            float shapeWidth = 150f;
            float shapeHeight = 50f;
            float margin = 10f;
            float x = slideSize.Width - shapeWidth - margin;
            float y = slideSize.Height - shapeHeight - margin;

            var watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, shapeWidth, shapeHeight);
            watermarkShape.AddTextFrame("Watermark");
            watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;
            watermarkShape.FillFormat.FillType = FillType.NoFill;
            watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
        }
    }
}
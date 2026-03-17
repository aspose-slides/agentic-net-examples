using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "InkShape.pptx";

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a rectangle shape that will act as an ink container
            Aspose.Slides.IAutoShape inkShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100f,
                100f,
                300f,
                200f);

            // Remove fill so only the ink line is visible
            inkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Set the line to a scribble (ink-like) style
            inkShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;
            inkShape.LineFormat.Width = 2f;
            inkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            inkShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
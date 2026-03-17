using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlideCollection slides = presentation.Slides;

            for (int i = 0; i < slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = slides[i];
                Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                for (int j = 0; j < shapes.Count; j++)
                {
                    Aspose.Slides.IShape shape = shapes[j];
                    shape.ThreeDFormat.Depth = 5.0;
                    shape.ThreeDFormat.ExtrusionHeight = 10.0;
                    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
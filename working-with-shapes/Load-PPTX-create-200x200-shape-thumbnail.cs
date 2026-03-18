using System;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPptx = "input.pptx";
            string outputPng = "shape_thumbnail.png";
            string outputPptx = "output.pptx";

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPptx))
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IShape shape = slide.Shapes[0];

                float scaleX = 200f / shape.Width;
                float scaleY = 200f / shape.Height;

                using (Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY))
                {
                    shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);
                }

                pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
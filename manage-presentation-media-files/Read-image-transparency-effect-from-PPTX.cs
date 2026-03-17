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
            using (Presentation presentation = new Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];
                        if (shape is IPictureFrame)
                        {
                            IPictureFrame picture = (IPictureFrame)shape;
                            Color fillColor = picture.FillFormat.SolidFillColor.Color;
                            float transparency = 1f - (fillColor.A / 255f);
                            Console.WriteLine($"Slide {slideIndex + 1}, Picture {shapeIndex + 1} transparency: {transparency}");
                        }
                    }
                }

                // Save the presentation (unchanged) before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
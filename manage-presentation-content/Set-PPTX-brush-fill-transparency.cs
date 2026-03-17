using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetBrushFillTransparency
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a rectangle shape
                Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

                // Set fill type to solid
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                // Set fill color with transparency (alpha = 128 out of 255 ~ 50% transparent)
                shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, System.Drawing.Color.Blue);

                // Save the presentation
                pres.Save("BrushFillTransparency.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
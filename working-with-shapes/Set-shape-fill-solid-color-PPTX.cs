using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Presentation presentation = new Presentation();
                ISlide slide = presentation.Slides[0];
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
                presentation.Save("SolidFillExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
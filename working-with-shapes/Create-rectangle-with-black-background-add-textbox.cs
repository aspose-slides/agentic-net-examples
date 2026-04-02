using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
                rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                rectangle.FillFormat.SolidFillColor.Color = Color.Black;
                rectangle.AddTextFrame("Sample Text");
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
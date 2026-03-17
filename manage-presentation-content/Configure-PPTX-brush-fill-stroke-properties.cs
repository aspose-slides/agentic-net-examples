using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BrushAttributesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape
                IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

                // Configure fill (solid accent color)
                rectangle.FillFormat.FillType = FillType.Solid;
                rectangle.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

                // Configure stroke (solid line with a different accent color)
                rectangle.LineFormat.FillFormat.FillType = FillType.Solid;
                rectangle.LineFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;

                // Save the presentation
                presentation.Save("BrushAttributes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentation = new Aspose.Slides.Presentation();

                // Add a blank slide
                var slide = presentation.Slides[0];

                // Add an ellipse shape
                var ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 150);

                // Apply line formatting
                ellipse.LineFormat.Width = 5;
                ellipse.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                ellipse.LineFormat.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;
                ellipse.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

                // Save the presentation
                presentation.Save("EllipseLineFormat.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
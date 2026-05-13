using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "EllipsePresentation.pptx";
            try
            {
                Presentation presentation = new Presentation();
                ISlide slide = presentation.Slides[0];
                IShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.Chocolate;
                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                shape.LineFormat.Width = 2.0;
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions
            }
        }
    }
}
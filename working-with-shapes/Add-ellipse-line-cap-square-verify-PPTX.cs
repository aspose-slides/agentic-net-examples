using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add an ellipse shape
                IShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);

                // Set solid fill color for the ellipse
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.Chocolate;

                // Set solid line color and width
                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                shape.LineFormat.Width = 5;

                // Set line cap style to Square
                shape.LineFormat.CapStyle = LineCapStyle.Square;

                // Save the presentation
                pres.Save("EllipseCapSquare.pptx", SaveFormat.Pptx);
                // The line cap style is set to Square; rendering will show square ends on the ellipse border.
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
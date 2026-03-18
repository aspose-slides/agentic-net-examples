using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an ellipse shape with specified position and size
            Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse, // Shape type
                100, // X position (points)
                100, // Y position (points)
                200, // Width (points)
                150  // Height (points)
            );

            // Set fill color to blue
            ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            ellipse.FillFormat.SolidFillColor.Color = Color.Blue;

            // Set line color to black and line width
            ellipse.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            ellipse.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
            ellipse.LineFormat.Width = 2;

            // Save the presentation
            presentation.Save("EllipsePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
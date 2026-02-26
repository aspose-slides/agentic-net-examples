using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to the slide
        Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50f, 150f, 300f, 200f);

        // Set solid fill color for the rectangle
        rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        rectangle.FillFormat.SolidFillColor.Color = Color.LightBlue;

        // Set solid line color for the rectangle border
        rectangle.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        rectangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;

        // Save the presentation
        presentation.Save("RectangleShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
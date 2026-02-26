using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Apply line style to the rectangle
        rectangle.LineFormat.Width = 5; // Set line width
        rectangle.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash; // Set dash style
        rectangle.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid; // Set fill type for the line
        rectangle.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue; // Set line color

        // Save the presentation
        presentation.Save("RectangleLineStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
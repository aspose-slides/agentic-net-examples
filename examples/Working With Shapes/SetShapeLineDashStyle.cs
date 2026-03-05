using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Set the line dash style of the shape to Dash
        shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;

        // Save the presentation to a file
        presentation.Save("LineDashStyleDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
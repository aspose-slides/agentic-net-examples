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
            var presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            var slide = presentation.Slides[0];

            // Add a rectangle shape
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

            // Configure line (stroke) formatting
            shape.LineFormat.Width = 5.0; // line width
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue; // line color
            shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash; // dash style
            shape.LineFormat.CapStyle = Aspose.Slides.LineCapStyle.Round; // cap style

            // Save the presentation
            presentation.Save("StrokeShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
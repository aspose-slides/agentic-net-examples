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

        // Add an ellipse shape to the slide
        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse, // Shape type
            100, // X position
            100, // Y position
            200, // Width
            150  // Height
        );

        // Access the line format of the ellipse
        Aspose.Slides.ILineFormat lineFormat = ellipse.LineFormat;

        // Set line width
        lineFormat.Width = 5.0;

        // Set line style to single (solid line)
        lineFormat.Style = Aspose.Slides.LineStyle.Single;

        // Set dash style to dash
        lineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;

        // Set line fill to solid color (red)
        lineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        lineFormat.FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation to a file
        presentation.Save("EllipseLineFormat.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Set line width and color
        line.LineFormat.Width = 5;
        line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

        // Apply custom cap style to both ends of the line
        line.LineFormat.CapStyle = Aspose.Slides.LineCapStyle.Square;

        // Save the presentation
        presentation.Save("LineWithCustomCap.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
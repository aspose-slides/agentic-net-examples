using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a line shape (used here as a simple polyline)
        IAutoShape polyline = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set the line join style to round
        polyline.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Round;

        // Save the presentation
        string outputPath = "PolyLineJoinStyle.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
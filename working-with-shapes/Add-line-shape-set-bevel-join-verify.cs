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

        // Add a plain line shape to the slide
        IShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 300, 0);

        // Set line width
        lineShape.LineFormat.Width = 5;

        // Set line join style to Bevel
        lineShape.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Bevel;

        // Save the presentation
        try
        {
            presentation.Save("LineJoinBevel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported.
        }
    }
}
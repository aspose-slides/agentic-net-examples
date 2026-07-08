using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a plain line shape to the slide
        Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Set line width (optional)
        lineShape.LineFormat.Width = 5;

        // Set the line join style to Bevel
        lineShape.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Bevel;

        // Save the presentation
        string outputPath = "LineJoinBevel.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
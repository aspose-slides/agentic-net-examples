using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a line shape to the slide
        var line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set the line cap style to round for visual appearance
        line.LineFormat.CapStyle = LineCapStyle.Round;
        line.LineFormat.Width = 5; // Make the line visible

        // Save the presentation
        string outputPath = "LineCapRound.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}
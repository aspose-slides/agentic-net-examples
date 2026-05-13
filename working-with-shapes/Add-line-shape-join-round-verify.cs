using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineJoinStyleRound.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set line width
        line.LineFormat.Width = 5;

        // Set the line join style to Round
        line.LineFormat.JoinStyle = LineJoinStyle.Round;

        // Verify the join style by printing it
        Console.WriteLine("Line JoinStyle: " + line.LineFormat.JoinStyle);

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
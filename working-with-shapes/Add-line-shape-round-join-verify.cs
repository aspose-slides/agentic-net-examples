using System;
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

        // Add a line shape to the slide
        Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

        // Set line width
        lineShape.LineFormat.Width = 5;

        // Set line join style to Round
        lineShape.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Round;

        // Save the presentation
        string outputPath = "LineJoinStyleRound.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle format not supported exception
        }

        // Indicate completion
        Console.WriteLine("Presentation saved to " + outputPath);
    }
}
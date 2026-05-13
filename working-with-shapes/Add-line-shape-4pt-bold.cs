using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Set line weight to 4 points and make it appear bold
        lineShape.LineFormat.Width = 4;
        lineShape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;

        // Define output file path
        string outputPath = "LineBold.pptx";

        try
        {
            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
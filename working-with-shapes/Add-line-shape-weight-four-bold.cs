using System;
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
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

        // Set line weight to 4 points
        line.LineFormat.Width = 4;

        // Make the line appear bold by using a thick style
        line.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;

        // Save the presentation
        string outputPath = "LineBold.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
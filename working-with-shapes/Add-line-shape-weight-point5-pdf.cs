using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output PDF file path
        string outputPath = "LineShape.pdf";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a plain line shape to the slide
        IShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 150f, 300f, 0f);

        // Set the line weight to 0.5 points
        lineShape.LineFormat.Width = 0.5;

        try
        {
            // Save the presentation as PDF
            presentation.Save(outputPath, SaveFormat.Pdf);
        }
        catch (Exception)
        {
            // Format not supported or other error handling
        }
    }
}
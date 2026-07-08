using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineCapRound.pptx";

        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line shape to the slide
            IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

            // Set line width for better visibility
            line.LineFormat.Width = 10;

            // Set the line cap style to round
            line.LineFormat.CapStyle = LineCapStyle.Round;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException)
        {
            // Handle missing input files if any were used
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., unsupported format)
            // Comment: format not supported
        }
    }
}
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

        // Add a line shape to the slide
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Configure arrowheads: begin none, end diamond
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Diamond;

        // Define output path
        string outputPath = "LineWithDiamondArrow.pptx";

        // Save the presentation with exception handling
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            presentation.Dispose();
        }
    }
}
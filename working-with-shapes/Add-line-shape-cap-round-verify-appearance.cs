using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line shape to the slide
            IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

            // Set line formatting
            line.LineFormat.Style = LineStyle.ThickBetweenThin;
            line.LineFormat.Width = 10;
            line.LineFormat.DashStyle = LineDashStyle.DashDot;
            line.LineFormat.CapStyle = LineCapStyle.Round; // Set line cap to round

            // Save the presentation
            string outputPath = "LineCapRound.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
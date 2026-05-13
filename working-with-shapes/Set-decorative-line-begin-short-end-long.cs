using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add an arrow-shaped line to the slide
        IAutoShape line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
        line.LineFormat.Style = LineStyle.ThickBetweenThin;
        line.LineFormat.Width = 10;
        line.LineFormat.DashStyle = LineDashStyle.DashDot;
        line.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;
        line.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
        line.LineFormat.FillFormat.FillType = FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Maroon;

        // Define output path
        string outputPath = "ArrowLine.pptx";

        // Save the presentation with exception handling
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., file I/O errors)
        }
    }
}
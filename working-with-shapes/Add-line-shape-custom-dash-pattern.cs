using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a line shape
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set line style and width
        line.LineFormat.Style = LineStyle.ThickBetweenThin;
        line.LineFormat.Width = 10;

        // Set custom dash pattern
        line.LineFormat.DashStyle = LineDashStyle.Custom;
        line.LineFormat.CustomDashPattern = new float[] { 5f, 2f, 1f, 2f };

        // Set arrowheads
        line.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;
        line.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

        // Set line fill color
        line.LineFormat.FillFormat.FillType = FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

        // Save the presentation
        string outputPath = "CustomDashLine.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
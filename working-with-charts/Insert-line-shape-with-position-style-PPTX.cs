using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "CustomLinePresentation.pptx";

        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add a plain line shape to the slide (position: x=100, y=150, width=300, height=0)
            var lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 150, 300, 0);

            // Apply line formatting (style, width, dash style, color)
            lineShape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;
            lineShape.LineFormat.Width = 5;
            lineShape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;
            lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
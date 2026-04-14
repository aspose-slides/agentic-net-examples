using System;
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
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 400, 0);

        // Set basic line properties
        line.LineFormat.Style = Aspose.Slides.LineStyle.Single;
        line.LineFormat.Width = 5;

        // Apply a custom dash pattern
        line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Custom;
        float[] customPattern = new float[] { 5f, 2f, 3f, 2f };
        line.LineFormat.CustomDashPattern = customPattern;

        // Set line color (optional)
        line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkBlue;

        // Save the presentation
        string outputPath = "CustomDashLine.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
        }
    }
}
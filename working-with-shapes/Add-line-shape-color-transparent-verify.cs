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

        // Add a plain line shape
        Aspose.Slides.IAutoShape line = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 400, 0);

        // Optional: set line style and width
        line.LineFormat.Style = Aspose.Slides.LineStyle.Single;
        line.LineFormat.Width = 2;

        // Set line fill to solid transparent color (no visible border)
        line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Transparent;

        // Define output path
        string outputPath = "TransparentLine.pptx";

        // Save the presentation (handle unsupported format exception)
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other save error
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
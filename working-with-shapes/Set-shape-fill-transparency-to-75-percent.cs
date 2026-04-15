using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Set solid fill type
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Set fill color with 75% transparency (alpha = 64)
        shape.FillFormat.SolidFillColor.Color = Color.FromArgb(64, Color.Blue);

        // Ensure outline (line) is fully opaque (default black)
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

        // Save the presentation
        try
        {
            presentation.Save("ShapeTransparency.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
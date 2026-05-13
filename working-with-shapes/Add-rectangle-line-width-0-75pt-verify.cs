using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100f, 100f, 200f, 100f);

        // Set line width to 0.75 points
        shape.LineFormat.Width = 0.75f;

        // Ensure line is visible (solid fill)
        shape.LineFormat.FillFormat.FillType = FillType.Solid;

        // Save the presentation
        string outputPath = "output.pptx";
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
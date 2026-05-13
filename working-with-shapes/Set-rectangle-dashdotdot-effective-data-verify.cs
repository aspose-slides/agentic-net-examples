using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 150, 200, 100);

        // Set line dash style to DashDot (closest to dash dot dot)
        shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;

        // Set line width
        shape.LineFormat.Width = 2;

        // Retrieve effective line format data
        Aspose.Slides.ILineFormatEffectiveData effective = shape.LineFormat.GetEffective();

        // Verify the effective dash style
        Console.WriteLine("Effective Dash Style: " + effective.DashStyle);

        // Save the presentation
        string outPath = "Output.pptx";
        try
        {
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
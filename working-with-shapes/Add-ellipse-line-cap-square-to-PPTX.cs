using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "EllipseLineCap.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);

        // Set the line cap style to square
        ellipse.LineFormat.CapStyle = Aspose.Slides.LineCapStyle.Square;

        // Verify the effective line cap style
        Aspose.Slides.ILineFormatEffectiveData effective = ellipse.LineFormat.GetEffective();
        Console.WriteLine("Effective Line Cap Style: " + effective.CapStyle);

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
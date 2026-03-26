using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "AnnotatedPresentation.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a callout shape
        Aspose.Slides.IAutoShape callout = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Callout1, 100, 100, 300, 100);
        callout.AddTextFrame("Important note: Review this section.");

        // Format the callout border
        callout.LineFormat.Width = 2;
        callout.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

        // Fill the callout background
        callout.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.FillFormat.SolidFillColor.Color = Color.Yellow;

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose resources
        presentation.Dispose();
    }
}
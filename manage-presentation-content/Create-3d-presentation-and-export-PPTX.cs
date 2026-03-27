using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output directory and ensure it exists
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        string outPath = Path.Combine(outputDir, "ThreeDPresentation.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a 3D cube shape to the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Cube, 100, 100, 200, 200);

        // Save the presentation as PPTX
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);

        // Cast the shape to IAutoShape to add text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
        autoShape.AddTextFrame("Click Here");

        // Attach an external URL hyperlink to the shape
        autoShape.HyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");

        // Define output file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "HyperlinkedPresentation.pptx");

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}
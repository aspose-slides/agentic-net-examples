using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape on the first slide
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);

        // Add a text frame with display text
        shape.AddTextFrame("Visit Aspose");

        // Set a website hyperlink on the text run
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
            new Aspose.Slides.Hyperlink("https://www.aspose.com");

        // Save the presentation
        string outputPath = "HyperlinkPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}
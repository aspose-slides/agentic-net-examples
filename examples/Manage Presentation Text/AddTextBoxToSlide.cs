using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define output directory
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 75, 150, 50);

        // Add an empty text frame
        autoShape.AddTextFrame(" ");

        // Access the text frame, paragraph, and portion
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];

        // Set the text for the portion
        portion.Text = "Aspose TextBox";

        // Save the presentation as PPTX
        string outputPath = Path.Combine(outputDir, "TextBox_out.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
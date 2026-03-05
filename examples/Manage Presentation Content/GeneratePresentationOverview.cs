using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Create or load a presentation
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
        }

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.LightBlue;

        // Cast to AutoShape to add a text frame
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
        autoShape.AddTextFrame("Presentation Overview");
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

        // Format the paragraph
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
        paragraph.ParagraphFormat.SpaceBefore = 20;
        paragraph.ParagraphFormat.SpaceAfter = 20;

        // Save the presentation in PPTX format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
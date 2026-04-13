using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TextBoxExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and file
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            string outputFile = Path.Combine(outputDir, "TextBox_out.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 75, 150, 50);

            // Add a TextFrame
            autoShape.AddTextFrame(" ");

            // Access the text frame
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Get the first paragraph and portion
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
            Aspose.Slides.IPortion portion = paragraph.Portions[0];

            // Set the text
            portion.Text = "Aspose TextBox";

            // Save the presentation
            presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
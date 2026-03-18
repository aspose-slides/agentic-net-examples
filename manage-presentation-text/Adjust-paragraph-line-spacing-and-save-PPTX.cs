using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape is an AutoShape containing a text frame
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes[0];
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Get the first paragraph
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Adjust line spacing properties
            paragraph.ParagraphFormat.SpaceWithin = 80;   // Space between lines (percentage)
            paragraph.ParagraphFormat.SpaceBefore = 40;   // Space before the paragraph (percentage)
            paragraph.ParagraphFormat.SpaceAfter = 40;    // Space after the paragraph (percentage)

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
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

            // Get the text frame and the first paragraph
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Set line spacing properties
            paragraph.ParagraphFormat.SpaceWithin = 80;   // Space between lines
            paragraph.ParagraphFormat.SpaceBefore = 40;   // Space before the paragraph
            paragraph.ParagraphFormat.SpaceAfter = 40;    // Space after the paragraph

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
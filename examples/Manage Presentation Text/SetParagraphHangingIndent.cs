using System;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string sourcePath = "InputPresentation.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is an AutoShape with a text frame
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes[0];

            // Access the text frame of the shape
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Get the first paragraph in the text frame
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Set a hanging indent (negative value) for the paragraph
            paragraph.ParagraphFormat.Indent = -30f; // 30 points hanging indent

            // Save the modified presentation
            presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
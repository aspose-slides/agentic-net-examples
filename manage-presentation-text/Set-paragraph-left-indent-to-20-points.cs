using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape rect = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        // Add a text frame with sample text
        Aspose.Slides.ITextFrame textFrame = rect.AddTextFrame("Sample paragraph text.");
        // Set autofit type
        textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;
        // Get the first paragraph
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        // Set left indent to 20 points
        paragraph.ParagraphFormat.Indent = 20f;
        // Save the presentation with exception handling for unsupported formats
        try
        {
            presentation.Save("ParagraphIndent.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        // Dispose the presentation
        presentation.Dispose();
    }
}
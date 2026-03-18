using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape is an AutoShape containing text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes[0];

            // Get the text frame of the shape
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Retrieve the first paragraph
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Retrieve the first portion within the paragraph
            Aspose.Slides.IPortion portion = paragraph.Portions[0];

            // Modify the font size of the portion
            portion.PortionFormat.FontHeight = 32f;

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyHangingIndent
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    50f,   // X position
                    100f,  // Y position
                    400f,  // Width
                    200f   // Height
                );

                // Add a text frame with sample text
                Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("First line of text.\nSecond line of text.\nThird line of text.");

                // Set autofit type to shape
                textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

                // Get the first paragraph
                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

                // Set a hanging indent (negative first line indent)
                paragraph.ParagraphFormat.Indent = -30f; // Adjust value as needed

                // Optionally set left margin to align subsequent lines
                paragraph.ParagraphFormat.MarginLeft = 30f;

                // Save the presentation as PPTX
                presentation.Save("HangingIndentOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
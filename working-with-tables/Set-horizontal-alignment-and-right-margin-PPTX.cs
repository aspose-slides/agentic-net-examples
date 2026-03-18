using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetHorizontalAlignmentAndRightMargin
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

                // Add a text frame to the shape
                shape.AddTextFrame("Sample text for alignment and margin.");

                // Get the text frame
                Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

                // Set the right margin of the text frame
                textFrame.TextFrameFormat.MarginRight = 20.0;

                // Get the first paragraph in the text frame
                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

                // Set horizontal alignment to center
                paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

                // Save the presentation
                presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
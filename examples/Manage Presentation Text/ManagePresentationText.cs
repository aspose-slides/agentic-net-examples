using System;
using Aspose.Slides;
using Aspose.Slides.Util;

namespace PresentationTextManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to the slide
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                // Set initial text in the shape's text frame
                autoShape.TextFrame.Text = "Original paragraph text";

                // Get the first paragraph of the text frame
                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

                // Modify the paragraph text
                paragraph.Text = "Updated paragraph text with center alignment";

                // Align the paragraph to the center
                paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

                // Save the presentation as PPTX
                presentation.Save("ManagedTextPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
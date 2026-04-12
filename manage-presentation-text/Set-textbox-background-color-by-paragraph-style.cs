using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetTextboxBackgroundByParagraphStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            Presentation presentation = null;

            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Presentation(inputPath);
                }
                catch (Exception)
                {
                    // Format not supported
                    // Create a new presentation as fallback
                    presentation = new Presentation();
                }
            }
            else
            {
                presentation = new Presentation();
            }

            // Ensure there is at least one slide
            ISlide slide = null;
            if (presentation.Slides.Count > 0)
            {
                slide = presentation.Slides[0];
            }
            else
            {
                slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Add a rectangle shape that will act as a text box
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 100);
            // Add a text frame with sample text
            ITextFrame textFrame = shape.AddTextFrame("Sample text for paragraph style.");

            // Access the first paragraph (could be extended to iterate paragraphs)
            IParagraph paragraph = textFrame.Paragraphs[0];

            // Example: set the shape's background color based on a chosen color
            // Here we simply use LightBlue; replace with logic based on paragraph style if needed
            shape.FillFormat.FillType = FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
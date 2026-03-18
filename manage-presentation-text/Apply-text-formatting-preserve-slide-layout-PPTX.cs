using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TextFormattingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Find the first AutoShape that contains a text frame
                IAutoShape autoShape = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IAutoShape && ((IAutoShape)shape).TextFrame != null)
                    {
                        autoShape = (IAutoShape)shape;
                        break;
                    }
                }

                if (autoShape != null)
                {
                    // Apply formatting to each portion in the first paragraph
                    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                    foreach (IPortion portion in paragraph.Portions)
                    {
                        portion.PortionFormat.FontBold = NullableBool.True;
                        portion.PortionFormat.FontHeight = 24;
                    }
                }

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
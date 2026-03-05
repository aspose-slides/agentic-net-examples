using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                // Process only AutoShape objects that can contain text
                if (slide.Shapes[shapeIndex] is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes[shapeIndex];

                    // Ensure the shape has a TextFrame
                    if (autoShape.TextFrame != null)
                    {
                        // Iterate through all paragraphs in the TextFrame
                        for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                        {
                            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];

                            // Set line spacing (SpaceWithin) to 150% of the font size
                            paragraph.ParagraphFormat.SpaceWithin = 150f;
                        }
                    }
                }
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}
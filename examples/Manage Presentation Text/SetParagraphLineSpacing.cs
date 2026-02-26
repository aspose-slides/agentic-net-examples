using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides in the presentation
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the current slide
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

                            // Set line spacing (SpaceWithin) in points (negative value indicates points)
                            paragraph.ParagraphFormat.SpaceWithin = -12f; // Example: 12 points line spacing
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
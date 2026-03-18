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

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Process only AutoShapes that contain a TextFrame
                    if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                    {
                        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                        // Iterate through all paragraphs in the TextFrame
                        for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                        {
                            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                            // Iterate through all portions in the paragraph
                            for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                            {
                                Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];

                                // Adjust intercharacter spacing (e.g., 2 points)
                                portion.PortionFormat.Spacing = 2f;
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
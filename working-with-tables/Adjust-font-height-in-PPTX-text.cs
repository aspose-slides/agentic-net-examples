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
            Presentation presentation = new Presentation("input.pptx");

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Process only AutoShapes that contain a TextFrame
                    if (shape is IAutoShape)
                    {
                        IAutoShape autoShape = (IAutoShape)shape;
                        if (autoShape.TextFrame != null)
                        {
                            // Iterate through paragraphs
                            for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                            {
                                IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];

                                // Iterate through portions within the paragraph
                                for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                {
                                    IPortion portion = paragraph.Portions[portionIndex];

                                    // Set the desired font height (in points)
                                    portion.PortionFormat.FontHeight = 24f;
                                }
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
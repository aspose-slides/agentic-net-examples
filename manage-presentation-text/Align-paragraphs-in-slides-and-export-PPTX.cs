using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AlignParagraphsExample
{
    class Program
    {
        static void Main(string[] args)
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
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            // Align each paragraph to the center
                            for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                            {
                                IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];
                                paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
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
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "aligned_output.pptx";

            using (var presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    var slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        var shape = slide.Shapes[shapeIndex];

                        // Process only AutoShape objects that contain a TextFrame
                        if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            var textFrame = autoShape.TextFrame;

                            // Align each paragraph within the text frame
                            for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                            {
                                var paragraph = textFrame.Paragraphs[paraIndex];
                                paragraph.ParagraphFormat.Alignment = TextAlignment.Center;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
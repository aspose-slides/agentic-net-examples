using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Process only AutoShapes that contain a TextFrame
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        // Iterate through all paragraphs in the TextFrame
                        for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                        {
                            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];

                            // Iterate through all portions in the paragraph
                            for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                            {
                                Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];

                                // Check if the portion has a hyperlink assigned
                                if (portion.PortionFormat.HyperlinkClick != null)
                                {
                                    // Apply consistent styling to the hyperlink portion
                                    portion.PortionFormat.FontHeight = 14.0f;
                                    portion.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;
                                    portion.PortionFormat.HyperlinkClick.Tooltip = "Styled hyperlink";
                                    portion.PortionFormat.HyperlinkClick.ColorSource = Aspose.Slides.HyperlinkColorSource.PortionFormat;
                                }
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
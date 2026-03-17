using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
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
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Process only AutoShape objects that contain a TextFrame
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                        // Iterate through paragraphs
                        for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                        {
                            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                            // Iterate through portions within the paragraph
                            for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                            {
                                Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];

                                // Example condition: replace hyperlinks in portions containing a specific placeholder
                                if (portion.Text != null && portion.Text.Contains("oldlink"))
                                {
                                    // Update the hyperlink using HyperlinkManager
                                    Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                                    hyperlinkManager.SetExternalHyperlinkClick("https://newexample.com");
                                }
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
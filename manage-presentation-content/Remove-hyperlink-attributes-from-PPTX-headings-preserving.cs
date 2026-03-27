using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        Presentation presentation = new Presentation(inputPath);

        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IShape shape = slide.Shapes[shapeIndex];
                IAutoShape autoShape = shape as IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                    {
                        IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];
                        for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                        {
                            IPortion portion = paragraph.Portions[portionIndex];
                            IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                            hyperlinkManager.RemoveHyperlinkClick();
                            hyperlinkManager.RemoveHyperlinkMouseOver();
                        }
                    }
                }
            }
        }

        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}
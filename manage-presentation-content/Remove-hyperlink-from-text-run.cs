using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IShape shape = slide.Shapes[0];
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                    if (textFrame.Paragraphs.Count > 0)
                    {
                        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
                        if (paragraph.Portions.Count > 1)
                        {
                            Aspose.Slides.IPortion portion = paragraph.Portions[1];
                            Aspose.Slides.IHyperlinkManager hyperlinkMgr = portion.PortionFormat.HyperlinkManager;
                            hyperlinkMgr.RemoveHyperlinkClick();
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
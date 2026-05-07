using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.odp";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            int hyperlinkCountBefore = 0;
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                        {
                            foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                            {
                                if (portion.PortionFormat.HyperlinkClick != null)
                                {
                                    hyperlinkCountBefore++;
                                }
                            }
                        }
                    }
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);

            Aspose.Slides.Presentation odpPresentation = new Aspose.Slides.Presentation(outputPath);
            int hyperlinkCountAfter = 0;
            foreach (Aspose.Slides.ISlide slide in odpPresentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                        {
                            foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                            {
                                if (portion.PortionFormat.HyperlinkClick != null)
                                {
                                    hyperlinkCountAfter++;
                                }
                            }
                        }
                    }
                }
            }

            if (hyperlinkCountBefore == hyperlinkCountAfter && hyperlinkCountBefore > 0)
            {
                Console.WriteLine("All hyperlinks are preserved after conversion.");
            }
            else
            {
                Console.WriteLine("Hyperlink validation failed. Before: {0}, After: {1}", hyperlinkCountBefore, hyperlinkCountAfter);
            }

            presentation.Dispose();
            odpPresentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
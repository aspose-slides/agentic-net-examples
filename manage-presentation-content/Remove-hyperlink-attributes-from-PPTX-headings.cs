using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (IPortion portion in paragraph.Portions)
                                {
                                    IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                                    hyperlinkManager.RemoveHyperlinkClick();
                                    hyperlinkManager.RemoveHyperlinkMouseOver();
                                }
                            }
                        }
                    }
                }

                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
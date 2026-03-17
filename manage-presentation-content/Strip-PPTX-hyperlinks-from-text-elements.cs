using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (var slide in presentation.Slides)
                {
                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            var textFrame = autoShape.TextFrame;
                            foreach (var paragraph in textFrame.Paragraphs)
                            {
                                foreach (var portion in paragraph.Portions)
                                {
                                    var hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                                    hyperlinkManager.SetExternalHyperlinkClick(string.Empty);
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
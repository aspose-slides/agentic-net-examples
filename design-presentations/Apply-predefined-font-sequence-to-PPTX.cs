using System;
using Aspose.Slides.Export;

namespace FontSequenceDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentation = new Aspose.Slides.Presentation();

                var fontNames = new[] { "Arial", "Calibri", "Times New Roman" };

                for (var i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var fontName = fontNames[i % fontNames.Length];

                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            foreach (var paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (var portion in paragraph.Portions)
                                {
                                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData(fontName);
                                }
                            }
                        }
                    }
                }

                presentation.Save("FontSequencePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
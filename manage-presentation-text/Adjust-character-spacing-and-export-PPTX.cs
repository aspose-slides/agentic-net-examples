using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AdjustCharacterSpacing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[j];
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                            for (int p = 0; p < textFrame.Paragraphs.Count; p++)
                            {
                                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[p];
                                for (int po = 0; po < paragraph.Portions.Count; po++)
                                {
                                    Aspose.Slides.IPortion portion = paragraph.Portions[po];
                                    portion.PortionFormat.Spacing = 2.0f; // Adjust intercharacter spacing
                                }
                            }
                        }
                    }
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
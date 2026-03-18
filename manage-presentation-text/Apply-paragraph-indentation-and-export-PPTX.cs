using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                for (int j = 0; j < slide.Shapes.Count; j++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[j];
                    if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                    {
                        for (int p = 0; p < autoShape.TextFrame.Paragraphs.Count; p++)
                        {
                            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[p];
                            paragraph.ParagraphFormat.Indent = 20;
                        }
                    }
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
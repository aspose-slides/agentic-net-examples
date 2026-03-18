using System;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

            foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
            {
                foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
                {
                    foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                    {
                        portion.PortionFormat.FontHeight = 12f;
                    }
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
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
        string fontPath = "customfont.ttf";
        string fontName = "CustomFont";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!File.Exists(fontPath))
        {
            Console.WriteLine("Font file does not exist.");
            return;
        }

        try
        {
            byte[] fontData = File.ReadAllBytes(fontPath);
            Aspose.Slides.FontsLoader.LoadExternalFont(fontData);

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            foreach (Aspose.Slides.ISlide slide in pres.Slides)
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
                                portion.PortionFormat.LatinFont = new Aspose.Slides.FontData(fontName);
                            }
                        }
                    }
                }
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
            Aspose.Slides.FontsLoader.ClearCache();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
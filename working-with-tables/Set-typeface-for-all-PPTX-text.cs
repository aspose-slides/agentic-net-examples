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
            string targetFontName = "Arial";

            // Load custom fonts if required (example)
            // byte[] fontBytes = System.IO.File.ReadAllBytes("fonts/Arial.ttf");
            // Aspose.Slides.FontsLoader.LoadExternalFont(fontBytes);

            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultRegularFont = targetFontName;

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
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
                                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData(targetFontName);
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
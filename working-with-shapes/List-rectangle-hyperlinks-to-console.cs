using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (var presentation = new Presentation(inputPath))
            {
                foreach (var slide in presentation.Slides)
                {
                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is IAutoShape autoShape && autoShape.ShapeType == ShapeType.Rectangle)
                        {
                            var hyperlink = autoShape.HyperlinkClick;
                            if (hyperlink != null && !string.IsNullOrEmpty(hyperlink.ExternalUrl))
                            {
                                Console.WriteLine(hyperlink.ExternalUrl);
                            }
                        }
                    }
                }

                // Save presentation before exit
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported (PPTX).");
        }
        catch (PptUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported (PPT).");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
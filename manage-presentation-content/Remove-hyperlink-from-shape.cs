using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.IHyperlinkManager hyperlinkManager = shape.HyperlinkManager;
                    hyperlinkManager.RemoveHyperlinkClick();
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
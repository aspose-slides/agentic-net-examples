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

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.ITable table = slide.Shapes[shapeIndex] as Aspose.Slides.ITable;
                        if (table == null)
                        {
                            continue;
                        }

                        Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
                        portionFormat.FontHeight = 12f;
                        table.SetTextFormat(portionFormat);
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
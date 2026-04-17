using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
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

            int slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                int shapeCount = slide.Shapes.Count;
                for (int j = 0; j < shapeCount; j++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[j];
                    if (shape.LineFormat != null)
                    {
                        double lineWidth = shape.LineFormat.Width;
                        if (lineWidth <= 0)
                        {
                            shape.LineFormat.Width = 1.0;
                        }
                    }
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
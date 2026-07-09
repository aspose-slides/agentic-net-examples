using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFilePath = "input.pptx";
        string outputImagePath = "shape_thumbnail.png";
        string outputPresentationPath = "output.pptx";

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        byte[] presentationBytes = File.ReadAllBytes(inputFilePath);
        Aspose.Slides.Presentation pres = null;

        try
        {
            using (MemoryStream ms = new MemoryStream(presentationBytes))
            {
                pres = new Aspose.Slides.Presentation(ms);

                Aspose.Slides.ISlide slide = pres.Slides[0];
                if (slide.Shapes.Count > 0)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[0];
                    Aspose.Slides.IImage shapeImage = shape.GetImage();
                    shapeImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                }
                else
                {
                    Console.WriteLine("No shapes found on the first slide.");
                }

                // Save presentation before exit
                pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}
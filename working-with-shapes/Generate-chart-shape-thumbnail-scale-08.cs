using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDirectory = "output";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            int chartIndex = 0;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    float scaleX = 0.8f;
                    float scaleY = 0.8f;
                    Aspose.Slides.IImage image = chart.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);
                    string imagePath = Path.Combine(outputDirectory, $"Chart_{slide.SlideNumber}_{chartIndex}.jpg");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                    image.Dispose();
                    chartIndex++;
                }
            }

            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
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
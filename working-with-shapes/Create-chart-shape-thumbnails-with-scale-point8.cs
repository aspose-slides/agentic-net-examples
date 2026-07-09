using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";
        var imagesDir = "ChartThumbnails";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var presentation = new Presentation(inputPath);
            var slide = presentation.Slides[0];
            Directory.CreateDirectory(imagesDir);
            var scale = 0.8f;
            var shapeIndex = 0;

            foreach (var shape in slide.Shapes)
            {
                var chart = shape as IChart;
                if (chart != null)
                {
                    var image = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scale, scale);
                    var imagePath = Path.Combine(imagesDir, $"Chart_{slide.SlideNumber}_{shapeIndex}.jpg");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                    image.Dispose();
                    shapeIndex++;
                }
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs)
            Console.WriteLine(ex.Message);
        }
    }
}
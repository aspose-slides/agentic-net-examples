using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartImages
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = args.Length > 0 ? args[0] : "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            using var presentation = new Presentation(inputPath);

            for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                var slide = presentation.Slides[slideIndex];
                var shapeCount = slide.Shapes.Count;

                for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
                {
                    var shape = slide.Shapes[shapeIndex];
                    if (shape is IChart chart)
                    {
                        var image = chart.GetImage();
                        var imagePath = $"chart_slide{slideIndex}_shape{shapeIndex}.png";
                        image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                        Console.WriteLine($"Saved chart image to {imagePath}");
                    }
                }
            }

            var outputPath = "output.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine($"Presentation saved to {outputPath}");
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPresPath = "output_A3.pptx";
        var outputImgFolder = "Images";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load presentation
            var presentation = new Presentation(inputPath);

            // Set slide size to A3 with EnsureFit scaling
            presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.A3Paper, Aspose.Slides.SlideSizeScaleType.EnsureFit);

            // Save modified presentation
            presentation.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Ensure output folder exists
            Directory.CreateDirectory(outputImgFolder);

            // Export each slide to JPG
            foreach (var slide in presentation.Slides)
            {
                using (var image = slide.GetImage(1f, 1f))
                {
                    var imagePath = Path.Combine(outputImgFolder, $"Slide_{slide.SlideNumber}.jpg");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Dispose presentation
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs)
        }
    }
}
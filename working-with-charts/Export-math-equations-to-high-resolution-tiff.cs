using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MathEquationToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input PPTX file path and output folder for TIFF images
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: MathEquationToTiff <input-pptx> <output-folder>");
                return;
            }

            string inputPath = args[0];
            string outputFolder = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file does not exist: {inputPath}");
                return;
            }

            // Verify that the output folder exists; if not, create it
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure high‑resolution TIFF options
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            tiffOptions.DpiX = 300;
            tiffOptions.DpiY = 300;

            // Export each slide as a high‑resolution TIFF image
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                Aspose.Slides.IImage image = slide.GetImage(tiffOptions);
                string outputPath = Path.Combine(outputFolder, $"slide_{i + 1}.tiff");
                image.Save(outputPath, Aspose.Slides.ImageFormat.Tiff);
                image.Dispose();
            }

            // Save the presentation (required by lifecycle rule)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}
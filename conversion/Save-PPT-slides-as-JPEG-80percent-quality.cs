using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file path (can be passed as argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Iterate through each slide and save as JPEG with 80% quality
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    Aspose.Slides.IImage image = slide.GetImage(1f, 1f);
                    string outputFile = $"slide_{i + 1}.jpg";
                    image.Save(outputFile, Aspose.Slides.ImageFormat.Jpeg, 80);
                }

                // Save the presentation before exiting (as per rule)
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
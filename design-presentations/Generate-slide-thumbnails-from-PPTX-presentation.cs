using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputDirectory = "Thumbnails";
                Directory.CreateDirectory(outputDirectory);

                using (Presentation presentation = new Presentation(inputPath))
                {
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        using (IImage slideImage = slide.GetImage())
                        {
                            string outputPath = Path.Combine(outputDirectory, $"slide_{index + 1}.png");
                            slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the presentation before exiting
                    string savedPath = "output.pptx";
                    presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
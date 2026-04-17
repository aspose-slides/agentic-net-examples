using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompressAllPictures
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output_compressed.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IPictureFrame pictureFrame = slide.Shapes[shapeIndex] as IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Compress image, delete cropped areas, use Dpi96 (minimum size) as example
                            pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi96);
                        }
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
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
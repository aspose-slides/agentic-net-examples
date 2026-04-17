using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompressPictureExample
{
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            IPictureFrame pictureFrame = shape as IPictureFrame;
                            if (pictureFrame != null)
                            {
                                // Compress the image, delete cropped areas, target resolution 150 DPI (web)
                                bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
                                // Optionally, handle the result if needed
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
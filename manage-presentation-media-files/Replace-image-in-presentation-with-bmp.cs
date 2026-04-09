using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string bmpPath = "newImage.bmp";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist.");
                return;
            }

            if (!File.Exists(bmpPath))
            {
                Console.WriteLine("BMP image file does not exist.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    if (pres.Images.Count == 0)
                    {
                        Console.WriteLine("No images in the presentation to replace.");
                    }
                    else
                    {
                        byte[] newImageData = File.ReadAllBytes(bmpPath);
                        Aspose.Slides.IPPImage existingImage = pres.Images[0];
                        existingImage.ReplaceImage(newImageData);
                    }

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
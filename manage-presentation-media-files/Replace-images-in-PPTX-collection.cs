using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceImagesDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var newImagePath = "newImage.png";

                using (var presentation = new Presentation(inputPath))
                {
                    var imageCount = presentation.Images.Count;
                    var newImageData = File.ReadAllBytes(newImagePath);

                    for (int i = 0; i < imageCount; i++)
                    {
                        var image = presentation.Images[i];
                        image.ReplaceImage(newImageData);
                    }

                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
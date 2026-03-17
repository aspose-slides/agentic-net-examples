using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractEmbeddedImages
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = "input.pptx";
                var outputFolder = "ExtractedImages";
                Directory.CreateDirectory(outputFolder);

                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    var imageCounter = 0;

                    foreach (var slide in presentation.Slides)
                    {
                        foreach (var shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.ISlidesPicture picture)
                            {
                                var embeddedImage = picture.Image; // IPPImage
                                var imageData = embeddedImage.BinaryData;
                                var outputPath = Path.Combine(outputFolder, $"image_{imageCounter}.png");
                                File.WriteAllBytes(outputPath, imageData);
                                imageCounter++;
                            }
                        }
                    }

                    // Save the presentation (if any modifications were made)
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
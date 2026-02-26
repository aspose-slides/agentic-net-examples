using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            // Output directory for extracted images
            string outputDir = Path.Combine(Environment.CurrentDirectory, "ExtractedImages");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            int imageIndex = 0;
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                    if (pictureFrame != null)
                    {
                        // Get the image associated with the picture frame
                        Aspose.Slides.IPPImage ppImage = pictureFrame.PictureFormat.Picture.Image;
                        if (ppImage != null)
                        {
                            byte[] imageData = ppImage.BinaryData;
                            string contentType = ppImage.ContentType; // e.g., "image/png"
                            int slashPos = contentType.LastIndexOf('/');
                            string extension = (slashPos >= 0 && slashPos < contentType.Length - 1)
                                ? contentType.Substring(slashPos + 1)
                                : "bin";

                            string outputFile = Path.Combine(outputDir, $"image_{imageIndex}.{extension}");
                            File.WriteAllBytes(outputFile, imageData);
                            imageIndex++;
                        }
                    }
                }
            }

            // Save the presentation (no modifications made, but required by authoring rules)
            string savedPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");
            presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}
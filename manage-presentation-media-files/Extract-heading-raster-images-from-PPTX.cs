using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Directory to store extracted images
        string outputDir = "ExtractedImages";

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation
            presentation = new Aspose.Slides.Presentation(inputPath);

            int imageIndex = 0;
            // Iterate through all slides
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Process only picture frames (heading images)
                    if (shape is Aspose.Slides.IPictureFrame)
                    {
                        Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)shape;
                        // Retrieve the embedded image via PictureFormat.Picture.Image
                        Aspose.Slides.IPPImage embeddedImage = pictureFrame.PictureFormat.Picture.Image;
                        if (embeddedImage != null)
                        {
                            // Get raw image bytes and content type (e.g., image/png)
                            byte[] imageData = embeddedImage.BinaryData;
                            string contentType = embeddedImage.ContentType;
                            int slashPos = contentType.LastIndexOf('/');
                            string extension = contentType.Substring(slashPos + 1);
                            // Build output file path preserving original format
                            string outPath = Path.Combine(outputDir, $"image_{imageIndex}.{extension}");
                            File.WriteAllBytes(outPath, imageData);
                            imageIndex++;
                        }
                    }
                }
            }

            // Save the (unchanged) presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
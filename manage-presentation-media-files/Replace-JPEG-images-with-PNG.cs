using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceJpegWithPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (can be passed as first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all images in the presentation
                    foreach (IPPImage image in presentation.Images)
                    {
                        // Identify JPEG images by MIME type
                        if (image.ContentType != null && image.ContentType.Equals("image/jpeg", StringComparison.OrdinalIgnoreCase))
                        {
                            // Get the image as IImage for conversion
                            using (IImage slideImage = image.Image)
                            {
                                // Convert JPEG to PNG using a memory stream
                                using (MemoryStream pngStream = new MemoryStream())
                                {
                                    slideImage.Save(pngStream, Aspose.Slides.ImageFormat.Png);
                                    byte[] pngBytes = pngStream.ToArray();

                                    // Replace the original JPEG data with the new PNG data
                                    image.ReplaceImage(pngBytes);
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved as: " + outputPath);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
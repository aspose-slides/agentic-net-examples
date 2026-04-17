using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlideBackgrounds
{
    class Program
    {
        static void Main()
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Output directory for background images
            string outputDir = "BackgroundImages";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];

                        // Check if slide background is a picture
                        if (slide.Background.Type == BackgroundType.OwnBackground &&
                            slide.Background.FillFormat.FillType == FillType.Picture)
                        {
                            // Retrieve the picture image
                            IPPImage bgImage = slide.Background.FillFormat.PictureFillFormat.Picture.Image;

                            // Get binary data of the image
                            byte[] imageData = bgImage.BinaryData;

                            // Determine file extension from content type
                            string contentType = bgImage.ContentType?.ToLowerInvariant() ?? "";
                            string extension = ".bin"; // default fallback

                            if (contentType.Contains("png"))
                                extension = ".png";
                            else if (contentType.Contains("jpeg") || contentType.Contains("jpg"))
                                extension = ".jpg";
                            else if (contentType.Contains("bmp"))
                                extension = ".bmp";
                            else if (contentType.Contains("gif"))
                                extension = ".gif";

                            // Build output file path
                            string outputPath = Path.Combine(outputDir, $"slide_{i + 1}_background{extension}");

                            // Write image data preserving original format
                            File.WriteAllBytes(outputPath, imageData);
                        }
                        else
                        {
                            // Slide does not have a picture background; skip or handle as needed
                            // Comment: background format not supported for this slide.
                        }
                    }

                    // Save presentation before exit (as per requirement)
                    string savedPresentationPath = Path.Combine(outputDir, "presentation_saved.pptx");
                    pres.Save(savedPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Comment: format not supported.
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
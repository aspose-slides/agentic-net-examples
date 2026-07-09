using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Override paths with command line arguments if provided
            if (args.Length >= 1)
            {
                inputPath = args[0];
            }
            if (args.Length >= 2)
            {
                outputPath = args[1];
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Generate Base64 thumbnail
                string base64Thumbnail = GetSlideThumbnailBase64(inputPath);
                Console.WriteLine("Base64 Thumbnail:");
                Console.WriteLine(base64Thumbnail);

                // Save presentation before exit (no modifications in this example)
                using (Presentation pres = new Presentation(inputPath))
                {
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("File format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Returns a Base64 string of the first slide thumbnail
        static string GetSlideThumbnailBase64(string presentationPath)
        {
            using (Presentation pres = new Presentation(presentationPath))
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];
                using (Aspose.Slides.IImage image = slide.GetImage(1f, 1f))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, Aspose.Slides.ImageFormat.Jpeg);
                        byte[] imageBytes = ms.ToArray();
                        return Convert.ToBase64String(imageBytes);
                    }
                }
            }
        }
    }
}
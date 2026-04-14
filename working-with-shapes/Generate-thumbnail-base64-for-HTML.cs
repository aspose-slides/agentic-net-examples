using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailBase64Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "example.pptx";
            int slideIndex = 0;

            if (args.Length >= 1)
            {
                inputPath = args[0];
            }
            if (args.Length >= 2)
            {
                int parsedIndex;
                if (Int32.TryParse(args[1], out parsedIndex))
                {
                    slideIndex = parsedIndex;
                }
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                string base64 = GetSlideThumbnailBase64(inputPath, slideIndex);
                Console.WriteLine("Base64 Thumbnail:");
                Console.WriteLine(base64);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static string GetSlideThumbnailBase64(string presentationPath, int slideIndex)
        {
            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath);

            // Ensure slide index is within range
            if (slideIndex < 0 || slideIndex >= pres.Slides.Count)
            {
                throw new ArgumentOutOfRangeException("slideIndex");
            }

            // Access the desired slide
            Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

            // Desired thumbnail dimensions
            int desiredX = 200;
            int desiredY = 150;

            // Calculate scaling factors
            float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
            float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

            // Generate thumbnail image
            using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
            {
                // Save image to memory stream in JPEG format
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, Aspose.Slides.ImageFormat.Jpeg);
                    byte[] imageBytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    
                    // Save presentation before exit (no modifications made)
                    pres.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    
                    return base64String;
                }
            }
        }
    }
}
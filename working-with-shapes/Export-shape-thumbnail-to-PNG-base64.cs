using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "sample.pptx";
            // Slide index (0‑based)
            int slideIndex = 0;

            // Override with command line arguments if provided
            if (args.Length >= 1)
            {
                inputPath = args[0];
            }
            if (args.Length >= 2)
            {
                Int32.TryParse(args[1], out slideIndex);
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Ensure slide index is within range
                if (slideIndex < 0 || slideIndex >= pres.Slides.Count)
                {
                    Console.WriteLine("Slide index out of range.");
                    pres.Save("output.pptx", SaveFormat.Pptx);
                    return;
                }

                // Get the requested slide
                ISlide slide = pres.Slides[slideIndex];

                // Create a full‑scale image of the slide
                IImage image = slide.GetImage(1f, 1f);

                // Save the image to a memory stream in JPEG format
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, Aspose.Slides.ImageFormat.Jpeg);
                    byte[] imageBytes = ms.ToArray();

                    // Convert the image bytes to a Base64 string
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Output the Base64 string (can be embedded in HTML)
                    Console.WriteLine("data:image/jpeg;base64," + base64String);
                }

                // Save the presentation before exiting (as required)
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported file format here
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
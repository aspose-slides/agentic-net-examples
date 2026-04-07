using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideConversionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = "input.pptx";
            string outputPresentationPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Define scaling factors
            int scaleX = 2;
            int scaleY = scaleX;

            // Load presentation with exception handling for unsupported formats
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // format not supported
                Console.WriteLine("File format not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Export each slide to JPEG with custom scale and validate dimensions
            foreach (ISlide slide in presentation.Slides)
            {
                using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
                {
                    string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
                    thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);

                    // Validate image dimensions
                    using (Image img = Image.FromFile(imageFileName))
                    {
                        int expectedWidth = (int)(presentation.SlideSize.Size.Width * scaleX);
                        int expectedHeight = (int)(presentation.SlideSize.Size.Height * scaleY);

                        if (img.Width == expectedWidth && img.Height == expectedHeight)
                        {
                            Console.WriteLine($"{imageFileName}: dimensions OK ({img.Width}x{img.Height})");
                        }
                        else
                        {
                            Console.WriteLine($"{imageFileName}: dimensions mismatch. Expected {expectedWidth}x{expectedHeight}, got {img.Width}x{img.Height}");
                        }
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save(outputPresentationPath, SaveFormat.Pptx);
        }
    }
}
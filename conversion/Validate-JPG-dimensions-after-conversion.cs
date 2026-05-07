using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateJpgDimensions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Desired output dimensions in pixels
                    int desiredWidth = 1200;
                    int desiredHeight = 800;

                    // Calculate scaling factors based on slide size (points)
                    float scaleX = (float)desiredWidth / pres.SlideSize.Size.Width;
                    float scaleY = (float)desiredHeight / pres.SlideSize.Size.Height;

                    // Process each slide
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];

                        // Generate JPEG image with custom scaling
                        IImage bmp = slide.GetImage(scaleX, scaleY);
                        string jpgPath = $"Slide_{i + 1}.jpg";
                        bmp.Save(jpgPath, Aspose.Slides.ImageFormat.Jpeg);

                        // Validate dimensions of the saved JPEG
                        using (Image img = Image.FromFile(jpgPath))
                        {
                            int actualWidth = img.Width;
                            int actualHeight = img.Height;

                            if (actualWidth != desiredWidth || actualHeight != desiredHeight)
                            {
                                Console.WriteLine($"Dimension mismatch in {jpgPath}: Expected {desiredWidth}x{desiredHeight}, Got {actualWidth}x{actualHeight}");
                            }
                            else
                            {
                                Console.WriteLine($"{jpgPath} dimensions are as expected.");
                            }
                        }
                    }

                    // Save the presentation before exiting
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
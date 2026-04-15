using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToPngExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = "input.pptx";
            string outputImagePath = "slide1.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Desired dimensions for the PNG image
                    int desiredWidth = 1200;
                    int desiredHeight = 800;

                    // Calculate scaling factors based on slide size
                    float scaleX = (float)(1.0 / presentation.SlideSize.Size.Width) * desiredWidth;
                    float scaleY = (float)(1.0 / presentation.SlideSize.Size.Height) * desiredHeight;

                    // Get the image of the first slide with custom scaling
                    IImage slideImage = presentation.Slides[0].GetImage(scaleX, scaleY);

                    // Save the image as PNG
                    slideImage.Save(outputImagePath, ImageFormat.Png);

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
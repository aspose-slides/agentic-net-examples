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
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "slide1.png";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Desired dimensions for the PNG image
                int desiredWidth = 1200;
                int desiredHeight = 800;

                // Calculate scaling factors based on slide size
                float scaleX = (float)(1.0 / presentation.SlideSize.Size.Width) * desiredWidth;
                float scaleY = (float)(1.0 / presentation.SlideSize.Size.Height) * desiredHeight;

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Generate the image with custom scaling
                Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY);

                // Save the image as PNG
                image.Save(outputPath, Aspose.Slides.ImageFormat.Png);

                // Dispose the image object
                image.Dispose();

                // Save the presentation before exiting (no modifications made)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("First slide saved as PNG to: " + outputPath);
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
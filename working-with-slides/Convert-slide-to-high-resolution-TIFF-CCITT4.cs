using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "slide1.tiff";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Select the first slide (index 0)
                ISlide slide = presentation.Slides[0];

                // Configure TIFF options with CCITT4 compression and high resolution
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.CompressionType = TiffCompressionTypes.CCITT4;
                tiffOptions.BwConversionMode = BlackWhiteConversionMode.Dithering;
                tiffOptions.DpiX = 300;
                tiffOptions.DpiY = 300;

                // Render the slide to a TIFF image using the options
                using (IImage tiffImage = slide.GetImage(tiffOptions))
                {
                    tiffImage.Save(outputPath, Aspose.Slides.ImageFormat.Tiff);
                }

                // Save the presentation before exiting
                presentation.Save(inputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
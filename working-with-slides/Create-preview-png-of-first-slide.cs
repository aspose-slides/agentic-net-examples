using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PreviewGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output PNG preview path
            string previewPath = "slide1.png";
            // Output presentation path (saved before exit)
            string outputPresPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                // Input file not found; exit the program
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide firstSlide = pres.Slides[0];

                    // Generate a thumbnail image of the first slide
                    using (IImage thumbnail = firstSlide.GetImage())
                    {
                        // Save the thumbnail as PNG
                        thumbnail.Save(previewPath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation before exiting
                    pres.Save(outputPresPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // The file format is not supported
                Console.WriteLine("The presentation format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
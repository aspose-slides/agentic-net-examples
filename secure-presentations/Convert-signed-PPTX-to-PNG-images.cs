using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertSignedPresentationToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the signed presentation file
            string inputPath = "signed.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the signed presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through each slide and export it as PNG
                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        ISlide slide = pres.Slides[index];

                        // GetImage returns an IImage (thumbnail of the slide)
                        using (IImage slideImage = slide.GetImage())
                        {
                            string outputPath = $"slide_{index + 1}.png";
                            slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the presentation (required before exiting)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for conversion.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
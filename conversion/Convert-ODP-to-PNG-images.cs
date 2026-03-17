using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OdpToPngConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source ODP file
            string inputPath = "input.odp";

            // Ensure proper exception handling
            try
            {
                // Load the ODP presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through each slide and save as PNG
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        // Get the slide
                        ISlide slide = presentation.Slides[index];

                        // Generate thumbnail image for the slide
                        using (IImage image = slide.GetImage())
                        {
                            // Define output file name
                            string outputFile = $"slide_{index}.png";

                            // Save the image as PNG using fully qualified ImageFormat
                            image.Save(outputFile, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the presentation before exiting (optional re-save)
                    presentation.Save("output.odp", Aspose.Slides.Export.SaveFormat.Odp);
                }
            }
            catch (Exception ex)
            {
                // Output error information
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation, thumbnail output, and saved presentation
            string inputPath = "input.pptx";
            string thumbnailPath = "thumbnail.png";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Set default Asian font via LoadOptions
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DefaultAsianFont = "Arial Unicode MS";

                // Load the presentation with the specified load options
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Generate a thumbnail image using GetImage (GetThumbnail is not available)
                    IImage thumbnail = slide.GetImage(1f, 1f);
                    thumbnail.Save(thumbnailPath, Aspose.Slides.ImageFormat.Png);

                    // Save the presentation before exiting (optional, demonstrates lifecycle rule)
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
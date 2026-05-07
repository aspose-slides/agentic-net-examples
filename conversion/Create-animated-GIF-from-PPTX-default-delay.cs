using System;
using System.IO;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "presentation.pptx";
            string outputPath = "animation.gif";

            // Check if the input PPTX file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Create GIF options with default settings (default loop count and frame delay)
                Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();

                // Save the presentation as an animated GIF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Animated GIF created successfully.");
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported file format
                // Format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
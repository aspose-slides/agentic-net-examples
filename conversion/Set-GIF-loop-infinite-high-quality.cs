using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GifConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Create custom GifOptions
                GifOptions gifOptions = new GifOptions();

                // NOTE: Loop count and quality level are not exposed in the current GifOptions API.
                // These settings are not supported; therefore they cannot be set programmatically.

                // Save the presentation as GIF using the custom options
                presentation.Save(outputPath, SaveFormat.Gif, gifOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation successfully saved as GIF: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GifFromOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input ODP file and output GIF paths
            string inputPath = "presentation.odp";
            string outputPath = "presentation.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the ODP presentation
                Presentation presentation = new Presentation(inputPath);

                // Save as animated GIF using default options (default delay and loop settings)
                presentation.Save(outputPath, SaveFormat.Gif, new GifOptions());

                // Ensure the presentation is saved before exiting
                presentation.Dispose();

                Console.WriteLine("Animated GIF created successfully at: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
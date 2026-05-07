using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if a file path argument is provided
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to a presentation file.");
                return;
            }

            string inputPath = args[0];

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("The specified file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Get the number of slides
                int slideCount = pres.Slides.Count;

                Console.WriteLine("Number of slides: " + slideCount);

                // Save the presentation before exiting (preserve original format if possible)
                pres.Save(inputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
                // Format not supported
            }
        }
    }
}
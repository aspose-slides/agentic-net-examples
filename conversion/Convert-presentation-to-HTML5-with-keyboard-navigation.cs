using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Html5ConversionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Save the presentation as HTML5.
                // Arrow key navigation is enabled by default in the generated HTML5 output.
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5);

                // Release resources
                presentation.Dispose();

                Console.WriteLine("Presentation successfully converted to HTML5.");
            }
            catch (Exception ex)
            {
                // If the format is not supported, Aspose.Slides will throw an exception.
                // Comment: format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
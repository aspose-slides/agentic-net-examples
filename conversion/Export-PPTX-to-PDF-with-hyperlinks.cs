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
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Save as PDF preserving hyperlinks (default behavior)
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

                // Release resources
                presentation.Dispose();

                Console.WriteLine("Presentation successfully saved as PDF.");
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                // format not supported
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
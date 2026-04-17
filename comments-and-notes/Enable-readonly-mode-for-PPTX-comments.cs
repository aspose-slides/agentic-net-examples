using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReadOnlyCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_readonly.pptx");

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

                // Enable read‑only recommendation (prevents editing of comments)
                presentation.ProtectionManager.ReadOnlyRecommended = true;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation saved in read‑only mode: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
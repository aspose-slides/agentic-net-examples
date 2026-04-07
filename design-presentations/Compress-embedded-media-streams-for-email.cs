using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompressMediaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_compressed.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation with options to delete embedded binary objects (audio, video, etc.)
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DeleteEmbeddedBinaryObjects = true; // Removes binary objects to reduce size

                Presentation presentation = new Presentation(inputPath, loadOptions);

                // Save the optimized presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation compressed and saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for compression.
                Console.WriteLine("The file format is not supported for compression.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
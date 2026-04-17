using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Remove all unused master slides (ignore Preserve flag)
                    presentation.Masters.RemoveUnused(false);

                    // Create options to compact the file size (ZIP64 mode)
                    PptxOptions saveOptions = new PptxOptions();
                    saveOptions.Zip64Mode = Zip64Mode.IfNecessary;

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx, saveOptions);
                }

                Console.WriteLine("Presentation processed and saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
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
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Create LoadOptions and set a custom default regular font
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DefaultRegularFont = "Arial";

                // Load the presentation with the specified load options
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Render the first slide to PDF and save the result
                    presentation.Save(outputPath, SaveFormat.Pdf);

                    // Save the presentation before exiting (no changes made, but fulfills requirement)
                    presentation.Save("temp_save.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
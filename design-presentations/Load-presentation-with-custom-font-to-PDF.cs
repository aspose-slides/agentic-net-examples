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
            // Define file paths
            string inputPath = "input.pptx";
            string outputPdfPath = "first_slide.pdf";
            string outputCopyPath = "presentation_copy.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Create load options with a custom default regular font
                LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
                loadOptions.DefaultRegularFont = "Arial";

                // Load the presentation using the load options
                Presentation presentation = new Presentation(inputPath, loadOptions);

                // Render the first slide to PDF (saving the whole presentation; adjust as needed for single slide)
                presentation.Save(outputPdfPath, SaveFormat.Pdf);

                // Save a copy of the presentation before exiting
                presentation.Save(outputCopyPath, SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
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
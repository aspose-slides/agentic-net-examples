using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToHtml5LazyImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output HTML5 file path
            string outputPath = "output.html";
            // Folder where external resources (images, scripts, etc.) will be stored
            string resourcesFolder = "output_resources";

            // Verify that the input file exists
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
                    // Configure HTML5 export options for lazy loading (do not embed images)
                    Html5Options html5Options = new Html5Options
                    {
                        EmbedImages = false,          // Images will be saved as external files
                        OutputPath = resourcesFolder  // Specify folder for external resources
                    };

                    // Ensure the resources folder exists
                    if (!Directory.Exists(resourcesFolder))
                    {
                        Directory.CreateDirectory(resourcesFolder);
                    }

                    // Save the presentation as HTML5
                    presentation.Save(outputPath, SaveFormat.Html5, html5Options);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
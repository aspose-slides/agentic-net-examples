using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesHtml5Export
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = "presentation.pptx";
            string outputFolder = "Html5Output";
            string outputPath = Path.Combine(outputFolder, "presentation.html");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure HTML5 export options
                Html5Options html5Options = new Html5Options();
                html5Options.AnimateShapes = true;
                html5Options.AnimateTransitions = true;
                html5Options.OutputPath = outputFolder; // Store external resources here

                // Export to HTML5
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, html5Options);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Export completed successfully. HTML5 files are located at: " + outputFolder);
                // The generated HTML5 can be served and loaded in a React component using an <iframe> or by fetching the HTML file.
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred during export: " + ex.Message);
                // If the format is not supported, the exception will be caught here.
            }
        }
    }
}
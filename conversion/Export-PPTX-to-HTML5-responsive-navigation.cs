using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationToHtml5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

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

                // Configure HTML5 export options with responsive layout and JavaScript navigation
                Html5Options html5Options = new Html5Options();
                // Enable embedding of images (can be adjusted as needed)
                html5Options.EmbedImages = true;
                // Set output path for external resources (optional)
                html5Options.OutputPath = Directory.GetCurrentDirectory();
                // Ensure JavaScript links are not skipped to keep interactive navigation
                html5Options.SkipJavaScriptLinks = false;

                // Note: Responsive layout for SVG is handled automatically in HTML5 export.
                // Save the presentation as HTML5
                presentation.Save(outputPath, SaveFormat.Html5, html5Options);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation exported successfully to HTML5.");
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported format exception
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (including possible web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
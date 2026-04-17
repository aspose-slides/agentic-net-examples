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

                // Configure HTML5 export options
                Html5Options html5Options = new Html5Options();
                html5Options.EmbedImages = true;               // Embed images into the HTML5 output
                html5Options.SkipJavaScriptLinks = false;      // Ensure JavaScript links are retained

                // Save the presentation as HTML5 with responsive layout (SVG responsive layout is handled internally)
                presentation.Save(outputPath, SaveFormat.Html5, html5Options);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation exported successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network issues if external resources are accessed)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
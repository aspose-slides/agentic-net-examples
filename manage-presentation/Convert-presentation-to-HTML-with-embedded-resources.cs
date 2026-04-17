using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesHtmlExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Create controller to embed all fonts
                string[] fontExclude = new string[0];
                EmbedAllFontsHtmlController embedController = new EmbedAllFontsHtmlController(fontExclude);

                // Set HTML options with custom formatter
                HtmlOptions htmlOptions = new HtmlOptions
                {
                    HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedController)
                };

                // Save as single HTML file with embedded resources
                presentation.Save(outputPath, SaveFormat.Html, htmlOptions);

                // Dispose presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment: // format not supported
            }
        }
    }
}
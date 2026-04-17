using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

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
                    // Create HTML export options
                    HtmlOptions htmlOptions = new HtmlOptions();

                    // Use a custom formatter that embeds all fonts as base64 data URIs
                    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController();
                    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController);

                    // Save the presentation as a single HTML file with embedded fonts
                    presentation.Save(outputPath, SaveFormat.Html, htmlOptions);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // The file format is not supported for conversion
                Console.WriteLine("The provided file format is not supported for HTML export.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, permission issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
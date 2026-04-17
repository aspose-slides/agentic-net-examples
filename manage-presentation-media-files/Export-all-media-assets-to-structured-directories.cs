using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MediaExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Prepare output directory
            string outputDir = Path.Combine(Environment.CurrentDirectory, "ExportedMedia");
            Directory.CreateDirectory(outputDir);

            // HTML export settings
            string htmlFileName = "presentation.html";
            string baseUri = "";

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Create controller for exporting media files
                VideoPlayerHtmlController controller = new VideoPlayerHtmlController(outputDir, htmlFileName, baseUri);

                // Set up HTML and SVG options
                HtmlOptions htmlOptions = new HtmlOptions(controller);
                SVGOptions svgOptions = new SVGOptions(controller);
                htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
                htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

                // Save presentation as HTML; media files (audio, images, flash) will be exported to the output directory
                pres.Save(Path.Combine(outputDir, htmlFileName), SaveFormat.Html, htmlOptions);

                // Ensure presentation is saved before exit
                pres.Dispose();

                Console.WriteLine("Media assets exported successfully to: " + outputDir);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for export.");
            }
            catch (System.Net.WebException)
            {
                // Handle external URL or web service errors
                Console.WriteLine("An error occurred while accessing external resources.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
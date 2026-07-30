// -----------------------------------------------------------------------------
// Example: Export all media assets to structured directories using C#
//
// Description:
// Demonstrates how to export all media assets (images, audio, video, flash) from a PowerPoint presentation to a structured directory using Aspose.Slides for .NET. The example loads a PPTX file, configures HTML export with a VideoPlayerHtmlController, and saves the presentation as HTML, causing all embedded media files to be written to the specified output folder.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Export, Media Assets, Structured Directories, HTML Export, VideoPlayerHtmlController, Presentation Processing
//
// Use Cases:
// - Automate extraction of embedded media from PPTX files.
// - Build tools that organize presentation assets for reuse or analysis.
// - Integrate media export functionality into .NET applications.
// - Prepare media assets for web publishing or content management systems.
// -----------------------------------------------------------------------------
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

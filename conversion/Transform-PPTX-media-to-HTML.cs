using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TransformPptxMediaToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input presentation path
                string dataDir = @"C:\Input";
                string inputFile = Path.Combine(dataDir, "presentation.pptx");

                // Output directory for HTML and media files
                string outputDir = @"C:\Output";
                Directory.CreateDirectory(outputDir);

                // HTML file name and base URI for media links
                const string htmlFileName = "presentation.html";
                const string baseUri = "";

                // Controller to handle video and audio export
                VideoPlayerHtmlController controller = new VideoPlayerHtmlController(outputDir, htmlFileName, baseUri);

                // HTML export options with custom formatter
                HtmlOptions htmlOptions = new HtmlOptions(controller);
                SVGOptions svgOptions = new SVGOptions(controller);
                htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
                htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

                // Load presentation and save as HTML with media files
                Presentation presentation = new Presentation(inputFile);
                presentation.Save(Path.Combine(outputDir, htmlFileName), SaveFormat.Html, htmlOptions);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
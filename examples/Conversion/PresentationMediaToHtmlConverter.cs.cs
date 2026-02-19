using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path
        string dataDir = "C:\\Data\\";
        string inputFile = Path.Combine(dataDir, "input.pptx");

        // Output directory and HTML file name
        string outputDir = "C:\\Output\\";
        Directory.CreateDirectory(outputDir);
        const string htmlFileName = "presentation.html";
        const string baseUri = "http://example.com/media/";

        // Create controller for exporting media files
        VideoPlayerHtmlController controller = new VideoPlayerHtmlController(outputDir, htmlFileName, baseUri);

        // Set up HTML export options with custom formatter and SVG slide images
        HtmlOptions htmlOptions = new HtmlOptions(controller);
        SVGOptions svgOptions = new SVGOptions(controller);
        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
        htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

        // Load the presentation
        Presentation pres = new Presentation(inputFile);

        // Save presentation as HTML with media files
        pres.Save(Path.Combine(outputDir, htmlFileName), SaveFormat.Html, htmlOptions);

        // Clean up
        pres.Dispose();
    }
}
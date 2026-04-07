using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputHtml = "output.html";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);

            // Create HTML controller for embedding SVG graphics
            VideoPlayerHtmlController controller = new VideoPlayerHtmlController(string.Empty, outputHtml, string.Empty);
            HtmlOptions htmlOptions = new HtmlOptions(controller);
            SVGOptions svgOptions = new SVGOptions(controller);

            htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
            htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

            // Save presentation as HTML with embedded SVG
            presentation.Save(outputHtml, SaveFormat.Html, htmlOptions);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
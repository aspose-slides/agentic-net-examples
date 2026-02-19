using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PptToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            // Output HTML file path (contains SVG images for each slide)
            string outputPath = Path.Combine(dataDir, "output.html");

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Configure HTML options to use SVG for slide images
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());

            // Save the presentation as HTML with embedded SVG images
            pres.Save(outputPath, SaveFormat.Html, htmlOptions);

            // Dispose the presentation object
            pres.Dispose();
        }
    }
}
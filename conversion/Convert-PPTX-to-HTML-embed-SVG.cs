using System;
using System.IO;
using Aspose.Slides.Export;

namespace ConvertPptxToHtmlSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";
            // Output directory for HTML and resources
            string outputDir = "output";
            // Full path of the resulting HTML file
            string outputHtml = Path.Combine(outputDir, "presentation.html");

            try
            {
                // Ensure output directory exists
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure HTML export options to embed images as scalable SVG
                Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
                Aspose.Slides.Export.SVGOptions svgOptions = new Aspose.Slides.Export.SVGOptions();
                htmlOptions.SlideImageFormat = Aspose.Slides.Export.SlideImageFormat.Svg(svgOptions);

                // Save the presentation as HTML with embedded SVG images
                presentation.Save(outputHtml, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

                // Dispose the presentation object
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Output any errors that occur during conversion
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
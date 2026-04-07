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
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Configure HTML export options to use inline SVG for vector shapes
                Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
                Aspose.Slides.Export.SVGOptions svgOptions = new Aspose.Slides.Export.SVGOptions();
                Aspose.Slides.Export.SlideImageFormat slideImageFormat = Aspose.Slides.Export.SlideImageFormat.Svg(svgOptions);
                htmlOptions.SlideImageFormat = slideImageFormat;

                // Save the presentation as HTML with the configured options
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("Presentation exported to HTML successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for export.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
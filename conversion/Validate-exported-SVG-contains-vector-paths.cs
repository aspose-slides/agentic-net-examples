using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgValidationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputSvgPath = Path.Combine(Directory.GetCurrentDirectory(), "slide_1.svg");
            string outputPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Set SVG options to vectorize text (keep text as vector paths)
                SVGOptions options = new SVGOptions();
                options.VectorizeText = true;

                // Export first slide to SVG with options
                using (FileStream svgStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                {
                    pres.Slides[0].WriteAsSvg(svgStream, options);
                }

                // Simple validation: check for presence of <path> and text elements in SVG
                string svgContent = File.ReadAllText(outputSvgPath);
                bool containsPath = svgContent.Contains("<path");
                bool containsText = svgContent.Contains("<text") || svgContent.Contains("<tspan");

                if (containsPath && containsText)
                {
                    Console.WriteLine("SVG contains vector paths for shapes and text.");
                }
                else
                {
                    Console.WriteLine("SVG validation failed: missing vector paths or text elements.");
                }

                // Save the presentation before exit
                pres.Save(outputPresentationPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for unsupported file formats if needed
            }
        }
    }
}
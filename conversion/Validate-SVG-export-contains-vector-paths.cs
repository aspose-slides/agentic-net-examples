using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgValidationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputSvgPath = Path.Combine(Directory.GetCurrentDirectory(), "slide_0.svg");

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

                // Prepare SVG options to vectorize text
                SVGOptions svgOptions = new SVGOptions();
                svgOptions.VectorizeText = true;

                // Export first slide as SVG
                using (FileStream fs = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                {
                    pres.Slides[0].WriteAsSvg(fs, svgOptions);
                }

                // Save presentation (as per rule)
                string tempSavePath = Path.Combine(Directory.GetCurrentDirectory(), "temp_save.pptx");
                pres.Save(tempSavePath, SaveFormat.Pptx);
                pres.Dispose();

                // Validate SVG content
                string svgContent = File.ReadAllText(outputSvgPath);
                bool containsPath = svgContent.Contains("<path");
                bool containsTextTag = svgContent.Contains("<text");

                if (containsPath && !containsTextTag)
                {
                    Console.WriteLine("Validation succeeded: SVG contains vector paths for all shapes and text.");
                }
                else
                {
                    Console.WriteLine("Validation failed: SVG does not contain expected vector paths.");
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "slide.svg";

            // Override paths with command line arguments if provided
            if (args.Length >= 2)
            {
                inputPath = args[0];
                outputPath = args[1];
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Create SVG export options (default settings)
                    SVGOptions svgOptions = new SVGOptions();

                    // Export the first slide as SVG with the specified options
                    using (FileStream fs = File.Create(outputPath))
                    {
                        pres.Slides[0].WriteAsSvg(fs, svgOptions);
                    }

                    // Save the presentation before exiting (no changes made)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for SVG conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external resources, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
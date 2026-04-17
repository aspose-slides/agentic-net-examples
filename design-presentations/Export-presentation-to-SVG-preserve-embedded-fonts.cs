using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation path and output directory
            string inputPath = "input.pptx";
            string outputDirectory = "output";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure SVG options to embed fonts and preserve theme colors
                SVGOptions svgOptions = new SVGOptions();
                svgOptions.ExternalFontsHandling = SvgExternalFontsHandling.Embed;

                // Export each slide to an individual SVG file
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    string slideFilePath = Path.Combine(outputDirectory, $"slide_{i + 1}.svg");
                    using (FileStream fileStream = File.Create(slideFilePath))
                    {
                        presentation.Slides[i].WriteAsSvg(fileStream, svgOptions);
                    }
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save("saved_output.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
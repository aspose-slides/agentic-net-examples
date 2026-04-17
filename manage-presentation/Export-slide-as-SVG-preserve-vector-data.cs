using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output SVG file path
            string outputPath = "slide_1.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Export the first slide to SVG
                    using (FileStream svgStream = File.Create(outputPath))
                    {
                        presentation.Slides[0].WriteAsSvg(svgStream);
                    }

                    // Save the presentation before exiting (as per lifecycle rule)
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Slide exported successfully to SVG: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
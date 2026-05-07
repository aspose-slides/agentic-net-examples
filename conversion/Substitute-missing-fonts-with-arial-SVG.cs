using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesSvgConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputDirectory = "output_svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure SVG options with fallback font Arial
                    SVGOptions svgOptions = new SVGOptions();
                    svgOptions.DefaultRegularFont = "Arial";

                    // Convert each slide to SVG
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        string svgPath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");
                        using (FileStream svgStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(svgStream, svgOptions);
                        }
                    }

                    // Save the presentation before exiting (optional, can be same as input)
                    string savedPath = "saved_presentation.pptx";
                    presentation.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
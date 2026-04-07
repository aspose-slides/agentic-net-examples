using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputFolder = "output";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation with default font fallback to Arial
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DefaultRegularFont = "Arial";

                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Ensure output directory exists
                    if (!Directory.Exists(outputFolder))
                    {
                        Directory.CreateDirectory(outputFolder);
                    }

                    // Convert each slide to SVG using Arial as fallback font
                    int slideCount = presentation.Slides.Count;
                    for (int i = 0; i < slideCount; i++)
                    {
                        string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                        using (FileStream svgStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                        {
                            SVGOptions svgOptions = new SVGOptions();
                            svgOptions.DefaultRegularFont = "Arial";
                            presentation.Slides[i].WriteAsSvg(svgStream, svgOptions);
                        }
                    }

                    // Save the presentation before exiting (optional, as we only performed conversion)
                    string tempSavePath = Path.Combine(outputFolder, "presentation_saved.pptx");
                    presentation.Save(tempSavePath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for SVG conversion.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
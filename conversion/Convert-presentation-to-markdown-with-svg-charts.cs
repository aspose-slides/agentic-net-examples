using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToMarkdown
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputMarkdownPath = "output.md";
            string outputImagesFolder = "output_images";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output folder exists
            Directory.CreateDirectory(outputImagesFolder);

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    StringBuilder markdownBuilder = new StringBuilder();

                    // Iterate through slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];
                        string svgFileName = $"slide_{i + 1}.svg";
                        string svgFilePath = Path.Combine(outputImagesFolder, svgFileName);

                        // Export slide as SVG (charts inside will be vector graphics)
                        using (FileStream svgStream = new FileStream(svgFilePath, FileMode.Create, FileAccess.Write))
                        {
                            slide.WriteAsSvg(svgStream);
                        }

                        // Append markdown for this slide
                        markdownBuilder.AppendLine($"## Slide {i + 1}");
                        markdownBuilder.AppendLine();
                        markdownBuilder.AppendLine($"![Slide {i + 1}]({svgFilePath})");
                        markdownBuilder.AppendLine();
                    }

                    // Write markdown to file
                    File.WriteAllText(outputMarkdownPath, markdownBuilder.ToString());

                    // Save presentation before exit (as per rule)
                    presentation.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
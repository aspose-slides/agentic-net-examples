using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input presentation path and output directory for SVG files
        string inputPath = "input.pptx";
        string outputDir = "output_svgs";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Convert each slide to an individual SVG file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                string svgFilePath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (FileStream fileStream = File.Create(svgFilePath))
                {
                    presentation.Slides[i].WriteAsSvg(fileStream);
                }
            }

            // Save the presentation before exiting (no modifications made)
            presentation.Save(inputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
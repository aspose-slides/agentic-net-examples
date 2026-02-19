using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file path
        string inputPath = "input.pptx";
        // Output directory for SVG files
        string outputDir = "output";

        // Override paths with command line arguments if provided
        if (args.Length >= 1)
        {
            inputPath = args[0];
        }
        if (args.Length >= 2)
        {
            outputDir = args[1];
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Iterate through each slide and save it as an SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (FileStream fs = new FileStream(svgPath, FileMode.Create))
                {
                    // Create default SVG options
                    SVGOptions svgOptions = new SVGOptions();

                    // Save the current slide as SVG using the slide image format API
                    pres.Slides[i].WriteAsSvg(fs, svgOptions);
                }
            }
        }
    }
}
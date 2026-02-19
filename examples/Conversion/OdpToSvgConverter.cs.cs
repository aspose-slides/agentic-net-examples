using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input ODP file path (default value can be overridden by command line argument)
        string inputPath = "input.odp";
        // Output directory for SVG files (default value can be overridden by command line argument)
        string outputDir = "output";

        if (args.Length >= 1)
        {
            inputPath = args[0];
        }
        if (args.Length >= 2)
        {
            outputDir = args[1];
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the ODP presentation
        Presentation pres = new Presentation(inputPath);

        // Convert each slide to an individual SVG file
        int slideCount = pres.Slides.Count;
        for (int i = 0; i < slideCount; i++)
        {
            string svgFilePath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
            using (FileStream fs = new FileStream(svgFilePath, FileMode.Create))
            {
                SVGOptions svgOptions = new SVGOptions();
                pres.Slides[i].WriteAsSvg(fs, svgOptions);
            }
        }

        // Save the presentation (required by lifecycle rule)
        string savedPresentationPath = Path.Combine(outputDir, "saved.pptx");
        pres.Save(savedPresentationPath, SaveFormat.Pptx);
    }
}
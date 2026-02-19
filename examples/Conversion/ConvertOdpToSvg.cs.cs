using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OdpToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input ODP file path (first argument) or default
            string inputPath = args.Length > 0 ? args[0] : "input.odp";

            // Output directory for SVG files (second argument) or default
            string outputDir = args.Length > 1 ? args[1] : "output";

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the ODP presentation
            Presentation pres = new Presentation(inputPath);

            // Convert each slide to an individual SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                string svgFilePath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (FileStream svgStream = new FileStream(svgFilePath, FileMode.Create))
                {
                    pres.Slides[i].WriteAsSvg(svgStream);
                }
            }

            // Save the presentation (required before exit)
            string savedPresentationPath = Path.Combine(outputDir, "converted.pptx");
            pres.Save(savedPresentationPath, SaveFormat.Pptx);
        }
    }
}
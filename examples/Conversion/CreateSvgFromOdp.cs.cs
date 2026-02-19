using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input ODP file
        string inputPath = "input.odp";
        // Directory where SVG files will be saved
        string outputDir = "output_svg";

        // Create output directory if it does not exist
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the ODP presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Export each slide to a separate SVG file
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
            using (FileStream outStream = new FileStream(svgPath, FileMode.Create))
            {
                pres.Slides[i].WriteAsSvg(outStream);
            }
        }

        // Save the presentation (optional, no modifications made)
        string savedPath = Path.Combine(outputDir, "saved.odp");
        pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Odp);
    }
}
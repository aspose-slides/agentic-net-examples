using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input ODP file path
        string inputPath = "input.odp";
        // Output folder for SVG files
        string outputFolder = "output_svg";

        if (args.Length >= 1)
        {
            inputPath = args[0];
        }
        if (args.Length >= 2)
        {
            outputFolder = args[1];
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Load the ODP presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Convert each slide to SVG
        int slideIndex = 0;
        foreach (Aspose.Slides.ISlide slide in pres.Slides)
        {
            string svgPath = Path.Combine(outputFolder, "slide_" + slideIndex + ".svg");
            using (FileStream outStream = new FileStream(svgPath, FileMode.Create))
            {
                slide.WriteAsSvg(outStream);
            }
            slideIndex++;
        }

        // Save the presentation (optional)
        string savedPath = Path.Combine(outputFolder, "saved.odp");
        pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Odp);
    }
}
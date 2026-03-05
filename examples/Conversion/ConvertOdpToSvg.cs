using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source ODP file
        string inputPath = "input.odp";

        // Directory where SVG files will be saved
        string outputDir = "output_svg";
        Directory.CreateDirectory(outputDir);

        // Load the ODP presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides and export each as SVG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (FileStream fs = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fs);
                }
            }

            // Save the presentation before exiting (optional, here saving to a new file)
            pres.Save("saved_output.odp", Aspose.Slides.Export.SaveFormat.Odp);
        }
    }
}
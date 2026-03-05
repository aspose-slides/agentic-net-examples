using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the source ODP file
        string inputPath = "input.odp";
        // Directory where SVG files will be saved
        string outputDir = "output_svgs";

        // Create output directory if it does not exist
        Directory.CreateDirectory(outputDir);

        // Load the ODP presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides and save each as an SVG file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (FileStream fileStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation before exiting (optional)
            presentation.Save("saved_output.odp", Aspose.Slides.Export.SaveFormat.Odp);
        }
    }
}
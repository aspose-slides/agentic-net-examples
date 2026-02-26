using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the source PowerPoint file
        var inputPath = "input.pptx";
        // Directory where SVG files will be saved
        var outputDir = "output_svgs";

        // Create output directory if it does not exist
        Directory.CreateDirectory(outputDir);

        // Load the presentation
        using (var pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides and save each as SVG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                var slide = pres.Slides[i];
                var svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (var stream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(stream);
                }
            }

            // Save the presentation before exiting
            pres.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
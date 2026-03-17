using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input ODP file path
            var inputPath = "input.odp";
            // Directory to store generated SVG files
            var outputDir = "output_svgs";
            Directory.CreateDirectory(outputDir);

            // Load the ODP presentation
            using (var pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides and save each as SVG
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    var svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                    using (var fileStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                    {
                        pres.Slides[i].WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation (optional, ensures any changes are persisted)
                pres.Save("output.odp", Aspose.Slides.Export.SaveFormat.Odp);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
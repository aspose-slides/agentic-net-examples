using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source ODP file
        string inputPath = "sample.odp";

        // Directory where SVG files will be saved
        string outputDir = "SvgOutput";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the ODP presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Convert each slide to an SVG file
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            string svgFilePath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
            using (FileStream fileStream = File.Create(svgFilePath))
            {
                slide.WriteAsSvg(fileStream);
            }
        }

        // Save the presentation (required by authoring rules)
        string savedPresentationPath = "saved_output.pptx";
        presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}
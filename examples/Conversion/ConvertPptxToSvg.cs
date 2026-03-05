using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";

        // Directory where SVG files will be saved
        string outputDir = "output_svgs";
        Directory.CreateDirectory(outputDir);

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Convert each slide to an SVG file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string svgFilePath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (FileStream svgStream = File.Create(svgFilePath))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
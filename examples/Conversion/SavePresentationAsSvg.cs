using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Directory to store SVG files
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation (required before exit)
            presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Iterate through all slides and save each as SVG
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");

                using (FileStream fileStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }
        }
    }
}
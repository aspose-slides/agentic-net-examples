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
            // Iterate through all slides
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                // Get the current slide
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Define SVG file name for the slide
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");

                // Save the slide as SVG
                using (FileStream fileStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation before exiting (optional: overwrite or new file)
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}
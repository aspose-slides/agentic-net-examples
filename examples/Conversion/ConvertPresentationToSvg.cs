using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string inputPath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides and save each as an SVG file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string svgFileName = $"slide_{i + 1}.svg";

                using (FileStream svgStream = File.Create(svgFileName))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
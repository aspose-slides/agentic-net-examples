using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input PPTX file
        string inputPath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides and save each as an SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                ISlide slide = pres.Slides[i];
                string svgPath = $"slide_{i + 1}.svg";

                using (FileStream svgStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the presentation before exiting (no modifications made)
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides and save each as an SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                string svgPath = $"slide_{i + 1}.svg";

                // Create a file stream for the SVG output
                using (FileStream fs = File.Create(svgPath))
                {
                    // Write the slide content as SVG
                    slide.WriteAsSvg(fs);
                }
            }

            // Save the presentation (no modifications) before exiting
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
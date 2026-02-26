using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
        {
            // Iterate through all slides and save each as an SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                // Define the SVG file name for the current slide
                string svgPath = $"slide_{i + 1}.svg";

                // Create a file stream for the SVG output
                using (FileStream svgStream = File.Create(svgPath))
                {
                    // Write the slide content to the SVG stream
                    pres.Slides[i].WriteAsSvg(svgStream);
                }
            }

            // Save the presentation (required before exiting)
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
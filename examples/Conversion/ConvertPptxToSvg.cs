using System;
using System.IO;

namespace AsposeSlidesSvgConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string sourcePath = "input.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Iterate through all slides
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    // Get the current slide
                    Aspose.Slides.ISlide slide = presentation.Slides[index];

                    // Define the output SVG file name
                    string svgPath = $"slide_{index + 1}.svg";

                    // Create a file stream for the SVG output
                    using (FileStream svgStream = File.Create(svgPath))
                    {
                        // Write the slide as SVG
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the presentation (no modifications made)
                presentation.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
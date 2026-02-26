using System;
using System.IO;
using Aspose.Slides;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string sourcePath = "input.pptx";

            // Load the presentation
            using (Presentation pres = new Presentation(sourcePath))
            {
                // Iterate through all slides
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    // Get the current slide
                    ISlide slide = pres.Slides[i];

                    // Create SVG file name for the slide
                    string svgPath = $"slide_{i}.svg";

                    // Create a file stream to write the SVG
                    using (FileStream svgStream = File.Create(svgPath))
                    {
                        // Save the slide as SVG
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the presentation (required by authoring rules)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
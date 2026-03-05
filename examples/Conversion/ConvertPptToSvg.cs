using System;
using System.IO;

namespace AsposeSlidesSvgConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Load the presentation using the Aspose.Slides constructor
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides and save each as an SVG file
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    string svgPath = $"slide_{i + 1}.svg";

                    using (FileStream svgStream = File.Create(svgPath))
                    {
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
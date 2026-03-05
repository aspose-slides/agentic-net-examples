using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgExportExample
{
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
                for (int index = 0; index < pres.Slides.Count; index++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[index];
                    string svgPath = $"slide_{index + 1}.svg";

                    using (FileStream svgStream = File.Create(svgPath))
                    {
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the (unchanged) presentation before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
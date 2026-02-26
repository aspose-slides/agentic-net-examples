using System;
using System.IO;
using Aspose.Slides;

namespace PPTXToSVG
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path (use first argument or default)
            string inputPath = (args.Length > 0) ? args[0] : "input.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides and save each as SVG
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    string svgPath = $"slide_{i + 1}.svg";

                    using (FileStream svgStream = File.Create(svgPath))
                    {
                        slide.WriteAsSvg(svgStream);
                    }
                }

                // Save the presentation before exiting (optional output)
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
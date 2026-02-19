using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPptxPath = "input.pptx";

            // Output directory for SVG files
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);

            // Load the presentation
            Presentation pres = new Presentation(inputPptxPath);

            // Convert each slide to SVG
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                // Build SVG file path for the current slide
                string svgFilePath = Path.Combine(outputDirectory, $"slide_{slideIndex + 1}.svg");

                // Create a file stream for writing the SVG
                using (FileStream svgStream = new FileStream(svgFilePath, FileMode.Create, FileAccess.Write))
                {
                    // SVG export options (default settings)
                    SVGOptions svgOptions = new SVGOptions();

                    // Export the slide as SVG
                    pres.Slides[slideIndex].WriteAsSvg(svgStream, svgOptions);
                }
            }

            // Save the presentation (as required by authoring rules)
            string savedPptxPath = Path.Combine(outputDirectory, "saved.pptx");
            pres.Save(savedPptxPath, SaveFormat.Pptx);
        }
    }
}
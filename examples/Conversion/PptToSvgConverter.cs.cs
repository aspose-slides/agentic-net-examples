using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file path
            string inputPptPath = "input.pptx";
            // Output directory for SVG files
            string outputDir = "output_svg";

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPptPath);

            // Iterate through each slide and save as SVG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                // Create SVG options (using default settings)
                SVGOptions svgOptions = new SVGOptions();

                // Define output SVG file path
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");

                // Save the slide as SVG
                using (FileStream svgStream = new FileStream(svgPath, FileMode.Create))
                {
                    // Write the slide to the SVG stream
                    pres.Slides[i].WriteAsSvg(svgStream, svgOptions);
                }
            }

            // Save the presentation (optional, as we only read)
            string dummySavePath = Path.Combine(outputDir, "dummy_save.pptx");
            pres.Save(dummySavePath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}
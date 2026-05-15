using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Define input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Define output directory for SVG files
            string outputDir = Path.Combine(Environment.CurrentDirectory, "SvgOutput");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Format string for naming SVG files
            string formatString = Path.Combine(outputDir, "slide_{0}.svg");

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Iterate through slides and export only non‑hidden slides to SVG
            for (int index = 0; index < pres.Slides.Count; index++)
            {
                ISlide slide = pres.Slides[index];

                // Use the Hidden property (ISlide does not have IsHidden)
                if (slide.Hidden)
                {
                    // Skip hidden slide
                    continue;
                }

                using (FileStream stream = new FileStream(string.Format(formatString, index), FileMode.Create, FileAccess.Write))
                {
                    slide.WriteAsSvg(stream);
                }
            }

            // Save the presentation (required by lifecycle rule)
            try
            {
                string savedPath = Path.Combine(outputDir, "ProcessedPresentation.pptx");
                pres.Save(savedPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Clean up
            pres.Dispose();
        }
    }
}
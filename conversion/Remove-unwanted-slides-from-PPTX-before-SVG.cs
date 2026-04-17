using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation path and output directory
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputDir = Path.Combine(Environment.CurrentDirectory, "output");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the presentation
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                // Handle other loading exceptions (e.g., network issues if a URL was used)
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Remove unwanted slides (example: remove the first slide)
            if (pres.Slides.Count > 0)
            {
                pres.Slides.RemoveAt(0);
            }

            // Save the modified presentation before exiting (as required)
            string modifiedPath = Path.Combine(outputDir, "modified.pptx");
            try
            {
                pres.Save(modifiedPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Saving in the requested format is not supported.");
            }

            // Export remaining slides to SVG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                using (FileStream svgStream = File.Create(svgPath))
                {
                    pres.Slides[i].WriteAsSvg(svgStream);
                }
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}
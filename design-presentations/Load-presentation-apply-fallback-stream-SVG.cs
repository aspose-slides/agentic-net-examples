using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                var presentation = new Presentation(inputPath);

                // Apply a font fallback rule
                var rules = new FontFallBackRulesCollection();
                rules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                presentation.FontsManager.FontFallBackRulesCollection = rules;

                // Get the first slide
                var slide = presentation.Slides[0];

                // Stream the slide as SVG (example uses a memory stream)
                using (var svgStream = new MemoryStream())
                {
                    slide.WriteAsSvg(svgStream);
                    svgStream.Position = 0;
                    // TODO: send svgStream to client (e.g., HTTP response)
                }

                // Save the modified presentation before exiting
                var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                using (var outStream = new FileStream(outputPath, FileMode.Create))
                {
                    presentation.Save(outStream, SaveFormat.Pptx);
                }

                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
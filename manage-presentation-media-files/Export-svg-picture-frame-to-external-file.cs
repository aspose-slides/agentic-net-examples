using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file names
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPptxPath = Path.Combine(dataDir, "input.pptx");
            string outputSvgPath = Path.Combine(dataDir, "exported_shape.svg");
            string outputPptxPath = Path.Combine(dataDir, "saved_presentation.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPptxPath))
            {
                Console.WriteLine("Input file not found: " + inputPptxPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPptxPath))
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    // Assume the first shape is the SVG picture frame
                    Aspose.Slides.IShape shape = slide.Shapes[0];

                    // Export the shape to an external SVG file, preserving vector paths
                    using (FileStream svgStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                    {
                        shape.WriteAsSvg(svgStream);
                    }

                    // Save the presentation before exiting (optional, demonstrates lifecycle rule)
                    pres.Save(outputPptxPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
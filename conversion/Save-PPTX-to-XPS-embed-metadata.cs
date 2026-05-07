using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesXpsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.xps";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Access document properties to preserve author information
                Aspose.Slides.IDocumentProperties docProps = pres.DocumentProperties;
                string author = docProps.Author; // Preserve author (no modification needed)

                // Create XPS save options (default settings)
                Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();

                // Save the presentation as XPS, embedding original metadata
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, options);

                // Save the presentation back to PPTX to satisfy "Save presentation before exit"
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
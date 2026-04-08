using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "output.xps";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure high‑quality XPS options for printing
                Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
                xpsOptions.SaveMetafilesAsPng = true; // Convert metafiles to PNG for better quality

                // Save the presentation to XPS format with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);

                // Dispose the presentation before exiting
                presentation.Dispose();

                Console.WriteLine("Presentation successfully exported to XPS: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, licensing issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
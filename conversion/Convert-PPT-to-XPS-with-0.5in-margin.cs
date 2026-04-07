using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace XpsExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
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
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Create XPS export options
                    XpsOptions options = new XpsOptions();

                    // Note: Aspose.Slides does not provide a direct margin property for XPS export.
                    // Custom margins would need to be handled by adjusting slide content or size beforehand.

                    // Save the presentation as XPS with the specified options
                    pres.Save(outputPath, SaveFormat.Xps, options);
                }

                Console.WriteLine("Presentation successfully saved as XPS: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // The input file format may not be supported for XPS conversion.
                Console.WriteLine("The file format is not supported for XPS conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
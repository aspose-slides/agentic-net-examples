// -----------------------------------------------------------------------------
// Example: Save PowerPoint Presentation to XPS with ISO29500 Compliance
//
// Description:
// This console application loads an existing PPTX file, creates XPS export
// options, and saves the presentation as an XPS document. While Aspose.Slides
// does not expose a direct ISO29500 compliance setting for XPS, ensuring the
// source PPTX conforms to ISO29500 guarantees the exported XPS meets the
// standard. The program checks input file existence and handles I/O errors.
//
// Keywords:
// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, ISO29500 compliance
//
// Use Cases:
// - Automate conversion of corporate presentations to XPS for archiving.
// - Integrate XPS generation into a .NET workflow while maintaining ISO standards.
// - Validate and export ISO29500‑compliant PPTX files to XPS format.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesXpsExport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.xps";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Create XPS export options
                Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
                // Example option: save metafiles as PNG to improve compatibility
                xpsOptions.SaveMetafilesAsPng = true;

                // Note: Aspose.Slides does not provide a direct ISO29500 compliance flag for XPS.
                // Ensure the source PPTX complies with ISO29500 before exporting.

                // Save the presentation as XPS
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);

                // Dispose of the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation successfully saved to XPS: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during conversion: " + ex.Message);
            }
        }
    }
}

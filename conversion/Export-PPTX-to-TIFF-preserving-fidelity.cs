using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source PPTX file
                string inputPath = "input.pptx";

                // Path for the output TIFF file
                string outputPath = "output.tiff";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Create default TIFF export options
                    TiffOptions tiffOptions = new TiffOptions();

                    // Save the presentation as a multi‑page TIFF image
                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
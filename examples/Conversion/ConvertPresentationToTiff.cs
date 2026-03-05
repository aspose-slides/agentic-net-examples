using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Create TIFF options (default settings)
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

                // Save the presentation as a multi-page TIFF file
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            }
        }
    }
}
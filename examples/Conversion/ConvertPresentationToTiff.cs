using System;

namespace ConvertToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation file
            string sourcePath = "input.pptx";
            // Path to the output TIFF file
            string outputPath = "output.tiff";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Save the presentation as a multi-page TIFF image
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff);
            }
        }
    }
}
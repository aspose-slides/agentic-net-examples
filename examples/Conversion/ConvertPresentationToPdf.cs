using System;

namespace PowerPointToPdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string inputPath = "input.pptx";

            // Path where the PDF will be saved
            string outputPath = "output.pdf";

            // Load the presentation using the fully-qualified Aspose.Slides type
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation as PDF using the fully-qualified SaveFormat enum
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
        }
    }
}
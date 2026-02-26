using System;

namespace ConvertPptxToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string inputPath = "input.pptx";
            // Path for the resulting PDF file
            string outputPath = "output.pdf";

            // Load the presentation from the PPTX file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation in PDF format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
        }
    }
}
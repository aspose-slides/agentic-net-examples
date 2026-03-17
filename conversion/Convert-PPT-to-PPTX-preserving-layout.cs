using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file and output PPTX file paths
            string inputPath = "input.ppt";
            string outputPath = "output.pptx";

            try
            {
                // Load the source PPT presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save the presentation in PPTX format
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during conversion
                Console.WriteLine("Conversion failed: " + ex.Message);
            }
        }
    }
}
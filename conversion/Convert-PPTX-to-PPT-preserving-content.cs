using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToPpt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.ppt";

            try
            {
                // Load the PPTX presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save as PPT format
                    presentation.Save(outputPath, SaveFormat.Ppt);
                }

                Console.WriteLine("Conversion successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during conversion: " + ex.Message);
            }
        }
    }
}
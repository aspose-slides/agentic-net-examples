using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the legacy PPT file
            string sourcePath = "sample.ppt";
            // Path for the converted PPTX file
            string destinationPath = "sample_converted.pptx";

            try
            {
                // Load the PPT presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
                {
                    // Save as PPTX format
                    presentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
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
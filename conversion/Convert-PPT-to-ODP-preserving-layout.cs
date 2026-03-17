using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "sample.ppt";
            string outputPath = "sample.odp";

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    presentation.Save(outputPath, SaveFormat.Odp);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during conversion: " + ex.Message);
            }
        }
    }
}
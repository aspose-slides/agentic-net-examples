using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCountExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    int slideCount = pres.DocumentProperties.Slides;
                    Console.WriteLine("Total slides: " + slideCount);

                    // Convert presentation to PDF (example format)
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
                }
            }
            catch (NotSupportedException)
            {
                // format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
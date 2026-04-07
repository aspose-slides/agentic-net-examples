using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputSwfPath = "output.swf";

            bool result = VerifySwfSlideCount(inputPath, outputSwfPath);
            Console.WriteLine("SWF slide count verification: " + result);
        }

        static bool VerifySwfSlideCount(string inputPath, string outputSwfPath)
        {
            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return false;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Expected slide count
                    int expectedCount = pres.Slides.Count;

                    // Create SWF options
                    SwfOptions swfOptions = new SwfOptions();

                    // Save presentation as SWF
                    pres.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                    // Generate animations to get exported slide count
                    using (PresentationAnimationsGenerator generator = new PresentationAnimationsGenerator(pres))
                    {
                        generator.Run(pres.Slides);
                        int exportedCount = generator.ExportedSlides;

                        // Return true if counts match
                        return exportedCount == expectedCount;
                    }
                }
            }
            catch (NotSupportedException)
            {
                // format not supported
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL)
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
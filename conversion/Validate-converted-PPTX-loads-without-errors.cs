using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidatePptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the converted PPTX file
            string inputPath = "converted.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation to ensure it opens without errors
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Save the presentation before exiting (validation succeeded)
                string outputPath = "validated_output.pptx";
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation loaded and saved successfully.");

                // Dispose the presentation object
                pres.Dispose();
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Comment: format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other loading errors
                Console.WriteLine("Error loading presentation: " + ex.Message);
            }
        }
    }
}
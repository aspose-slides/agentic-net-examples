using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesUnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prepare output directory
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Define output file path
            string outputPath = Path.Combine(dataDir, "output.swf");

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Create SwfOptions and set JpegQuality to boundary value 0
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.JpegQuality = 0;

            // Verify that the property accepts the value 0
            if (swfOptions.JpegQuality == 0)
            {
                Console.WriteLine("SwfOptions.JpegQuality successfully set to 0.");
            }
            else
            {
                Console.WriteLine("Failed to set SwfOptions.JpegQuality to 0.");
            }

            // Save the presentation using the configured options
            try
            {
                pres.Save(outputPath, SaveFormat.Swf, swfOptions);
                Console.WriteLine("Presentation saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Clean up
            pres.Dispose();
        }
    }
}
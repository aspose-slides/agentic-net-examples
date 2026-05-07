using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfOptionsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputPath = Path.Combine(dataDir, "test_output.swf");

            // Ensure output directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Configure SwfOptions with boundary JPEG quality value 0
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.JpegQuality = 0;

            // Verify that the property accepts the value
            if (swfOptions.JpegQuality != 0)
            {
                Console.WriteLine("SwfOptions.JpegQuality did not accept the value 0.");
                return;
            }

            // Save the presentation as SWF using the configured options
            try
            {
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                Console.WriteLine("Presentation saved successfully with JpegQuality = 0.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation
                presentation.Dispose();
            }
        }
    }
}
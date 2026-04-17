using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReadOnlyPresentationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output folder and file name
            var outFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            var outFile = Path.Combine(outFolder, "ReadOnlyPresentation.pptx");

            // Ensure output directory exists
            if (!Directory.Exists(outFolder))
                Directory.CreateDirectory(outFolder);

            // Create a new presentation
            var presentation = new Presentation();

            // Set the read‑only recommendation flag
            presentation.ProtectionManager.ReadOnlyRecommended = true;

            try
            {
                // Save the presentation in PPTX format
                presentation.Save(outFile, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., unsupported format)
                Console.WriteLine("Error saving presentation: " + ex.Message);
                // Format not supported
                // Comment: format not supported
            }
            finally
            {
                // Dispose the presentation object
                presentation.Dispose();
            }

            Console.WriteLine("Presentation saved to: " + outFile);
        }
    }
}
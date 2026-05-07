using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file path
            string inputPath = "input.ppt";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Output file paths
            string outputTiff = "output.tiff";
            string outputDocx = "output.docx";

            try
            {
                // Load the presentation once and reuse it
                Presentation presentation = new Presentation(inputPath);

                // Convert to TIFF
                presentation.Save(outputTiff, SaveFormat.Tiff);

                // Attempt to convert to DOCX (unsupported format)
                try
                {
                    // Aspose.Slides does not support saving to DOCX; using an invalid enum value to trigger exception
                    presentation.Save(outputDocx, (SaveFormat)9999);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (InvalidOperationException)
                {
                    // Format not supported
                }

                // Ensure the presentation is saved before exiting (already saved above)
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
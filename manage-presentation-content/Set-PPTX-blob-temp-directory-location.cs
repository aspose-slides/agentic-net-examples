using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";
            // Desired temporary files directory
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeSlidesTemp");

            try
            {
                // Ensure the temporary directory exists
                Directory.CreateDirectory(tempDir);

                // Configure load options to allow temporary files and set the root path
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
                loadOptions.BlobManagementOptions.TempFilesRootPath = tempDir;

                // Load the presentation with the configured options
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))
                {
                    // Perform any processing here (none in this example)

                    // Save the presentation before exiting
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EfficientBlobHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Configure load options for efficient BLOB handling
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

            // Load the presentation with the specified options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Example operation: display slide count
            int slideCount = presentation.Slides.Count;
            Console.WriteLine("Slide count: " + slideCount);

            // Save the presentation to the output path
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources and unlock the source file
            presentation.Dispose();

            // Delete the original file after processing
            File.Delete(inputPath);
        }
    }
}
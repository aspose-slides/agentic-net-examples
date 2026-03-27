using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationBlobOptimization
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Configure load options to optimize BLOB handling
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked;

            // Load the presentation with the specified options
            Presentation presentation = new Presentation(inputPath, loadOptions);

            // Example manipulation: rename the first slide
            if (presentation.Slides.Count > 0)
            {
                presentation.Slides[0].Name = "OptimizedSlide";
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation to release resources and unlock the source file
            presentation.Dispose();

            // Optionally delete the original file after processing
            File.Delete(inputPath);
        }
    }
}
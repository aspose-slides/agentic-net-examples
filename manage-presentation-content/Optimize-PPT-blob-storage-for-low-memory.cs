using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BLOBExample
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

            // Configure load options to use BLOB management with KeepLocked behavior
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.BlobManagementOptions = new BlobManagementOptions();
            loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked;

            // Load the presentation with the specified load options
            Presentation presentation = new Presentation(inputPath, loadOptions);

            // Example manipulation: add an empty slide based on the first slide's layout
            ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation to release resources and unlock the source file
            presentation.Dispose();

            Console.WriteLine("Presentation processed and saved to: " + outputPath);
        }
    }
}
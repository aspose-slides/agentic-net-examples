using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "large.pptx";
        string outputPath = "copy.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Configure load options for BLOB handling
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

        // Load the presentation using the specified load options
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions);

        // Example operation: rename the first slide
        pres.Slides[0].Name = "RenamedSlide";

        // Save the presentation before exiting
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources (unlocks the source file)
        pres.Dispose();

        // Delete the original file to demonstrate that the lock has been released
        File.Delete(inputPath);
    }
}
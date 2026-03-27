using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the original large presentation and the copy
        string sourcePath = "largePresentation.pptx";
        string copyPath = "largePresentation_copy.pptx";

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file not found: " + sourcePath);
            return;
        }

        // Configure load options to use temporary files and keep the source locked
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
        {
            PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked,
            IsTemporaryFilesAllowed = true
        };

        // Open the large presentation with memory‑efficient settings
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

        // Example operation: rename the first slide
        presentation.Slides[0].Name = "RenamedSlide";

        // Save a copy of the presentation
        presentation.Save(copyPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release all resources
        presentation.Dispose();

        // Delete the original file after processing
        File.Delete(sourcePath);

        Console.WriteLine("Processing completed. Copy saved at: " + copyPath);
    }
}
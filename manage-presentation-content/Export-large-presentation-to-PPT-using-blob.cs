using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string sourcePath = "largePresentation.pptx";
        string outputPath = "outputPresentation.ppt";

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        // Configure load options with BLOB management for large presentations
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
        {
            BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
            {
                PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
            }
        };

        // Open the large presentation using the specified load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

        // Example modification: rename the first slide
        presentation.Slides[0].Name = "RenamedSlide";

        // Save the presentation to a BLOB stream in PPT format
        using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
        {
            presentation.Save(outputStream, Aspose.Slides.Export.SaveFormat.Ppt);
        }

        // Clean up resources
        presentation.Dispose();
    }
}
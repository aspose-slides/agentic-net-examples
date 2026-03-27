using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for source and output files
        string sourcePath = "largePresentation.pptx";
        string outputPath = "exportedPresentation.pptx";

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        // Configure load options to keep the source locked for efficient BLOB handling
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.BlobManagementOptions = new BlobManagementOptions();
        loadOptions.BlobManagementOptions.PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked;

        // Open the large presentation with the specified load options
        Presentation presentation = new Presentation(sourcePath, loadOptions);

        // Create a memory stream to hold the PPTX data
        MemoryStream memoryStream = new MemoryStream();

        // Save the presentation to the memory stream in PPTX format
        presentation.Save(memoryStream, SaveFormat.Pptx);

        // Write the memory stream contents to the output file
        using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
        {
            memoryStream.Position = 0;
            memoryStream.CopyTo(fileStream);
        }

        // Clean up resources
        memoryStream.Close();
        presentation.Dispose();

        Console.WriteLine("Export completed successfully.");
    }
}
using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string sourcePath = "largePresentation.pptx";
        // Path to save the modified presentation
        string outputPath = "outputPresentation.pptx";

        // Create load options with BLOB management settings
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        // Configure BLOB management options
        loadOptions.BlobManagementOptions = new Aspose.Slides.BlobManagementOptions();
        loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
        loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

        // Open the presentation with the specified load options
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions))
        {
            // Example operation: write slide count to console
            int slideCount = presentation.Slides.Count;
            Console.WriteLine("Number of slides: " + slideCount);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
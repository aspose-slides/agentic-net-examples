using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create load options with BLOB management settings
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.BlobManagementOptions = new Aspose.Slides.BlobManagementOptions();
        loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
        loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

        // Open existing large presentation with the specified options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("largePresentation.pptx", loadOptions);

        // Save the presentation before exiting
        presentation.Save("largePresentation_modified.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose presentation
        presentation.Dispose();
    }
}
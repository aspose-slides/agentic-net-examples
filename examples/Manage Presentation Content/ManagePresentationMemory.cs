using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the source and the copy
        string sourcePath = "largePresentation.ppt";
        string copyPath = "largePresentation_copy.ppt";

        // Load options with BlobManagementOptions to keep the source locked
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
        {
            BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
            {
                PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
            }
        };

        // Open the very large presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath, loadOptions);

        // Rename the first slide (example of modifying content)
        pres.Slides[0].Name = "RenamedSlide";

        // Save the presentation in PPT format before exiting
        pres.Save(copyPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Delete the original file now that it is no longer needed
        File.Delete(sourcePath);

        // Clean up resources
        pres.Dispose();
    }
}
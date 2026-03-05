using System;
using System.IO;

namespace ManagePresentationContent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the original large presentation (PPT format)
            System.String sourcePath = "largePresentation.ppt";
            // Path where the copy will be saved after processing
            System.String copyPath = "largePresentation_copy.ppt";

            // Create load options with BLOB management to keep the source locked during the presentation lifecycle
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.BlobManagementOptions = new Aspose.Slides.BlobManagementOptions();
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

            // Load the large presentation using the specified load options
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath, loadOptions);

            // Example operation: rename the first slide
            pres.Slides[0].Name = "RenamedSlide";

            // Save the presentation copy in PPT format
            pres.Save(copyPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Delete the original source file (it is unlocked after disposing the presentation)
            File.Delete(sourcePath);

            // Dispose the presentation to release resources and unlock the source file
            pres.Dispose();
        }
    }
}
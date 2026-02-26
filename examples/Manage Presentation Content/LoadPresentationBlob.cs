using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationContent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the original large presentation (PPT format)
            string sourcePath = "largePresentation.ppt";

            // Path where the copy will be saved after loading as BLOB
            string copyPath = "largePresentationCopy.ppt";

            // Load options with BLOB management to keep the source locked for the lifetime of the presentation
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

            // Load the presentation using the specified load options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

            // Example operation: rename the first slide
            presentation.Slides[0].Name = "RenamedSlide";

            // Save the presentation in PPT format before exiting
            presentation.Save(copyPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Delete the original file now that it is no longer needed
            File.Delete(sourcePath);

            // Dispose the presentation to release the lock on the source file
            presentation.Dispose();
        }
    }
}
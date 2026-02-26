using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReducePresentationMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            System.String sourcePath = "input.ppt";
            // Path where the reduced-memory copy will be saved
            System.String copyPath = "output.ppt";

            // Create LoadOptions with BlobManagement to keep the source locked for the lifetime of the presentation
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.BlobManagementOptions = new Aspose.Slides.BlobManagementOptions();
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

            // Load the presentation using the specified LoadOptions
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

            // Example modification: rename the first slide
            presentation.Slides[0].Name = "RenamedSlide";

            // Save the presentation in PPT format
            presentation.Save(copyPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Dispose the presentation to release resources and unlock the source file
            presentation.Dispose();

            // Optionally delete the original file after processing
            System.IO.File.Delete(sourcePath);
        }
    }
}
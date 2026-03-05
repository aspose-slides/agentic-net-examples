using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the original large presentation and its copy
        System.String sourcePath = "largePresentation.pptx";
        System.String copyPath = "largePresentation_copy.pptx";

        // Load options to handle the presentation as a BLOB with locking behavior
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
        {
            BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
            {
                PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
            }
        };

        // Load the presentation using the specified load options
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions))
        {
            // Optionally rename the first slide
            presentation.Slides[0].Name = "RenamedSlide";

            // Save a copy of the presentation in PPTX format
            presentation.Save(copyPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }

        // Delete the original file after the presentation has been unlocked
        System.IO.File.Delete(sourcePath);
    }
}
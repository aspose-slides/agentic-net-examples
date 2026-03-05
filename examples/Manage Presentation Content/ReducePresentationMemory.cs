using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Paths for the source and the output presentation
        string sourcePath = "input.ppt";
        string outputPath = "output.ppt";

        // Configure load options to use BLOB management with KeepLocked behavior
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
        {
            BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
            {
                PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
            }
        };

        // Load the presentation using the specified load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath, loadOptions);

        // Example modification: rename the first slide
        presentation.Slides[0].Name = "RenamedSlide";

        // Save the presentation in PPT format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        presentation.Dispose();

        // Delete the original file (it was locked only during the presentation's lifetime)
        File.Delete(sourcePath);
    }
}
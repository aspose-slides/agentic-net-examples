using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string sourcePath = "large.pptx";
        string copyPath = "large_copy.pptx";

        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
        {
            BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
            {
                PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
            }
        };

        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath, loadOptions))
        {
            pres.Slides[0].Name = "RenamedSlide";
            pres.Save(copyPath, SaveFormat.Pptx);
        }

        File.Delete(sourcePath);
    }
}
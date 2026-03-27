using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "large.pptx";
        string outputPath = "large.pdf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.BlobManagementOptions = new Aspose.Slides.BlobManagementOptions();
        loadOptions.BlobManagementOptions.PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked;

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        presentation.Dispose();
    }
}
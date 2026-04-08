using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output folder and ensure it exists
        string outFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outFolder))
        {
            Directory.CreateDirectory(outFolder);
        }

        // Define output file path
        string outPath = Path.Combine(outFolder, "ReadOnlyPresentation.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Set the presentation to read‑only (editing disabled)
        pres.ProtectionManager.ReadOnlyRecommended = true;

        // Save the presentation
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        pres.Dispose();
    }
}
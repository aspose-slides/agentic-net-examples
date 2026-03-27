using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define paths
        string dataDir = @"C:\Data\";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output_without_blobs.pptx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load presentation with option to delete embedded binary objects (BLOBs)
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DeleteEmbeddedBinaryObjects = true;

        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))
        {
            // Remove VBA macros if any
            if (pres.VbaProject != null && pres.VbaProject.Modules.Count > 0)
            {
                pres.VbaProject.Modules.Remove(pres.VbaProject.Modules[0]);
            }

            // Save the cleaned presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }

        Console.WriteLine("Presentation saved without embedded binary objects to: " + outputPath);
    }
}
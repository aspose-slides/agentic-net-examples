using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define output directory and file path
        string outputDir = Path.Combine(Environment.CurrentDirectory, "output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }
        string outputPath = Path.Combine(outputDir, "presentation.pptx");

        // Create a new presentation
        Presentation pres = new Presentation();

        // Save the presentation as PPTX with ZIP64 mode always enabled
        pres.Save(outputPath, SaveFormat.Pptx, new PptxOptions()
        {
            Zip64Mode = Zip64Mode.Always
        });

        // Release resources
        pres.Dispose();

        Console.WriteLine("Presentation saved to: " + outputPath);
    }
}
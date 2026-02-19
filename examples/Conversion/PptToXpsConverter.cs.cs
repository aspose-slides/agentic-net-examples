using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation files
        string inputPptPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.ppt");
        string inputPptxPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.pptx");

        // Output directory
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Convert PPT to XPS
        string outputPptXpsPath = Path.Combine(outputDir, "sample_ppt.xps");
        using (Presentation presPpt = new Presentation(inputPptPath))
        {
            // Save without additional XPS options
            presPpt.Save(outputPptXpsPath, SaveFormat.Xps);
        }

        // Convert PPTX to XPS
        string outputPptxXpsPath = Path.Combine(outputDir, "sample_pptx.xps");
        using (Presentation presPptx = new Presentation(inputPptxPath))
        {
            // Save without additional XPS options
            presPptx.Save(outputPptxXpsPath, SaveFormat.Xps);
        }
    }
}
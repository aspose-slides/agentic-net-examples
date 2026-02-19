using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPT file path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.ppt");
        // Output XPS file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Save as XPS format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);

        // Dispose the presentation
        pres.Dispose();
    }
}
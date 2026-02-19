using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input presentation path and output directory
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputDir = Path.Combine(dataDir, "output");
        Directory.CreateDirectory(outputDir);

        // Load the presentation
        Presentation pres = new Presentation(inputPath);

        // Export each slide as SVG
        int slideIndex = 0;
        while (slideIndex < pres.Slides.Count)
        {
            string outSvgPath = Path.Combine(outputDir, "slide_" + slideIndex + ".svg");
            using (FileStream outStream = new FileStream(outSvgPath, FileMode.Create))
            {
                pres.Slides[slideIndex].WriteAsSvg(outStream);
            }
            slideIndex++;
        }

        // Save the presentation before exiting
        string outPptxPath = Path.Combine(outputDir, "output.pptx");
        pres.Save(outPptxPath, SaveFormat.Pptx);
    }
}
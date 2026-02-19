using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path
        System.String inputPath = "input.pptx";
        // Output directory for SVG files
        System.String outputDir = "output";

        // Ensure output directory exists
        System.IO.Directory.CreateDirectory(outputDir);

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Iterate through each slide and save as SVG
        for (System.Int32 i = 0; i < pres.Slides.Count; i++)
        {
            System.String svgPath = System.IO.Path.Combine(outputDir, "slide_" + (i + 1) + ".svg");
            using (System.IO.FileStream outStream = new System.IO.FileStream(svgPath, System.IO.FileMode.Create))
            {
                // Write the current slide as SVG
                pres.Slides[i].WriteAsSvg(outStream);
            }
        }

        // Save the presentation before exiting
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
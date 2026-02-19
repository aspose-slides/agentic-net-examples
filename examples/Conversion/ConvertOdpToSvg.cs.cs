using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input ODP file path
        string inputPath = "input.odp";
        // Output SVG file path
        string outputSvgPath = "output.svg";

        // Override paths with command line arguments if provided
        if (args.Length >= 1)
        {
            inputPath = args[0];
        }
        if (args.Length >= 2)
        {
            outputSvgPath = args[1];
        }

        // Load the ODP presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Export the first slide to SVG
        using (System.IO.FileStream outStream = new System.IO.FileStream(outputSvgPath, System.IO.FileMode.Create))
        {
            pres.Slides[0].WriteAsSvg(outStream);
        }

        // Save the presentation before exiting (optional)
        string tempSavePath = "temp.pptx";
        pres.Save(tempSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
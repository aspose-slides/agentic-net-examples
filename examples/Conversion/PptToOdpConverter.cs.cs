using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PPT file
        string inputPath = "input.ppt";
        // Path to the destination ODP file
        string outputPath = "output.odp";

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the PPT presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Save the presentation in ODP format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);

        // Release resources
        presentation.Dispose();
    }
}
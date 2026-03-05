using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        var inputPath = "input.pptx";
        // Path for the resulting XPS file
        var outputPath = "output.xps";

        // Load the presentation
        using (var presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in XPS format
            presentation.Save(outputPath, SaveFormat.Xps);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";
        // Path to the output XPS file
        string outputPath = "output.xps";

        // Load the existing presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
        {
            // Create XPS save options (default settings)
            Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();

            // Save the presentation as XPS using the options
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, options);
        }
    }
}
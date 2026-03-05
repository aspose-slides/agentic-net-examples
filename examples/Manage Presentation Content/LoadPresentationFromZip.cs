using System;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file (ZIP package)
        string inputPath = "input.pptx";
        // Path for the output PPTX file
        string outputPath = "output.pptx";

        // Load the presentation from the ZIP package
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in PPTX format
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
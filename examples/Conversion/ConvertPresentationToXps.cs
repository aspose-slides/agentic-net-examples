using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourcePath = "input.pptx";
        // Path to the output XPS file
        string outputPath = "output.xps";

        // Load the presentation using fully-qualified Aspose.Slides type
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
        {
            // Save the presentation to XPS format with default settings
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);
        }
        // Presentation is disposed automatically by the using statement
    }
}
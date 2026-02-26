using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourcePath = "input.pptx";
        // Path where the XPS file will be saved
        string outputPath = "output.xps";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Save the presentation to XPS format using default options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);
        }
    }
}
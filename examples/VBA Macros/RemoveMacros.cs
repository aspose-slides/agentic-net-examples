using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptm";
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Remove VBA macros if present
        if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
        {
            presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);
        }

        // Save the presentation without macros
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Remove the first VBA module if present
        if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
        {
            presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);
        }

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
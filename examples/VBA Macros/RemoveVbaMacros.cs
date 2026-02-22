using System;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        System.String inputPath = "input.pptx";
        // Path where the modified PPTX will be saved
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Check if VBA project exists and has at least one module
        if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
        {
            // Remove the first VBA module
            presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);
        }

        // Save the presentation after removing VBA macros
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
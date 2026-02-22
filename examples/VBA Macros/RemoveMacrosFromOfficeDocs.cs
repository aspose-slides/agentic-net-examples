using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output PPTX file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Load the presentation from the input file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Check if the presentation contains a VBA project with modules
        if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
        {
            // Remove the first VBA module (macro) from the project
            presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);
        }

        // Save the modified presentation to the output file
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPT file
        string inputPath = "input.ppt";
        // Path for the converted PPTX file
        string outputPath = "output.pptx";

        // Load the PPT presentation
        Presentation presentation = new Presentation(inputPath);

        // Create PPTX save options using the factory
        SaveOptionsFactory optionsFactory = new SaveOptionsFactory();
        IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

        // Save the presentation as PPTX with the specified options
        presentation.Save(outputPath, SaveFormat.Pptx, pptxOptions);

        // Ensure resources are released before exiting
        presentation.Dispose();
    }
}
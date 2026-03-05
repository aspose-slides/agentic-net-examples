using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPT file path
        string inputPath = "input.ppt";
        // Output PPTX file path
        string outputPath = "output.pptx";

        // Load the PPT presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create a SaveOptionsFactory instance to obtain PPTX save options
        Aspose.Slides.Export.SaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
        Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

        // Save the presentation as PPTX using the obtained options
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);

        // Dispose the presentation object
        presentation.Dispose();
    }
}
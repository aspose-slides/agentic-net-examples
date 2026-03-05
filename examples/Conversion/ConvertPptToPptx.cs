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
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create PPTX save options using the factory
            Aspose.Slides.Export.ISaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
            Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

            // Save the presentation as PPTX with the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);
        }
    }
}
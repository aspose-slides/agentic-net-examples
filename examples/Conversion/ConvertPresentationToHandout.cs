using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file and output PPT file paths
        string inputPath = "input.pptx";
        string outputPath = "output.ppt";

        // Load the PPTX presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create PPT save options
            Aspose.Slides.Export.PptOptions pptOptions = new Aspose.Slides.Export.PptOptions();

            // Save the presentation in PPT format (handout mode not applicable for PPT)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt, pptOptions);
        }
    }
}
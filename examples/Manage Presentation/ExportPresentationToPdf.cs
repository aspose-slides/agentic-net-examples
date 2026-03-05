using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation (any supported format, e.g., PPTX)
        string inputPath = "input.pptx";

        // Path where the PDF will be saved
        string outputPath = "output.pdf";

        // Load the presentation using the fully-qualified Aspose.Slides type
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Export the presentation to PDF format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file (large file)
        string inputPath = "input.pptx";

        // Path for the resulting PDF file
        string outputPath = "output.pdf";

        // Load the presentation from the PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Export the presentation to PDF format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

        // Release resources
        presentation.Dispose();
    }
}
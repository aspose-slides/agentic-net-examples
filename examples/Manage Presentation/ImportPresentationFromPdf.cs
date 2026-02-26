using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Define output directory and ensure it exists
        string outputDir = "output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Paths for the source PDF and the resulting PPTX file
        string pdfPath = "input.pdf";
        string pptxPath = Path.Combine(outputDir, "result.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Import slides from the PDF document
        presentation.Slides.AddFromPdf(pdfPath);

        // Save the presentation in PPTX format
        presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}
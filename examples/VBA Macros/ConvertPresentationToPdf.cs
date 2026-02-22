using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = System.IO.Path.Combine("Input", "MacroPresentation.pptm");
        string outputPath = System.IO.Path.Combine("Output", "MacroPresentation.pdf");

        // Ensure the output directory exists
        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outputPath));

        // Load the macro-enabled presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create PDF options and set compliance level
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA2a;

        // Save the presentation as PDF
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Release resources
        presentation.Dispose();
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create PDF export options (default options preserve layout)
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            // Save the presentation as PDF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source PPTX file containing 3D effects
            string inputPath = "input.pptx";
            // Path where the resulting PDF will be saved
            string outputPath = "output.pdf";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Create PDF export options (default options preserve visual effects)
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                // Save the presentation as PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
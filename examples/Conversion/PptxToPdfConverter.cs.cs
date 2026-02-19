using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file path
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        // Output PDF file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

        // Load the PPTX presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation as PDF
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}
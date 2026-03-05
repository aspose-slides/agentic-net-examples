using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Verify command line arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: ConvertPptxToPdf <input.pptx> <output.pdf>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the PPTX presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation as PDF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}
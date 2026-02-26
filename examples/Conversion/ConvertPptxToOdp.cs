using System;

class Program
{
    static void Main(string[] args)
    {
        // Verify that input and output file paths are provided
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: ConvertPptxToOdp <input.pptx> <output.odp>");
            return;
        }

        // Input PPTX file path
        string inputPath = args[0];
        // Desired ODP output file path
        string outputPath = args[1];

        // Load the PPTX presentation using the fully-qualified Aspose.Slides type
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in ODP format before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
        }
    }
}
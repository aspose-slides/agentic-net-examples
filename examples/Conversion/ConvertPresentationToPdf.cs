using System;

namespace ConvertPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verify that input and output file paths are provided
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ConvertPresentation <input-ppt-or-pptx> <output-pdf>");
                return;
            }

            // Assign command‑line arguments to local variables
            string inputPath = args[0];
            string outputPath = args[1];

            // Load the presentation from the specified file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation as a PDF file
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }

            // Inform the user that conversion has finished
            Console.WriteLine("Conversion completed.");
        }
    }
}
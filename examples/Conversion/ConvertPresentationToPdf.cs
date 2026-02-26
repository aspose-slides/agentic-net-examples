using System;

namespace ConvertToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verify that input and output paths are provided
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ConvertToPdf <input-ppt-or-pptx> <output-pdf>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Load the presentation from the specified file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation as a PDF file
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
        }
    }
}
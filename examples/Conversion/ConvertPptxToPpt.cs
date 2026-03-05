using System;

namespace ConvertPptxToPpt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path (first argument or default)
            string inputPath = args.Length > 0 && !String.IsNullOrEmpty(args[0]) ? args[0] : "input.pptx";

            // Output PPT file path (second argument or default)
            string outputPath = args.Length > 1 && !String.IsNullOrEmpty(args[1]) ? args[1] : "output.ppt";

            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation in PPT format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Release resources
            presentation.Dispose();
        }
    }
}
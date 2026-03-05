using System;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input PPT file
            string inputPath = "input.ppt";
            // Path to the output PPTX file
            string outputPath = "output.pptx";

            // Load the presentation from the PPT file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation in PPTX format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
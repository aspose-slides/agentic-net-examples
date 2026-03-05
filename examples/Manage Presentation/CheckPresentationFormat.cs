using System;

namespace PresentationFormatChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "sample.pptx";
            // Path for the saved copy
            string outputPath = "sample_copy.pptx";

            // Retrieve presentation information using PresentationFactory
            Aspose.Slides.IPresentationInfo info = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
            // Display the detected load format
            Console.WriteLine(info.LoadFormat);

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
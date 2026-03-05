using System;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation instance
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Define the output file path
                string outputPath = "SavedPresentation.pptx";

                // Save the presentation in PPTX format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
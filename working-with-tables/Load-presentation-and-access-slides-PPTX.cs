using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "sample.pptx";
                var outputPath = "output.pptx";

                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Access the first slide for editing or extraction
                    var slide = presentation.Slides[0];
                    // ... perform operations on the slide ...

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
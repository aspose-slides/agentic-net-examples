using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSlideAtPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "source.pptx";
            string outputPath = "result.pptx";

            // Load the existing presentation
            Presentation pres = new Presentation(inputPath);

            // Get the slide collection
            ISlideCollection slides = pres.Slides;

            // Insert a copy of the first slide at position 1 (second position)
            slides.InsertClone(1, pres.Slides[0]);

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}
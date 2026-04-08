using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideNumberDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Make slide number placeholders visible on all slides
            presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

            // Define output file path
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "PresentationWithSlideNumbers.pptx");

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
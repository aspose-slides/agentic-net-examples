using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddNumbersToPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set the first slide number (using the set-slide-number rule)
            presentation.FirstSlideNumber = 1;

            // Make slide numbers visible for all slides
            presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

            // Save the updated presentation as PPTX
            presentation.Save("UpdatedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}
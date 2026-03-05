using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing PPTX file
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Get the slide collection
            Aspose.Slides.ISlideCollection slides = pres.Slides;

            // Clone the first slide (index 0) and insert it at position 2
            Aspose.Slides.ISlide clonedSlide = slides.InsertClone(2, slides[0]);

            // Save the modified presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
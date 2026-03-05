using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Access the slide collection
        Aspose.Slides.ISlideCollection slides = pres.Slides;

        // Clone the first slide and insert it at index 1 (after the original slide)
        Aspose.Slides.ISlide clonedSlide = slides.InsertClone(1, slides[0]);

        // Save the modified presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
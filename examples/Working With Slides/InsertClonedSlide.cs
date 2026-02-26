using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Get the slide collection
        Aspose.Slides.ISlideCollection slides = pres.Slides;

        // Choose the slide to clone (e.g., the first slide)
        Aspose.Slides.ISlide sourceSlide = slides[0];

        // Insert the cloned slide at the desired index (e.g., position 2)
        Aspose.Slides.ISlide clonedSlide = slides.InsertClone(2, sourceSlide);

        // Save the modified presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
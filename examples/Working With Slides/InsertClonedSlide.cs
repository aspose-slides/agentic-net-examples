using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Access the slide collection
            Aspose.Slides.ISlideCollection slides = presentation.Slides;
            // Select the slide to be cloned (e.g., first slide)
            Aspose.Slides.ISlide sourceSlide = slides[0];
            // Insert the cloned slide at the desired index (e.g., position 2)
            Aspose.Slides.ISlide clonedSlide = slides.InsertClone(2, sourceSlide);
            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
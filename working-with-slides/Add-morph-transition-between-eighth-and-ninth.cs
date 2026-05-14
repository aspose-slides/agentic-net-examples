using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Ensure there is at least one slide to clone from
        var baseSlide = presentation.Slides[0];

        // Add slides up to slide nine (indices 0‑8)
        for (int i = 1; i < 9; i++)
        {
            presentation.Slides.AddClone(baseSlide);
        }

        // Apply Morph transition between slide eight (index 7) and slide nine (index 8)
        // Set the transition type to Morph
        presentation.Slides[7].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

        // Cast the transition value to MorphTransition to set a custom MorphType
        var morphTransition = (Aspose.Slides.SlideShow.MorphTransition)presentation.Slides[7].SlideShowTransition.Value;
        morphTransition.MorphType = Aspose.Slides.SlideShow.TransitionMorphType.ByWord; // Custom morph type

        // Save the presentation
        presentation.Save("MorphTransitionExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
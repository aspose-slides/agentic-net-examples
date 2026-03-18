using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Define the transition type to apply
            Aspose.Slides.SlideShow.TransitionType transitionType = Aspose.Slides.SlideShow.TransitionType.Fade;

            // Apply the transition to all slides in the presentation
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                presentation.Slides[i].SlideShowTransition.Type = transitionType;
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
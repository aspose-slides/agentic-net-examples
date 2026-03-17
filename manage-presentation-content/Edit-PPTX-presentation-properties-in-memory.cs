using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Presentation();

            // Access the first slide
            var slide = presentation.Slides[0];

            // Apply a fade transition using the correct enum reference
            slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

            // Save the presentation to disk
            presentation.Save("EditedPresentation.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
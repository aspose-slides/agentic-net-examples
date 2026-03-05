using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing PPTX file
        Presentation presentation = new Presentation("input.pptx");

        // Reference the slide to be removed (e.g., the first slide)
        ISlide slideToRemove = presentation.Slides[0];

        // Remove the slide from the presentation
        slideToRemove.Remove();

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}
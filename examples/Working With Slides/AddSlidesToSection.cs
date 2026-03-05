using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the collection of sections
        Aspose.Slides.ISectionCollection sections = presentation.Sections;

        // Assume we want to add slides to the first section
        Aspose.Slides.ISection targetSection = sections[0];

        // Choose a slide to clone (e.g., the first slide in the presentation)
        Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

        // Add a cloned slide to the end of the target section
        Aspose.Slides.ISlide newSlide1 = presentation.Slides.AddClone(sourceSlide, targetSection);

        // Add another cloned slide to the same section
        Aspose.Slides.ISlide newSlide2 = presentation.Slides.AddClone(sourceSlide, targetSection);

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}
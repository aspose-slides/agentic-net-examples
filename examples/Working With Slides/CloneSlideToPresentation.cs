using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation containing the slide to be cloned
        Presentation srcPres = new Presentation("Source.pptx");

        // Create a new destination presentation
        Presentation destPres = new Presentation();

        // Get the first slide from the source presentation
        ISlide sourceSlide = srcPres.Slides[0];

        // Get the slide collection of the destination presentation
        ISlideCollection destSlides = destPres.Slides;

        // Insert a clone of the source slide at the end of the destination slide collection
        destSlides.InsertClone(destSlides.Count, sourceSlide);

        // Save the destination presentation to disk
        destPres.Save("ClonedPresentation.pptx", SaveFormat.Pptx);

        // Clean up resources
        srcPres.Dispose();
        destPres.Dispose();
    }
}
using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the source presentation from file
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("source.pptx");
        // Create a new destination presentation (contains one empty slide by default)
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the first slide from the source presentation
        Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];
        // Clone the source slide into the destination presentation
        Aspose.Slides.ISlide clonedSlide = destPres.Slides.AddClone(sourceSlide);

        // Save the destination presentation to a PPTX file
        destPres.Save("merged.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        sourcePres.Dispose();
        destPres.Dispose();
    }
}
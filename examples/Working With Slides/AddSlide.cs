using System;

class Program
{
    static void Main()
    {
        // Load the source presentation containing the slide to copy
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("source.pptx");
        // Create a new destination presentation (starts with one empty slide)
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();
        // Get the first slide from the source presentation
        Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];
        // Add a clone of the source slide to the destination presentation
        destPres.Slides.AddClone(sourceSlide);
        // Save the destination presentation to a file
        destPres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Clean up resources
        sourcePres.Dispose();
        destPres.Dispose();
    }
}
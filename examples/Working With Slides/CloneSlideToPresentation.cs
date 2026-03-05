using System;

class Program
{
    static void Main()
    {
        // Load the source presentation from a PPTX file
        var srcPres = new Aspose.Slides.Presentation("Source.pptx");
        // Create a new destination presentation
        var destPres = new Aspose.Slides.Presentation();
        // Get the slide collection of the destination presentation
        var destSlides = destPres.Slides;
        // Clone the first slide from the source into the destination at index 0
        destSlides.InsertClone(0, srcPres.Slides[0]);
        // Save the destination presentation to disk
        destPres.Save("ClonedPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Clean up resources
        srcPres.Dispose();
        destPres.Dispose();
    }
}
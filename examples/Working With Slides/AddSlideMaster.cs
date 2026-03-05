using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation that contains the master slide to be cloned
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("SourceMaster.pptx");

        // Create a new (empty) destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Retrieve the master slide from the first slide of the source presentation
        Aspose.Slides.IMasterSlide sourceMaster = sourcePres.Slides[0].LayoutSlide.MasterSlide;

        // Insert a clone of the source master slide into the destination presentation at index 0
        Aspose.Slides.IMasterSlide insertedMaster = destPres.Masters.InsertClone(0, sourceMaster);

        // Add an empty slide to the destination presentation using a layout from the newly inserted master
        Aspose.Slides.ILayoutSlide layout = insertedMaster.LayoutSlides[0];
        destPres.Slides.InsertEmptySlide(0, layout);

        // Save the destination presentation to disk
        destPres.Save("DestinationWithNewMaster.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        sourcePres.Dispose();
        destPres.Dispose();
    }
}
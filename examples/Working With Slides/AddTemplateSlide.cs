using System;

class Program
{
    static void Main()
    {
        // Load the template presentation from which the slide will be copied
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("Template.pptx");

        // Create a new empty presentation that will receive the slide
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the first slide from the template (adjust index as needed)
        Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];

        // Retrieve the master slide associated with the source slide's layout
        Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

        // Clone the master slide into the destination presentation
        Aspose.Slides.IMasterSlideCollection destMasters = destPres.Masters;
        Aspose.Slides.IMasterSlide clonedMaster = destMasters.AddClone(sourceMaster);

        // Clone the source slide into the destination presentation using the cloned master
        Aspose.Slides.ISlideCollection destSlides = destPres.Slides;
        destSlides.AddClone(sourceSlide, clonedMaster, true);

        // Save the resulting presentation to disk
        destPres.Save("Result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        sourcePres.Dispose();
        destPres.Dispose();
    }
}
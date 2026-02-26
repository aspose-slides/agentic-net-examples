using System;

class Program
{
    static void Main()
    {
        // Load the template presentation
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("Template.pptx");
        // Create a new destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the first slide from the source
        Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];
        // Get the master slide associated with the source slide
        Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

        // Clone the master slide into the destination presentation
        Aspose.Slides.IMasterSlideCollection destMasters = destPres.Masters;
        Aspose.Slides.IMasterSlide clonedMaster = destMasters.AddClone(sourceMaster);

        // Clone the source slide into the destination presentation using the cloned master
        Aspose.Slides.ISlideCollection destSlides = destPres.Slides;
        destSlides.AddClone(sourceSlide, clonedMaster, true);

        // Save the destination presentation
        destPres.Save("Result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        sourcePres.Dispose();
        destPres.Dispose();
    }
}
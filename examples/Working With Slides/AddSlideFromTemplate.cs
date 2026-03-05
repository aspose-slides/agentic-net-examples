using System;

class Program
{
    static void Main()
    {
        // Load the template presentation
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("Template.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the first slide from the template
        Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];

        // Get the master slide associated with the source slide
        Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

        // Clone the master slide into the destination presentation
        Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

        // Clone the source slide into the destination presentation using the cloned master
        destPres.Slides.AddClone(sourceSlide, destMaster, true);

        // Save the resulting presentation
        destPres.Save("Result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        sourcePres.Dispose();
        destPres.Dispose();
    }
}
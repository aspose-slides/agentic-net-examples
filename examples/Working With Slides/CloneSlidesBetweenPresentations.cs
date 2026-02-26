using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the source presentation
        using (Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation("Source.pptx"))
        {
            // Create a new destination presentation
            using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
            {
                // Get the first slide from the source presentation
                Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
                // Get the master slide associated with the source slide
                Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                // Clone the master slide into the destination presentation
                Aspose.Slides.IMasterSlide clonedMaster = destPres.Masters.AddClone(sourceMaster);
                // Clone the source slide into the destination presentation using the cloned master
                Aspose.Slides.ISlide clonedSlide = destPres.Slides.AddClone(sourceSlide, clonedMaster, true);
                // Save the destination presentation
                destPres.Save("ClonedPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
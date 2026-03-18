using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            Presentation sourcePres = new Presentation("source.pptx");

            // Create or load the target presentation
            Presentation targetPres = new Presentation();

            // Get the first slide from the source presentation
            Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];

            // Get the master slide associated with the source slide
            Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

            // Clone the master slide into the target presentation
            Aspose.Slides.IMasterSlideCollection targetMasters = targetPres.Masters;
            Aspose.Slides.IMasterSlide clonedMaster = targetMasters.AddClone(sourceMaster);

            // Clone the source slide into the target presentation using the cloned master
            Aspose.Slides.ISlideCollection targetSlides = targetPres.Slides;
            targetSlides.AddClone(sourceSlide, clonedMaster, true);

            // Save the target presentation
            targetPres.Save("target.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
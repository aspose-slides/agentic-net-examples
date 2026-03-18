using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var sourceTemplatePath = "Template.pptx";
            var existingPresentationPath = "Existing.pptx";
            var outputPath = "Result.pptx";

            using (var sourcePresentation = new Presentation(sourceTemplatePath))
            using (var destinationPresentation = new Presentation(existingPresentationPath))
            {
                // Get the first slide from the template
                var sourceSlide = sourcePresentation.Slides[0];

                // Get the master slide associated with the source slide
                var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                // Clone the master slide into the destination presentation
                var clonedMaster = destinationPresentation.Masters.AddClone(sourceMaster);

                // Insert the slide into the destination presentation using the cloned master
                destinationPresentation.Slides.AddClone(sourceSlide, clonedMaster, true);

                // Save the updated presentation
                destinationPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
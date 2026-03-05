using System;
using Aspose.Slides;

namespace SlideFromTemplateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the template and the output presentation
            string templatePath = "Template.pptx";
            string outputPath = "Result.pptx";

            // Load the template presentation
            using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(templatePath))
            {
                // Create a new empty presentation
                using (Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation())
                {
                    // Get the first slide from the template
                    Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[0];

                    // Get the master slide associated with the source slide's layout
                    Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                    // Clone the master slide into the destination presentation
                    Aspose.Slides.IMasterSlide clonedMaster = destinationPresentation.Masters.AddClone(sourceMaster);

                    // Clone the source slide into the destination presentation using the cloned master
                    Aspose.Slides.ISlide clonedSlide = destinationPresentation.Slides.AddClone(sourceSlide, clonedMaster, true);

                    // Save the resulting presentation
                    destinationPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
    }
}
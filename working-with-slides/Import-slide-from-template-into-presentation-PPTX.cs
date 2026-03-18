using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the template presentation containing the slide to import
                using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation("Template.pptx"))
                {
                    // Load or create the destination presentation
                    using (Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation())
                    {
                        // Get the first slide from the template
                        Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[0];

                        // Get the master slide associated with the source slide
                        Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                        // Clone the master slide into the destination presentation
                        Aspose.Slides.IMasterSlide clonedMaster = destinationPresentation.Masters.AddClone(sourceMaster);

                        // Clone the source slide into the destination presentation using the cloned master
                        destinationPresentation.Slides.AddClone(sourceSlide, clonedMaster, true);

                        // Save the updated presentation
                        destinationPresentation.Save("Result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = "source.pptx";
                string outputPath = "output.pptx";

                using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath))
                {
                    using (Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation())
                    {
                        // Get the first slide from the source presentation
                        Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[0];
                        // Get the master slide associated with the source slide
                        Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                        // Clone the master slide into the destination presentation
                        Aspose.Slides.IMasterSlide clonedMaster = destinationPresentation.Masters.AddClone(sourceMaster);
                        // Clone the source slide into the destination, preserving formatting
                        destinationPresentation.Slides.AddClone(sourceSlide, clonedMaster, true);
                        // Save the resulting presentation
                        destinationPresentation.Save(outputPath, SaveFormat.Pptx);
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
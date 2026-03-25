using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string sourcePath = "source.pptx";
        string outputPath = "output.pptx";

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine($"Source file not found: {sourcePath}");
            return;
        }

        // Load the source presentation
        using (Presentation srcPres = new Presentation(sourcePath))
        {
            // Create a new destination presentation
            using (Presentation destPres = new Presentation())
            {
                // Clone the first slide and its master from the source to the destination
                Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
                Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                destPres.Slides.AddClone(sourceSlide, destMaster, true);

                // Save the resulting presentation
                destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
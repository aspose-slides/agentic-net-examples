using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for source and destination presentations
            string sourcePath = "source.pptx";
            string destinationPath = "destination.pptx";

            // Load the source presentation
            Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);

            // Create a new destination presentation
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            // Indices of slides to copy (0‑based)
            int[] slidesToCopy = new int[] { 0, 2 };

            // Clone each selected slide along with its master
            foreach (int slideIndex in slidesToCopy)
            {
                Aspose.Slides.ISlide sourceSlide = srcPres.Slides[slideIndex];
                Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                destPres.Slides.AddClone(sourceSlide, destMaster, true);
            }

            // Save the destination presentation
            destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            srcPres.Dispose();
            destPres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
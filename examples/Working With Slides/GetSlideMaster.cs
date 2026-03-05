using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
        string sourcePath = Path.Combine(dataDir, "source.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Load the source presentation
        Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);
        // Create a new (empty) destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the first slide from the source presentation
        Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
        // Get the master slide associated with that source slide
        Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

        // Clone the source master slide into the destination presentation
        Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
        // Clone the source slide into the destination presentation using the cloned master
        destPres.Slides.AddClone(sourceSlide, destMaster, true);

        // Save the destination presentation
        destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        srcPres.Dispose();
        destPres.Dispose();
    }
}